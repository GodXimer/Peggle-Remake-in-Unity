using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

static public class SoundManager
{
    static public AudioSource AudioSource { get; private set; }
    static private AudioClip[] hitClips;
    static private AudioClip[] holeClips;

    static public void Init(AudioSource audioSource)
    {
        AudioSource = audioSource;
        hitClips = Resources.LoadAll<AudioClip>($"Audio/SFX/Hit");
        holeClips = Resources.LoadAll<AudioClip>($"Audio/SFX/Hole");

    }

    static public void Play(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
    }

    static public void PlayRandomHit()
    {
        Play(hitClips[Random.Range(0, hitClips.Length)]);
    }

    static public void PlayRandomHole()
    {
        Play(holeClips[Random.Range(0, holeClips.Length)]);
    }
}
