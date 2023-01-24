using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongsManager : MonoBehaviour
{
    ////[SerializeField] private AudioClip[] songsList;
    //[SerializeField] private AudioClip song;
    //[SerializeField] private static AudioSource staticAudioSource;
    //[SerializeField] private static bool started;

    //void Start()
    //{
    //    //too many loading and lag
    //    //songsList = Resources.LoadAll<AudioClip>($"Audio/Songs");

    //    //audioSource.clip = songsList[Random.Range(0,songsList.Length)];

    //    if (started) return;

    //    audioSource.clip = song;
    //    audioSource.Play();
    //    started = true;

    //    staticAudioSource = audioSource;
    //}

    [SerializeField] private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        PlayMusic();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
