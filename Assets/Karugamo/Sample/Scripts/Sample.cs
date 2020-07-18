using UnityEngine;
using Karugamo.Audio;

public class Sample : MonoBehaviour
{
    public void PlaySample1()
    {
        StopBGM();
        AudioManager.Instance.PlayBGM("sample1");
        //AudioManager.Instance.FadeInBGM("sample1");
    }

    public void PlaySample2()
    {
        StopBGM();
        AudioManager.Instance.PlayBGM("sample2");
        //AudioManager.Instance.FadeInBGM("sample2");
    }

    public void CrossSample1()
    {
        AudioManager.Instance.CrossBGM("sample1");
    }

    public void CrossSample2()
    {
        AudioManager.Instance.CrossBGM("sample2");
    }

    public void CrossFadeSample1()
    {
        AudioManager.Instance.CrossFadeBGM("sample1");
    }

    public void CrossFadeSample2()
    {
        AudioManager.Instance.CrossFadeBGM("sample2");
    }

    public void StopBGM()
    {
        AudioManager.Instance.StopBGM();
        //AudioManager.Instance.FadeOutBGM();
    }
}


