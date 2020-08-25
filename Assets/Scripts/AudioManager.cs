using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private float volume;

    private void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1);
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
        Sound snd = Array.Find(sounds, sound => sound.name == name);
        if (snd == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        snd.source.Play();
    }

    public void ChangeVolume(float cVolume)
    {
        float vol = cVolume / 10;
        Debug.Log("Changing volume to: " + vol);
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("Volume", vol);
    }

}
