using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public bool mute;
    public Sound[] sounds;

    private void Awake()
    {
        if (mute)
        {
            Debug.Log("Game is muted!");
            return;
        }
        foreach (Sound snd in sounds)
        {
            snd.source = gameObject.AddComponent<AudioSource>();
            snd.source.clip = snd.clip;

            snd.source.volume = snd.volume;
            snd.source.pitch = snd.pitch;
            snd.source.loop = snd.loop;
        }
    }

    public void Play(string name)
    {
        if (mute)
        {
            return;
        }
        Sound snd = Array.Find(sounds, sound => sound.name == name);
        if (snd == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        snd.source.Play();
    }

}
