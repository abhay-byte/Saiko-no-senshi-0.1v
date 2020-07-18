using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Karugamo.Audio
{
    /// <summary>
    /// AudioManager - Loopable BGMs & SEs Management Class
    /// </summary>
    [ExecuteInEditMode()]
    public class AudioManager : MonoBehaviour
    {
        private const int AUDIO_SOURCE_POOL_SIZE = 32;

        public enum PlayMode
        {
            // Plays (or fades-in) only if the same audios are stopped all, or otherwise does nothing.
            IgnoreSame = 0,

            // Stops to fade-out and plays (or fade-in) if the same audio(s) is fading-out, or otherwise behaves like IgnoreSame.
            StopFadingOutSame,

            // Stops immediately if the same audio(s) is already playing, then plays (or fades-in).
            RestartSame,

            // Always plays (or fades-in), even if the same audio(s) is already playing.
            DuplicateSame,
        }

        public static AudioManager Instance { get; private set; }

        [SerializeField]
        private List<Audio> audios = new List<Audio>();
#if UNITY_EDITOR
        public List<Audio> Audios { get { return audios; } set { audios = value; } }
#else
        private List<Audio> Audios { get { return audios; } set { audios = value; } }
#endif

        [SerializeField]
        private int debugModeIndex = 0;
#if UNITY_EDITOR
        private Audio.AudioManagerEditorWindow AudioManagerEditorWindow { get; set; }
        public int DebugModeIndex { get { return debugModeIndex; } set { debugModeIndex = value; } }
#endif

        public AudioSource BaseBGMSource { get; set; }
        public AudioSource BaseSESource { get; set; }

        private Dictionary<string, Audio> audioId2audio;

        private GameObject instantAudioSources;

        private Queue<GameObject> audioSourcePool;

        private uint lastNameId = 0;
        private Dictionary<string, Audio> name2audio;
        private Dictionary<string, List<AudioSource>> audioId2playingBGMs;
        private Dictionary<string, List<AudioSource>> audioId2playingSEs;
        private Dictionary<string, AudioSource> name2playingAudioSource;
        private Dictionary<string, AudioSource> name2playingLoopableAudioSource;
        private Dictionary<string, bool> name2fadesOut;

        /// <summary>
        /// Initializes.
        /// </summary>
        public void Awake()
        {
            SetBaseSourcesFromGameObjects();
            IndexAudios();

            var iasTransform = transform.parent.Find("InstantAudioSources");
            if (iasTransform == null)
            {
                instantAudioSources = new GameObject("InstantAudioSources");
                instantAudioSources.transform.SetParent(transform.parent);
                instantAudioSources.hideFlags = HideFlags.NotEditable;
            }
            else
            {
                instantAudioSources = iasTransform.gameObject;
            }

            foreach (var audioSource in instantAudioSources.GetComponentsInChildren<AudioSource>())
            {
                DestroyImmediate(audioSource.gameObject);
            }

            audioSourcePool = new Queue<GameObject>(AUDIO_SOURCE_POOL_SIZE);
            int i = 0;
            foreach (var audioSource in instantAudioSources.GetComponentsInChildren<AudioSource>(true))
            {
                if (i < AUDIO_SOURCE_POOL_SIZE)
                {
                    audioSourcePool.Enqueue(audioSource.gameObject);
                    i++;
                }
                else
                {
                    DestroyImmediate(audioSource.gameObject);
                }
            }
            while (i++ < AUDIO_SOURCE_POOL_SIZE)
            {
                var instantAudioSource = new GameObject();
                instantAudioSource.SetActive(false);
                instantAudioSource.hideFlags = HideFlags.NotEditable;
                instantAudioSource.transform.SetParent(instantAudioSources.transform);
                instantAudioSource.AddComponent<AudioSource>();
                audioSourcePool.Enqueue(instantAudioSource);
            }

            name2audio = new Dictionary<string, Audio>();
            audioId2playingBGMs = new Dictionary<string, List<AudioSource>>();
            audioId2playingSEs = new Dictionary<string, List<AudioSource>>();
            name2playingAudioSource = new Dictionary<string, AudioSource>();
            name2playingLoopableAudioSource = new Dictionary<string, AudioSource>();
            name2fadesOut = new Dictionary<string, bool>();

            // Registers a singleton instance.
#if UNITY_EDITOR
            Instance = this;
#else
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
#endif
        }

#if UNITY_EDITOR
        public void IndexAudios()
#else
        private void IndexAudios()
#endif
        {
            audioId2audio = new Dictionary<string, Audio>();
            foreach (var audio in Audios)
            {
                if (!string.IsNullOrEmpty(audio.AudioId))
                {
                    audioId2audio[audio.AudioId] = audio;
                }
            }
        }

        public void SetBaseSourcesFromGameObjects()
        {
            BaseBGMSource = null;
            BaseSESource = null;
            // Sets default AudioSource from siblings
            foreach (var audioSource in transform.parent.gameObject.GetComponentsInChildren<AudioSource>())
            {
                switch (audioSource.gameObject.name)
                {
                    case "BaseBGMSource":
                        BaseBGMSource = audioSource;
                        break;
                    case "BaseSESource":
                        BaseSESource = audioSource;
                        break;
                }
            }

            if (BaseBGMSource == null)
            {
                // Sets default AudioSource from all
                var obj = GameObject.Find("BaseBGMSource");
                if (obj != null)
                {
                    BaseBGMSource = obj.GetComponent<AudioSource>();
                }

                if (BaseBGMSource == null)
                {
                    throw new NullReferenceException("GameObject named \"BaseBGMSource\" with AudioSource is not found.");
                }
            }

            if (BaseSESource == null)
            {
                // Sets default AudioSource from all
                var obj = GameObject.Find("BaseSESource");
                if (obj != null)
                {
                    BaseSESource = obj.GetComponent<AudioSource>();
                }

                if (BaseSESource == null)
                {
                    throw new NullReferenceException("GameObject named \"BaseSESource\" with AudioSource is not found.");
                }
            }
        }

        public AudioSource InstantiateAudioSource(AudioSource baseAudioSource)
        {
            AudioSource audioSource = null;

            var instantAudioSource = audioSourcePool.Count > 0 ? audioSourcePool.Dequeue() : null;
            if (instantAudioSource == null)
            {
                instantAudioSource = new GameObject();
                instantAudioSource.hideFlags = HideFlags.NotEditable;
                instantAudioSource.transform.SetParent(instantAudioSources.transform);
            }
            else
            {
                audioSource = instantAudioSource.GetComponent<AudioSource>();
            }
            instantAudioSource.SetActive(true);

            if (audioSource == null)
            {
                audioSource = instantAudioSource.AddComponent<AudioSource>();
            }

            audioSource.bypassEffects = baseAudioSource.bypassEffects;
            audioSource.bypassListenerEffects = baseAudioSource.bypassListenerEffects;
            audioSource.bypassReverbZones = baseAudioSource.bypassReverbZones;
            audioSource.clip = null;
            audioSource.dopplerLevel = baseAudioSource.dopplerLevel;
            audioSource.enabled = baseAudioSource.enabled;
            //audioSource.gameObject
            //audioSource.hideFlags
            audioSource.ignoreListenerPause = baseAudioSource.ignoreListenerPause;
            audioSource.ignoreListenerVolume = baseAudioSource.ignoreListenerVolume;
            audioSource.loop = baseAudioSource.loop;
            audioSource.maxDistance = baseAudioSource.maxDistance;
            audioSource.minDistance = baseAudioSource.minDistance;
            audioSource.mute = false;
            audioSource.name = string.Format("Karugamo.AudioSource.{0}", ++lastNameId);
            audioSource.outputAudioMixerGroup = baseAudioSource.outputAudioMixerGroup;
            audioSource.panStereo = baseAudioSource.panStereo;
            audioSource.pitch = baseAudioSource.pitch;
            audioSource.playOnAwake = false;
            audioSource.priority = baseAudioSource.priority;
            audioSource.reverbZoneMix = baseAudioSource.reverbZoneMix;
            audioSource.rolloffMode = baseAudioSource.rolloffMode;
            audioSource.spatialBlend = baseAudioSource.spatialBlend;
            audioSource.spatialize = baseAudioSource.spatialize;
            audioSource.spread = baseAudioSource.spread;
            //audioSource.tag
            audioSource.time = baseAudioSource.time;
            audioSource.timeSamples = baseAudioSource.timeSamples;
            audioSource.velocityUpdateMode = baseAudioSource.velocityUpdateMode;
            audioSource.volume = baseAudioSource.volume;

            return audioSource;
        }

        public AudioSource GetPlayingAudioSourceByName(string name)
        {
            return name != null && name2playingAudioSource.ContainsKey(name) ? name2playingAudioSource[name] : null;
        }

        private Audio GetAudio(string audioId)
        {
            if (audioId2audio.ContainsKey(audioId))
            {
                return audioId2audio[audioId];
            }

            Debug.Log(audioId2audio.Keys);
            throw new KeyNotFoundException(string.Format("Audio {0} is not found.", audioId));
        }

        private void Play(Audio audio, float fadeInTime, float delay, AudioSource audioSource)
        {
            string name = audioSource.name;
            name2audio[name] = audio;
            name2playingAudioSource[name] = audioSource;

            audioSource.clip = audio.Clip;

            if (audioSource.loop)
            {
                name2playingLoopableAudioSource[name] = audioSource;
            }

            if (fadeInTime > 0 || delay > 0)
            {
                audio.FadeIn(this, audioSource, fadeInTime, delay);
            }
            else
            {
                audio.Play(this, audioSource);
            }
        }

        public string PlayBGMAtPoint(string audioId, Vector3 position, AudioSource baseBGMSource = null)
        {
            var audio = GetAudio(audioId);
            if (audioId2playingBGMs.ContainsKey(audioId))
            {
                audioId2playingBGMs[audioId] = new List<AudioSource>();
            }

            var audioSource = InstantiateAudioSource(baseBGMSource != null ? baseBGMSource : BaseBGMSource);
            audioSource.transform.position = position;
            Play(audio, 0, 0, audioSource);
            audioId2playingBGMs[audioId].Add(audioSource);

            return audioSource.name;
        }

        public string PlaySEAtPoint(string audioId, Vector3 position, AudioSource baseSESource = null)
        {
            var audio = GetAudio(audioId);
            if (audioId2playingSEs.ContainsKey(audioId))
            {
                audioId2playingSEs[audioId] = new List<AudioSource>();
            }

            var audioSource = InstantiateAudioSource(baseSESource != null ? baseSESource : BaseSESource);
            audioSource.transform.position = position;
            Play(audio, 0, 0, audioSource);
            audioId2playingSEs[audioId].Add(audioSource);

            return audioSource.name;
        }

        public string PlayBGM(string audioId, PlayMode playMode = PlayMode.StopFadingOutSame, AudioSource baseBGMSource = null)
        {
            return FadeInBGM(audioId, 0, 0, playMode, baseBGMSource);
        }

        public string PlayBGM(string audioId, float delay, PlayMode playMode = PlayMode.StopFadingOutSame, AudioSource baseBGMSource = null)
        {
            return FadeInBGM(audioId, 0, delay, playMode, baseBGMSource);
        }

        public string PlaySE(string audioId, PlayMode playMode = PlayMode.RestartSame, AudioSource baseSESource = null)
        {
            return FadeInSE(audioId, 0, 0, playMode, baseSESource);
        }

        public string PlaySE(string audioId, float delay, PlayMode playMode = PlayMode.RestartSame, AudioSource baseSESource = null)
        {
            return FadeInSE(audioId, 0, delay, playMode, baseSESource);
        }

        public string FadeInBGM(string audioId, float fadeInTime = 2, float delay = 0, PlayMode playMode = PlayMode.IgnoreSame, AudioSource baseBGMSource = null)
        {
            var audio = GetAudio(audioId);
            if (audioId2playingBGMs.ContainsKey(audioId))
            {
                var playingAudioSources = audioId2playingBGMs[audioId];
                if (playingAudioSources.Count > 0)
                {
                    switch (playMode)
                    {
                        case PlayMode.IgnoreSame:
                            return playingAudioSources.First().name;
                        case PlayMode.StopFadingOutSame:
                            foreach (var playingAudioSource in playingAudioSources)
                            {
                                string name = playingAudioSource.name;
                                if (name2fadesOut.ContainsKey(name))
                                {
                                    name2fadesOut.Remove(name);
                                    audio.FadeIn(this, playingAudioSource, fadeInTime > 0 ? fadeInTime : 2, 0, playingAudioSource.volume);
                                }
                                return name;
                            }
                            break;
                        case PlayMode.RestartSame:
                            foreach (var playingAudioSource in playingAudioSources)
                            {
                                Stop(playingAudioSource.name);
                            }
                            break;
                        case PlayMode.DuplicateSame:
                        default:
                            break;
                    }
                }
            }
            else
            {
                audioId2playingBGMs[audioId] = new List<AudioSource>();
            }

            var audioSource = InstantiateAudioSource(baseBGMSource != null ? baseBGMSource : BaseBGMSource);
            Play(audio, fadeInTime, delay, audioSource);
            audioId2playingBGMs[audioId].Add(audioSource);

            return audioSource.name;
        }

        public string FadeInSE(string audioId, float fadeInTime = 2, float delay = 0, PlayMode playMode = PlayMode.RestartSame, AudioSource baseSESource = null)
        {
            var audio = GetAudio(audioId);
            if (audioId2playingSEs.ContainsKey(audioId))
            {
                var playingAudioSources = audioId2playingSEs[audioId];
                if (playingAudioSources.Count > 0)
                {
                    switch (playMode)
                    {
                        case PlayMode.IgnoreSame:
                            return playingAudioSources.First().name;
                        case PlayMode.StopFadingOutSame:
                            foreach (var playingAudioSource in playingAudioSources)
                            {
                                string name = playingAudioSource.name;
                                if (name2fadesOut.ContainsKey(name))
                                {
                                    name2fadesOut.Remove(name);
                                    audio.FadeIn(this, playingAudioSource, fadeInTime > 0 ? fadeInTime : 2, 0, playingAudioSource.volume);
                                    return name;
                                }
                            }
                            break;
                        case PlayMode.RestartSame:
                            foreach (var playingAudioSource in playingAudioSources)
                            {
                                Stop(playingAudioSource.name);
                            }
                            break;
                        case PlayMode.DuplicateSame:
                        default:
                            break;
                    }
                }
            }
            else
            {
                audioId2playingSEs[audioId] = new List<AudioSource>();
            }

            var audioSource = InstantiateAudioSource(baseSESource != null ? baseSESource : BaseSESource);
            Play(audio, fadeInTime, delay, audioSource);
            audioId2playingSEs[audioId].Add(audioSource);

            return audioSource.name;
        }

        public void FadeBGM(string audioId = null, float? volumeTo = null, float? pitchTo = null, float fadeTime = 2)
        {
            foreach (var audioSource in GetPlayingBGMs(audioId))
            {
                name2audio[audioSource.name].Fade(this, audioSource, fadeTime, volumeTo, pitchTo);
            }
        }

        public void FadeSE(string audioId = null, float? volumeTo = null, float? pitchTo = null, float fadeTime = 2)
        {
            foreach (var audioSource in GetPlayingSEs(audioId))
            {
                name2audio[audioSource.name].Fade(this, audioSource, fadeTime, volumeTo, pitchTo);
            }
        }

        private IEnumerable<AudioSource> GetPlayingBGMs(string audioId = null)
        {
            if (audioId == null)
            {
                foreach (var pair in audioId2playingBGMs)
                {
                    foreach (var audioSource in pair.Value)
                    {
                        yield return audioSource;
                    }
                }
            }
            else if (audioId2playingBGMs.ContainsKey(audioId))
            {
                foreach (var audioSource in audioId2playingBGMs[audioId])
                {
                    yield return audioSource;
                }
            }
        }

        private IEnumerable<AudioSource> GetPlayingSEs(string audioId = null)
        {
            if (audioId == null)
            {
                foreach (var pair in audioId2playingSEs)
                {
                    foreach (var audioSource in pair.Value)
                    {
                        yield return audioSource;
                    }
                }
            }
            else if (audioId2playingSEs.ContainsKey(audioId))
            {
                foreach (var audioSource in audioId2playingSEs[audioId])
                {
                    yield return audioSource;
                }
            }
        }

        private IEnumerator StopAudioSourceCoroutine(string name, AudioSource audioSource)
        {
            name2fadesOut[name] = true;

            do
            {
                yield return new WaitForSeconds(.2f);
            } while (audioSource.isPlaying && name2fadesOut.ContainsKey(name));

            if (name2fadesOut.ContainsKey(name))
            {
                ReleaseAudioSource(name, audioSource);
            }
        }

        private void ReleaseAudioSource(string name, AudioSource audioSource)
        {
            string audioId = name2audio[name].AudioId;
            if (audioId2playingBGMs.ContainsKey(audioId))
            {
                audioId2playingBGMs[audioId].Remove(audioSource);
            }
            if (audioId2playingSEs.ContainsKey(audioId))
            {
                audioId2playingSEs[audioId].Remove(audioSource);
            }

            name2fadesOut.Remove(name);
            name2playingLoopableAudioSource.Remove(name);
            name2playingAudioSource.Remove(name);
            name2audio.Remove(name);

            ReleaseAudioSource(audioSource);
        }

#if UNITY_EDITOR
        public void ReleaseAudioSource(AudioSource audioSource)
#else
        private void ReleaseAudioSource(AudioSource audioSource)
#endif
        {
            var gameObject = audioSource.gameObject;
            if (audioSourcePool.Count < AUDIO_SOURCE_POOL_SIZE)
            {
                gameObject.SetActive(false);
                audioSourcePool.Enqueue(gameObject);
            }
            else
            {
#if UNITY_EDITOR
                DestroyImmediate(gameObject);
#else
                Destroy(gameObject);
#endif
            }
        }

        public void Stop(string name, float fadeOutTime = 0)
        {
            if (name2playingAudioSource.ContainsKey(name))
            {
                var audioSource = name2playingAudioSource[name];
                var audio = name2audio[name];

                name2fadesOut.Remove(name);

                if (fadeOutTime > 0)
                {
                    audio.FadeOut(this, audioSource, fadeOutTime);
                    StartCoroutine(StopAudioSourceCoroutine(name, audioSource));
                }
                else
                {
                    audio.Stop(this, audioSource);
                    ReleaseAudioSource(name, audioSource);
                }
            }
        }

        public void StopBGM(string audioId = null)
        {
            foreach (var audioSource in GetPlayingBGMs(audioId).ToList())
            {
                Stop(audioSource.name);
            }
        }

        public void StopSE(string audioId = null)
        {
            foreach (var audioSource in GetPlayingSEs(audioId).ToList())
            {
                Stop(audioSource.name);
            }
        }

        public void FadeOutBGM(string audioId = null, float fadeOutTime = 2)
        {
            if (fadeOutTime <= 0)
            {
                StopBGM(audioId);
                return;
            }

            foreach (var audioSource in GetPlayingBGMs(audioId))
            {
                Stop(audioSource.name, fadeOutTime);
            }
        }

        public void FadeOutSE(string audioId = null, float fadeOutTime = 2)
        {
            if (fadeOutTime <= 0)
            {
                StopSE(audioId);
                return;
            }

            foreach (var audioSource in GetPlayingSEs(audioId))
            {
                Stop(audioSource.name, fadeOutTime);
            }
        }

        public string CrossBGM(string audioId, AudioSource baseBGMSource = null)
        {
            return CrossFadeBGM(audioId, 0, 0, 0, baseBGMSource);
        }

        public string CrossSE(string audioId, AudioSource baseSESource = null)
        {
            return CrossFadeSE(audioId, 0, 0, 0, baseSESource);
        }

        public string CrossFadeBGM(string audioId, float fadeInTime = 2, float fadeInDelay = 1, float fadeOutTime = 2, AudioSource baseBGMSource = null)
        {
            if (audioId2playingBGMs.ContainsKey(audioId) && audioId2playingBGMs[audioId].Count > 0)
            {
                return FadeInBGM(audioId, fadeInTime, fadeInDelay, PlayMode.StopFadingOutSame, baseBGMSource);
            }
            else
            {
                foreach (var audioSource in GetPlayingBGMs().ToList())
                {
                    Stop(audioSource.name, fadeOutTime);
                }
                return FadeInBGM(audioId, fadeInTime, fadeInDelay, PlayMode.DuplicateSame, baseBGMSource);
            }
        }

        public string CrossFadeSE(string audioId, float fadeInTime = 2, float fadeInDelay = 1, float fadeOutTime = 2, AudioSource baseSESource = null)
        {
            if (audioId2playingSEs.ContainsKey(audioId) && audioId2playingSEs[audioId].Count > 0)
            {
                return FadeInSE(audioId, fadeInTime, fadeInDelay, PlayMode.StopFadingOutSame, baseSESource);
            }
            else
            {
                foreach (var audioSource in GetPlayingSEs().ToList())
                {
                    Stop(audioSource.name, fadeOutTime);
                }
                return FadeInSE(audioId, fadeInTime, fadeInDelay, PlayMode.DuplicateSame, baseSESource);
            }
        }

        public void Pause(string name)
        {
            if (name2playingAudioSource.ContainsKey(name))
            {
                name2playingAudioSource[name].Pause();
            }
        }

        public void PauseBGM(string audioId = null)
        {
            foreach (var audioSource in GetPlayingBGMs(audioId))
            {
                audioSource.Pause();
            }
        }

        public void PauseSE(string audioId = null, float fadeOutTime = 0)
        {
            foreach (var audioSource in GetPlayingSEs(audioId))
            {
                audioSource.Pause();
            }
        }

        public void UnPause(string name)
        {
            if (name2playingAudioSource.ContainsKey(name))
            {
                name2playingAudioSource[name].UnPause();
            }
        }

        public void UnPauseBGM(string audioId = null)
        {
            foreach (var audioSource in GetPlayingBGMs(audioId))
            {
                audioSource.UnPause();
            }
        }

        public void UnPauseSE(string audioId = null)
        {
            foreach (var audioSource in GetPlayingSEs(audioId))
            {
                audioSource.UnPause();
            }
        }

#if UNITY_EDITOR
        [MenuItem("GameObject/Audio/Create Audio Manager Set", false, -100)]
        public static void CreateAudioManagerSet()
        {
            Undo.IncrementCurrentGroup();

            var container = new GameObject("Audio");
            var parent = Selection.activeGameObject;
            if (parent != null)
            {
                container.transform.SetParent(parent.transform);
            }

            var child = new GameObject("BaseBGMSource");
            child.transform.SetParent(container.transform);
            var baseBGMSource = child.AddComponent<AudioSource>();
            baseBGMSource.playOnAwake = false;
            baseBGMSource.loop = true;

            child = new GameObject("BaseSESource");
            child.transform.SetParent(container.transform);
            var baseSESource = child.AddComponent<AudioSource>();
            baseSESource.playOnAwake = false;

            child = new GameObject("AudioManager");
            child.transform.SetParent(container.transform);
            var audioManager = child.AddComponent<AudioManager>();
            child.transform.SetSiblingIndex(0);

            Undo.RegisterCreatedObjectUndo(container, "Create Audio Manager Set");

            audioManager.AudioManagerEditorWindow = ScriptableObject.CreateInstance<Audio.AudioManagerEditorWindow>();
            audioManager.AudioManagerEditorWindow.titleContent = new GUIContent("AudioManager");
            audioManager.AudioManagerEditorWindow.Show();
            audioManager.AudioManagerEditorWindow.ShowTab();
        }

        [CustomEditor(typeof(AudioManager))]
        public class AudioManagerEditor : Editor
        {
            private void OnEnable()
            {
                var audioManager = target as AudioManager;
                audioManager.Awake();
            }

            public override void OnInspectorGUI()
            {
                if (GUILayout.Button("Open AudioManager Window"))
                {
                    Open();
                }
            }

            public static void Open()
            {
                EditorWindow window;
                var audioManager = Instance;
                if (audioManager.AudioManagerEditorWindow == null)
                {
                    window = audioManager.AudioManagerEditorWindow = CreateInstance<Audio.AudioManagerEditorWindow>();
                    window.titleContent = new GUIContent("AudioManager");
                    window.minSize = new Vector2(270, 200);
                }

                window = EditorWindow.GetWindow<Audio.AudioManagerEditorWindow>("AudioManager", true, typeof(SceneView));
                window.Show();
                window.ShowTab();
            }
        }
#endif
    }
}


