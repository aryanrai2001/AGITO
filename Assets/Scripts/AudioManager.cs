using System;
using UnityEngine;

[Serializable]
public class AudioAsset
{
    public string audioName;
    public AudioClip clip;
}

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public void Init()
    {
        audioSource = GameManager.instance.GetComponent<AudioSource>();
    }

    public void Play(string audioName)
    {
        AudioClip clip = null;
        foreach (AudioAsset audioAsset in GameManager.assets.audioAssets)
        {
            if (audioAsset.audioName == audioName)
            {
                clip = audioAsset.clip;
            }
        }
        if (clip == null)
        {
            Debug.LogError("Audio Clip Not Found!");
        }
        else
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
