using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

namespace Karugamo.Audio
{
    [Serializable]
    public class Audio
    {
        const float LOOP_CHECK_INTERVAL = .2f;

        [SerializeField]
        private AudioClip clip;
        public AudioClip Clip { get { return clip; } private set { clip = value; } }

        /// <summary>
        /// Audio identity string
        /// </summary>
        [SerializeField]
        private string audioId;
        public string AudioId { get { return audioId; } private set { audioId = value; } }

        [SerializeField]
        private bool isLocked;

        /// <summary>
        /// timeSamples between loopStart and loopEnd
        /// </summary>
        [SerializeField]
        private int loopLength;
        public int LoopLength { get { return loopLength; } private set { loopLength = value; } }

        /// <summary>
        /// Intro's timeSamples
        /// </summary>
        [SerializeField]
        private int loopStart;
        public int LoopStart { get { return loopStart; } private set { loopStart = value; } }

        [SerializeField]
        private float volume = 1;
        public float Volume { get { return volume; } private set { volume = value; } }

        [SerializeField]
        private float pitch = 1;
        public float Pitch { get { return pitch; } private set { pitch = value; } }

        private IEnumerator fadeCoroutine;

        private void SetUpProperties(MonoBehaviour monoBehaviour, AudioSource audioSource)
        {
            audioSource.clip = Clip;
            audioSource.volume *= Volume;
            audioSource.pitch *= Pitch;

            if (audioSource.loop && LoopLength > 0)
            {
                monoBehaviour.StartCoroutine(LoopCoroutine(audioSource));
            }
        }

        private int GetLoopEnd()
        {
            int loopEnd = LoopStart + LoopLength;
            int margin = loopEnd + (int)(.3f * Clip.frequency) - Clip.samples;

            if (margin > 0)
            {
                loopEnd -= LoopStart < margin ? LoopStart : margin;
            }

            return loopEnd > 0 ? loopEnd : Clip.samples;
        }

        private IEnumerator LoopCoroutine(AudioSource audioSource)
        {
            int loopLength = LoopLength;
            int loopEnd = GetLoopEnd();
            int loopStart = loopEnd - loopLength;

            while (audioSource != null)
            {
                if (Pitch > 0)
                {
                    if (audioSource.timeSamples >= loopEnd)
                    {
                        Debug.Log(string.Format("Audio Debug - {0} looped from {1} to {2}.", AudioId, audioSource.timeSamples, audioSource.timeSamples - loopLength));
                        audioSource.timeSamples -= loopLength;
                    }
                }
                else
                {
                    if (audioSource.timeSamples < loopStart)
                    {
                        Debug.Log(string.Format("Audio Debug - {0} looped from {1} to {2}.", AudioId, audioSource.timeSamples, audioSource.timeSamples + loopLength));
                        audioSource.timeSamples += loopLength;
                    }
                }
                yield return new WaitForSeconds(LOOP_CHECK_INTERVAL);
            }
        }

        public void Play(MonoBehaviour monoBehaviour, AudioSource audioSource)
        {
            SetUpProperties(monoBehaviour, audioSource);

            StopFade(monoBehaviour);
            if (audioSource.time > 0)
            {
                audioSource.UnPause();
            }
            else
            {
                audioSource.Play();
            }
        }

        public void Stop(MonoBehaviour monoBehaviour, AudioSource audioSource)
        {
            StopFade(monoBehaviour);
            audioSource.Stop();
        }

        public void FadeIn(MonoBehaviour monoBehaviour, AudioSource audioSource, float fadeInTime = 2, float delay = 0, float volumeFrom = 0)
        {
            SetUpProperties(monoBehaviour, audioSource);

            float volumeTo = Volume * audioSource.volume;
            audioSource.volume = volumeFrom;
            StopFade(monoBehaviour);
            fadeCoroutine = FadeCoroutine(audioSource, fadeInTime, delay, volumeTo, audioSource.pitch, true, false);
            monoBehaviour.StartCoroutine(fadeCoroutine);
        }

        public void FadeOut(MonoBehaviour monoBehaviour, AudioSource audioSource, float fadeOutTime = 2)
        {
            StopFade(monoBehaviour);
            fadeCoroutine = FadeCoroutine(audioSource, fadeOutTime, 0, 0, audioSource.pitch, false, true);
            monoBehaviour.StartCoroutine(fadeCoroutine);
        }

        public void Fade(MonoBehaviour monoBehaviour, AudioSource audioSource, float fadeTime, float? volumeTo = null, float? pitchTo = null)
        {
            StopFade(monoBehaviour);
            fadeCoroutine = FadeCoroutine(audioSource, fadeTime, 0, volumeTo ?? audioSource.volume, pitchTo ?? audioSource.pitch, false, false);
            monoBehaviour.StartCoroutine(fadeCoroutine);
        }

        public void StopFade(MonoBehaviour monoBehaviour)
        {
            if (fadeCoroutine != null)
            {
                monoBehaviour.StopCoroutine(fadeCoroutine);
            }
        }

        private IEnumerator FadeCoroutine(AudioSource audioSource, float fadeTime, float delay, float volumeTo, float pitchTo, bool starts, bool stops)
        {
            yield return new WaitForSeconds(delay);
            if (starts)
            {
                if (audioSource.time > 0)
                {
                    audioSource.UnPause();
                }
                else
                {
                    audioSource.Play();
                }
            }

            float volumeFrom = audioSource.volume;
            float pitchFrom = audioSource.pitch;
            float time0 = Time.time;
            float dt = 0;
            while (dt < fadeTime)
            {
                float progress = dt / fadeTime;
                audioSource.volume = Mathf.Lerp(volumeFrom, volumeTo, progress);
                audioSource.pitch = Mathf.Lerp(pitchFrom, pitchTo, progress);
                yield return null;
                dt = Time.time - time0;
            }
            audioSource.volume = volumeTo;
            audioSource.pitch = pitchTo;

            if (stops)
            {
                audioSource.Stop();
            }

            fadeCoroutine = null;
        }

#if UNITY_EDITOR
        /// <summary>
        /// BGMのループ情報をメタタグから抽出する。
        /// </summary>
        public void CompleteLoopInfo()
        {
            try
            {
                Debug.Log("AudioManager Debug - CompleteLoopInfo");
                string projectPath = Application.dataPath.Substring(0, Application.dataPath.Length - 6);
                Debug.Log("AudioManager Debug - project path: " + projectPath);
                string audioFilePath = AssetDatabase.GetAssetPath(Clip);
                Debug.Log("AudioManager Debug - audio file path: " + audioFilePath);
                string filePath = projectPath + audioFilePath;
                LoopLength = LoopStart = 0;
                readMetaAsOgg(filePath);
                readMetaAsMp4(filePath); // Unity では無くても良い
            }
            catch (Exception e)
            {
                Debug.Log("AudioManager Debug - " + e.Message + e.StackTrace);
                LoopLength = LoopStart = -1;
            }
        }

        /// <summary>
        /// ファイルを ogg とみなしてメタデータを取得する。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        private void readMetaAsOgg(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                while (getStringFromReader(stream, 4) == "OggS")
                {
                    getStringFromReader(stream, 22);
                    bool vorbisHeaderFound = false;
                    int segmentsCount = stream.ReadByte();
                    Debug.Log("segmentsCount = " + segmentsCount);
                    var segments = new int[segmentsCount];

                    for (int i = 0; i < segmentsCount; i++)
                    {
                        segments[i] = stream.ReadByte();
                    }
                    Debug.Log("OggS segments[0] = " + segments[0]);

                    for (int i = 0; i < segmentsCount; i++)
                    {
                        int count = segments[i];
                        if (count > 5)
                        {
                            int type = stream.ReadByte();
                            if (getStringFromReader(stream, 4) == "vorb")
                            {
                                vorbisHeaderFound = true;
                                switch (type)
                                {
                                    case 1:
                                        getStringFromReader(stream, 7);
                                        // sampleRate =
                                        getLittleEndianFromReader(stream);
                                        if (count > 16)
                                        {
                                            getStringFromReader(stream, count - 16);
                                        }
                                        break;
                                    case 3:
                                        // 以降のセグメントを全てコメントヘッダとみなす。
                                        while (++i < segmentsCount)
                                        {
                                            count += segments[i];
                                        }
                                        readLoopInfo(stream, count - 5);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            getStringFromReader(stream, count);
                        }
                    }

                    if (!vorbisHeaderFound)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// ファイルを mp4 とみなしてメタデータを取得する。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        private void readMetaAsMp4(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int size = getBigEndianFromReader(stream);
                if (getStringFromReader(stream, 4) == "ftyp")
                {
                    int read = 8;
                    do
                    {
                        if (size > read)
                        {
                            getStringFromReader(stream, size - read);
                        }

                        size = getBigEndianFromReader(stream);
                        string head = getStringFromReader(stream, 4);
                        read = 8;
                        if (head != "moov")
                        {
                            switch (head)
                            {
                                case "mvhd":
                                    getStringFromReader(stream, 12);
                                    //sampleRate =
                                    getBigEndianFromReader(stream);
                                    read += 16;
                                    break;
                                case "udta":
                                case "meta":
                                    if (size > read)
                                    {
                                        readLoopInfo(stream, size - read);
                                    }
                                    read = size;
                                    break;
                            }
                            if (size < 2)
                            {
                                break;
                            }
                        }
                    } while (true);
                }
            }
        }

        /// <summary>
        /// メタ情報から LOOPLENGTH/LOOPSTART を抽出する。
        /// </summary>
        /// <param name="stream">ファイル</param>
        /// <param name="size">読み込みサイズ</param>
        private void readLoopInfo(FileStream stream, int size)
        {
            string text = getStringFromReader(stream, size);
            Debug.Log("AudioManager Debug - readLoopInfo: " + text.Replace('\0', '\n'));
            foreach (Match match in Regex.Matches(text, "LOOP(LENGTH|START)(?:=|\0.{15})([0-9]+)"))
            {
                if (match.Groups[1].Value == "LENGTH")
                {
                    LoopLength = Convert.ToInt32(match.Groups[2].Value);
                }
                else // START
                {
                    LoopStart = Convert.ToInt32(match.Groups[2].Value);
                }
            }
        }

        /// <summary>
        /// ファイルの現在位置から指定バイト数分返す。
        /// </summary>
        /// <param name="stream">ファイル</param>
        /// <param name="count">バイト数</param>
        /// <returns>バイト配列</returns>
        private byte[] getBytesFromReader(FileStream stream, int count)
        {
            var buffer = new byte[count];
            int index = 0;
            int readCount = 1;
            while (count > 0 && readCount > 0)
            {
                readCount = stream.Read(buffer, index, count);
                index += readCount;
                count -= readCount;
            }
            return buffer;
        }

        /// <summary>
        /// ファイルの現在位置から指定文字数分取得して文字列として返す。
        /// </summary>
        /// <param name="stream">ファイル</param>
        /// <param name="count">文字数</param>
        /// <returns>文字列</returns>
        private string getStringFromReader(FileStream stream, int count)
        {
            return Encoding.UTF8.GetString(getBytesFromReader(stream, count));
        }

        /// <summary>
        /// ファイルの現在位置からの 4 バイトをリトルエンディアンとみなして数値を返す。
        /// </summary>
        /// <param name="stream">ファイル</param>
        /// <returns>数値</returns>
        private int getLittleEndianFromReader(FileStream stream)
        {
            var buffer = getBytesFromReader(stream, 4);
            return buffer[3] * 0x1000000 + buffer[2] * 0x10000 + buffer[1] * 0x100 + buffer[0];
        }

        /// <summary>
        /// ファイルの現在位置からの 4 バイトをビッグエンディアンとみなして数値を返す。
        /// </summary>
        /// <param name="stream">ファイル</param>
        /// <returns>数値</returns>
        private int getBigEndianFromReader(FileStream stream)
        {
            var buffer = getBytesFromReader(stream, 4);
            return buffer[0] * 0x1000000 + buffer[1] * 0x10000 + buffer[2] * 0x100 + buffer[3];
        }

        public class AudioManagerEditorWindow : EditorWindow
        {
            string defaultName;

            ReorderableList reorderableList;
            Dictionary<string, int> audioId2count;

            Vector2 scrollPosition;
            Color backgroundColor;
            Color horizontalLineColor;
            float maxWidth = 100;
            int scrollBoxHeight = 600;
            bool is2columns = false;
            int nextSelectedIndex = -2;
            long nextCheckLoopTicks = 0;
            bool isGameStarted;

            AudioSource debugBaseAudioSource;
            AudioSource debugPlayingAudioSource;
            Audio currentAudio;
            IEnumerator debugLoopCoroutine;

            private void OnEnable()
            {
                var audioManager = AudioManager.Instance;
                if (audioManager == null)
                {
                    return;
                }

                var md5 = System.Security.Cryptography.MD5.Create();
                defaultName = "Audio_" + BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(DateTime.Now.Ticks.ToString()))).ToLower().Replace("-", "") + "_";
                md5.Clear();

                reorderableList = new ReorderableList(audioManager.Audios, typeof(Audio), true, false, false, false);
                audioId2count = new Dictionary<string, int>();

                scrollPosition = new Vector2();
                backgroundColor = new Color(.9f, .9f, .9f, .8f);
                horizontalLineColor = new Color(.8f, .8f, .8f, .8f);

                reorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
                {
                    if (rect.width > 20)
                    {
                        maxWidth = rect.width;
                        is2columns = maxWidth > 400;
                    }
                    var wholeRect = new Rect(rect.x, rect.y, rect.width, GetElementHeight(index) - 2);
                    EditorGUI.DrawRect(wholeRect, backgroundColor);
                    var audio = audioManager.Audios[index];
                    GUI.SetNextControlName(defaultName + index + "_1");
                    rect.height = 22;
                    EditorGUI.BeginDisabledGroup(isGameStarted);
                    var clip = EditorGUI.ObjectField(rect, audio.Clip, typeof(AudioClip), true) as AudioClip;
                    EditorGUI.EndDisabledGroup();
                    if (clip != audio.Clip)
                    {
                        audio.Clip = clip;
                        if (!audio.isLocked)
                        {
                            audio.AudioId = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(clip));
                            audio.CompleteLoopInfo();
                            audioManager.IndexAudios();
                        }
                    }

                    if (audio.Clip != null)
                    {
                        rect.y += 24;
                        var labelRect = new Rect(rect);
                        labelRect.width = 70;
                        var inputRect = new Rect(labelRect);
                        inputRect.width = maxWidth - 150;
                        inputRect.height = 15;
                        inputRect.x += labelRect.width + 5;
                        var toggleRect = new Rect(inputRect);
                        toggleRect.width = 60;
                        toggleRect.x += inputRect.width + 10;

                        // AudioId
                        EditorGUI.BeginDisabledGroup(isGameStarted);
                        SetLabel(labelRect, "AudioId");
                        EditorGUI.EndDisabledGroup();

                        if (string.IsNullOrEmpty(audio.AudioId) || audioId2count.ContainsKey(audio.AudioId) && audioId2count[audio.AudioId] > 1)
                        {
                            EditorGUI.DrawRect(inputRect, Color.red);
                        }
                        EditorGUI.BeginDisabledGroup(isGameStarted || audio.isLocked);
                        GUI.SetNextControlName(defaultName + index + "_2");
                        string audioId = (string)SetField(inputRect, audio.AudioId);
                        if (audio.AudioId != audioId)
                        {
                            audio.AudioId = audioId;
                            audioManager.IndexAudios();
                        }
                        EditorGUI.EndDisabledGroup();

                        EditorGUI.BeginDisabledGroup(isGameStarted);

                        GUI.SetNextControlName(defaultName + index + "_3");
                        audio.isLocked = EditorGUI.ToggleLeft(toggleRect, "lock", audio.isLocked);

                        // LoopStart
                        labelRect.y += 16;
                        inputRect.y += 16;
                        if (is2columns)
                        {
                            inputRect.width = 80;
                        }
                        SetLabel(labelRect, "LoopStart");
                        GUI.SetNextControlName(defaultName + index + "_4");
                        EditorGUI.BeginDisabledGroup(debugLoopCoroutine != null);
                        audio.LoopStart = (int)SetField(inputRect, audio.LoopStart);
                        EditorGUI.EndDisabledGroup();

                        // LoopLength
                        labelRect.y += 16;
                        inputRect.y += 16;
                        SetLabel(labelRect, "LoopLength");
                        GUI.SetNextControlName(defaultName + index + "_5");
                        EditorGUI.BeginDisabledGroup(debugLoopCoroutine != null);
                        audio.LoopLength = (int)SetField(inputRect, audio.LoopLength);
                        EditorGUI.EndDisabledGroup();

                        // Volume
                        if (is2columns)
                        {
                            labelRect.x += 170;
                            labelRect.y -= 16;
                            inputRect.x += 150;
                            inputRect.y -= 16;
                            inputRect.width = maxWidth - 250;
                        }
                        else
                        {
                            labelRect.y += 16;
                            inputRect.y += 16;
                            inputRect.width = maxWidth - 100;
                        }
                        SetLabel(labelRect, "Volume");
                        GUI.SetNextControlName(defaultName + index + "_6");
                        EditorGUI.BeginDisabledGroup(debugLoopCoroutine != null);
                        audio.Volume = EditorGUI.Slider(inputRect, audio.Volume, 0, 3);
                        EditorGUI.EndDisabledGroup();

                        // Pitch
                        labelRect.y += 16;
                        inputRect.y += 16;
                        SetLabel(labelRect, "Pitch");
                        GUI.SetNextControlName(defaultName + index + "_7");
                        EditorGUI.BeginDisabledGroup(debugLoopCoroutine != null);
                        audio.Pitch = EditorGUI.Slider(inputRect, audio.Pitch, -3, 3);
                        EditorGUI.EndDisabledGroup();

                        EditorGUI.EndDisabledGroup();

                        if (audio == currentAudio && debugPlayingAudioSource != null)
                        {
                            debugPlayingAudioSource.volume = debugBaseAudioSource.volume * audio.Volume;
                            debugPlayingAudioSource.pitch = debugBaseAudioSource.pitch * audio.Pitch;
                        }
                    }

                    EditorGUI.DrawRect(new Rect(wholeRect.x, wholeRect.y + wholeRect.height - 1, wholeRect.width, 1), horizontalLineColor);
                };

                reorderableList.elementHeightCallback = GetElementHeight;

                reorderableList.onMouseUpCallback = TestAudio;

                reorderableList.onSelectCallback = OnSelect;
            }

            private void OnDisable()
            {
                if (debugPlayingAudioSource != null)
                {
                    AudioManager.Instance.StopBGM();
                    debugPlayingAudioSource = null;
                    currentAudio = null;
                }
            }

            private void SetLabel(Rect rect, string label)
            {
                var labelStyle = new GUIStyle(EditorStyles.label) { fontSize = 10 };
                EditorGUI.LabelField(rect, label, labelStyle);
            }

            private object SetField(Rect rect, object value)
            {
                var fieldStyle = new GUIStyle(EditorStyles.textField) { fixedHeight = 15, fontSize = 10 };

                if (value is int)
                {
                    value = EditorGUI.IntField(rect, (int)value, fieldStyle);
                }
                else
                {
                    value = EditorGUI.TextField(rect, (string)value, fieldStyle);
                }

                return value;
            }

            private float GetElementHeight(int index)
            {
                return 24 + 16 * (AudioManager.Instance.Audios[index].Clip != null ? is2columns ? 3 : 5 : 0) + 2;
            }

            private void TestAudio(ReorderableList list)
            {
                if (isGameStarted)
                {
                    return;
                }

                var audioManager = AudioManager.Instance;
                var audio = audioManager.Audios[list.index];
                var clip = audio.Clip;

                audioManager.StopBGM();
                debugLoopCoroutine = null;

                if (clip != null && audio != currentAudio)
                {
                    if (debugBaseAudioSource != null)
                    {
                        audioManager.ReleaseAudioSource(debugBaseAudioSource);
                    }
                    debugBaseAudioSource = audioManager.InstantiateAudioSource(audioManager.BaseBGMSource);
                    if (debugBaseAudioSource.volume == 0)
                    {
                        EditorUtility.DisplayDialog("Debug Audio Warning", "BaseBGMSource's volume is zero.", "OK");
                        debugBaseAudioSource.volume = 1;
                    }
                    if (debugBaseAudioSource.pitch == 0)
                    {
                        EditorUtility.DisplayDialog("Debug Audio Warning", "BaseBGMSource's pitch is zero.", "OK");
                        debugBaseAudioSource.pitch = 1;
                    }

                    currentAudio = audio;
                    switch (audioManager.DebugModeIndex)
                    {
                        case 0:
                            debugBaseAudioSource.loop = false;
                            debugPlayingAudioSource = audioManager.GetPlayingAudioSourceByName(audioManager.PlayBGM(audioId: audio.AudioId, baseBGMSource: debugBaseAudioSource));
                            break;
                        case 1:
                            debugBaseAudioSource.loop = true;
                            debugPlayingAudioSource = audioManager.GetPlayingAudioSourceByName(audioManager.PlayBGM(audioId: audio.AudioId, baseBGMSource: debugBaseAudioSource));
                            debugLoopCoroutine = DebugLoopCoroutine(false);
                            debugLoopCoroutine.MoveNext();
                            break;
                        case 2:
                            {
                                float baseVolume = debugBaseAudioSource.volume;
                                int samples = audio.clip.samples;
                                int frequency = audio.clip.frequency;
                                bool isLoopTest = samples > frequency * 12;
                                debugBaseAudioSource.loop = true;
                                if (isLoopTest)
                                {
                                    debugBaseAudioSource.volume = 0;
                                    debugBaseAudioSource.timeSamples = (audio.LoopLength > 0 ? audio.LoopStart + audio.LoopLength : samples) - (int)(frequency * 5.5f);
                                }
                                debugPlayingAudioSource = audioManager.GetPlayingAudioSourceByName(audioManager.PlayBGM(audioId: audio.AudioId, baseBGMSource: debugBaseAudioSource));
                                if (isLoopTest)
                                {
                                    debugBaseAudioSource.volume = baseVolume;
                                }
                                debugLoopCoroutine = DebugLoopCoroutine(isLoopTest);
                                debugLoopCoroutine.MoveNext();
                            }
                            break;
                    }
                }
                else
                {
                    debugPlayingAudioSource = null;
                    currentAudio = null;
                }
            }

            public void Update()
            {
                if (debugLoopCoroutine != null)
                {
                    debugLoopCoroutine.MoveNext();
                }
            }

            private IEnumerator DebugLoopCoroutine(bool isLoopTest)
            {
                var audioManager = AudioManager.Instance;
                var audioSource = debugPlayingAudioSource;
                float pitch = currentAudio.Pitch;
                float baseVolume = debugBaseAudioSource.volume * currentAudio.Volume;
                int frequency = currentAudio.clip.frequency;
                int sign = pitch > 0 ? 1 : -1;
                int signedFrequency = sign * frequency;
                int loopLength = currentAudio.LoopLength;
                int loopEnd = currentAudio.GetLoopEnd();
                IEnumerator loopCoroutine = audioSource.loop && loopLength > 0 ? currentAudio.LoopCoroutine(audioSource) : null;
                loopLength = loopLength > 0 ? loopLength : loopEnd;
                int loopMid = loopEnd - loopLength / 2;
                int loopStart = loopEnd - loopLength;

                if (sign == -1)
                {
                    int t = loopEnd;
                    loopEnd = loopStart;
                    loopStart = t;
                }

                nextCheckLoopTicks = DateTime.Now.Ticks;

                while (audioSource == debugPlayingAudioSource)
                {
                    if (loopCoroutine != null && DateTime.Now.Ticks >= nextCheckLoopTicks)
                    {
                        nextCheckLoopTicks += (long)(10000000 * LOOP_CHECK_INTERVAL);

                        loopCoroutine.MoveNext();
                    }

                    if (isLoopTest)
                    {
                        int timeSamples = audioSource.timeSamples;
                        float rate = 0;
                        if (sign * (timeSamples - loopMid) > 0)
                        {
                            float timeFromLoopEnd = (float)(timeSamples - loopEnd) / signedFrequency;
                            rate = (5 + timeFromLoopEnd) / 2;
                        }
                        else
                        {
                            float timeFromLoopStart = (float)(timeSamples - loopStart) / signedFrequency;
                            if (timeFromLoopStart < 2.8f)
                            {
                                rate = 1;
                            }
                            else if (timeFromLoopStart < 4.8f)
                            {
                                rate = (4.8f - timeFromLoopStart) / 2;
                            }
                            else
                            {
                                audioSource.timeSamples = loopEnd - signedFrequency * 5 - sign * UnityEngine.Random.Range(0, frequency / 2);
                            }
                        }

                        audioSource.volume = baseVolume * (rate < 0 ? 0 : rate > 1 ? 1 : rate);
                    }

                    yield return 0;
                }
            }

            private void OnSelect(ReorderableList list)
            {
                // Scrolls automatically if the current list item is out of sight.
                float y = scrollPosition.y;
                float prevAllHeight = list.headerHeight;
                int j = list.index;
                for (int i = 0; i < j; i++)
                {
                    prevAllHeight += GetElementHeight(i);
                }
                float currentHeight = GetElementHeight(j);
                float upper = prevAllHeight - scrollBoxHeight + currentHeight + list.footerHeight;
                float lower = prevAllHeight - list.headerHeight;
                if (y < upper)
                {
                    y = upper;
                }
                else if (lower < y)
                {
                    y = lower;
                }
                else
                {
                    return;
                }
                scrollPosition.y = y;
            }

            /// <summary>
            /// Update Inspector GUI
            /// </summary>
            private void OnGUI()
            {
                if (reorderableList == null)
                {
                    if (AudioManager.Instance == null)
                    {
                        return;
                    }

                    OnEnable();
                }

                string focusedName = GUI.GetNameOfFocusedControl();
                var buttonWidth = GUILayout.Width(80);
                int index = reorderableList.index;
                int oldIndex = index;
                int count = reorderableList.count;
                var audioManager = AudioManager.Instance;
                bool is2or3rows = position.width < 805;
                bool is3rows = position.width < 520;

                audioId2count = audioManager.Audios.GroupBy(audio => audio.AudioId ?? "").ToDictionary(g => g.Key, g => g.Count());
                scrollBoxHeight = (int)position.height - (is3rows ? 76 : is2or3rows ? 53 : 21);
                isGameStarted = EditorApplication.isPlayingOrWillChangePlaymode || EditorApplication.isPaused;

                EditorGUI.BeginDisabledGroup(isGameStarted);
                EditorGUILayout.BeginHorizontal();
                if (count == 0)
                {
                    if (GUILayout.Button("+ Add", buttonWidth))
                    {
                        audioManager.Audios.Add(new Audio());
                        audioManager.IndexAudios();
                    }
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();
                    EditorGUI.EndDisabledGroup();
                    return;
                }

                if (GUILayout.Button("+ Add Prev", buttonWidth))
                {
                    if (-1 < index && index <= count)
                    {
                        nextSelectedIndex = index;
                        audioManager.Audios.Insert(index, new Audio());
                        audioManager.IndexAudios();
                    }
                    else
                    {
                        nextSelectedIndex = 0;
                        audioManager.Audios.Insert(0, new Audio());
                        audioManager.IndexAudios();
                    }
                }
                if (GUILayout.Button("+ Add Next", buttonWidth))
                {
                    nextSelectedIndex = index < count ? index + 1 : count;
                    audioManager.Audios.Insert(nextSelectedIndex, new Audio());
                    audioManager.IndexAudios();
                    if (index > -1)
                    {
                        scrollPosition.y += GetElementHeight(index);
                    }
                }

                EditorGUI.EndDisabledGroup();
                GUILayout.Space(10);

                EditorGUI.BeginDisabledGroup(isGameStarted || index < 0);
                if (GUILayout.Button("- Remove", buttonWidth))
                {
                    audioManager.Audios.RemoveAt(index);
                    audioManager.IndexAudios();
                    nextSelectedIndex = index >= count - 1 ? index - 1 : index;
                }
                EditorGUI.EndDisabledGroup();

                EditorGUI.BeginDisabledGroup(isGameStarted);

                if (is2or3rows)
                {
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(2);
                    GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
                    GUILayout.Space(2);
                    EditorGUILayout.BeginHorizontal();
                }
                else
                {
                    GUILayout.Space(10);
                    GUILayout.Box("", GUILayout.Width(1), GUILayout.Height(16));
                    GUILayout.Space(10);
                }

                if (GUILayout.Button("<< Prev", buttonWidth))
                {
                    if (index < 1)
                    {
                        reorderableList.index = count;
                    }
                    reorderableList.index--;

                    if (focusedName.IndexOf(defaultName) == 0)
                    {
                        string[] nameParts = focusedName.Split('_');
                        nameParts[2] = reorderableList.index.ToString();
                        focusedName = string.Join("_", nameParts);
                        GUI.FocusControl(focusedName);
                    }
                    OnSelect(reorderableList);

                    if (debugPlayingAudioSource != null)
                    {
                        TestAudio(reorderableList);
                    }
                }
                if (GUILayout.Button("Play/Stop", buttonWidth))
                {
                    if (index < 0 || count <= index)
                    {
                        reorderableList.index = 0;
                    }
                    TestAudio(reorderableList);
                }
                if (GUILayout.Button("Next >>", buttonWidth))
                {
                    if (index < 0)
                    {
                        reorderableList.index = -1;
                    }
                    reorderableList.index = (index + 1) % count;

                    if (focusedName.IndexOf(defaultName) == 0)
                    {
                        string[] nameParts = focusedName.Split('_');
                        nameParts[2] = reorderableList.index.ToString();
                        focusedName = string.Join("_", nameParts);
                        GUI.FocusControl(focusedName);
                    }
                    OnSelect(reorderableList);

                    if (debugPlayingAudioSource != null)
                    {
                        TestAudio(reorderableList);
                    }
                }

                if (is3rows)
                {
                    GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(2);
                    EditorGUILayout.BeginHorizontal();
                }
                else
                {
                    GUILayout.Space(10);
                }

                GUILayout.Label("Debug:");
                audioManager.DebugModeIndex = GUILayout.SelectionGrid(audioManager.DebugModeIndex, new[] { "Normal", "Loop", "LoopTest" }, 3);
                GUILayout.FlexibleSpace();
                EditorGUILayout.EndHorizontal();

                EditorGUI.EndDisabledGroup();

                // main list
                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.Height(scrollBoxHeight));
                reorderableList.DoLayoutList();
                EditorGUILayout.EndScrollView();

                if (nextSelectedIndex > -2)
                {
                    if (nextSelectedIndex > -1)
                    {
                        if (focusedName.IndexOf(defaultName) == 0)
                        {
                            var nameParts = focusedName.Split('_');
                            nameParts[2] = nextSelectedIndex.ToString();
                            GUI.FocusControl(string.Join("_", nameParts));
                        }

                        reorderableList.index = nextSelectedIndex;
                    }

                    nextSelectedIndex = -2;
                }

                if (oldIndex == reorderableList.index && focusedName.IndexOf(defaultName) == 0)
                {
                    int focusedIndex = Convert.ToInt32(focusedName.Split('_')[2]);
                    if (oldIndex != focusedIndex && focusedIndex < count)
                    {
                        reorderableList.index = focusedIndex;
                        OnSelect(reorderableList);
                    }
                }
            }
        }
#endif
    }
}


