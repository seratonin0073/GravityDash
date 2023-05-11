using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip Hit;
    public AudioClip Food;
    public AudioClip Dead;
    public AudioMixerGroup Mixer;

    private AudioSource source;
    private AudioSource hitSourse;

    private float soundVolume = 0.75f; 
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        hitSourse = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = Mixer;
        hitSourse.outputAudioMixerGroup = Mixer;
        

        source.volume = soundVolume;
        hitSourse.volume = soundVolume;
    }

    public void PlaySound(string soundName)
    {
        switch(soundName)
        {
            case "Hit":
                {
                    hitSourse.clip = Hit;
                    hitSourse.Play();
                    break;
                }
            case "Food":
                {
                    source.clip = Food;
                    source.Play();
                    break;
                }
            case "Dead":
                {
                    Debug.Log("Tray to play Dead");
                    source.clip = Dead;
                    source.Play();
                    break;
                }
        }

    }
}
