using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip Hit;
    public AudioClip Food;
    public AudioClip Dead;

    private AudioSource source;
    private AudioSource hitSourse;

    private float soundVolume = 0.75f; 
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        hitSourse = gameObject.AddComponent<AudioSource>();
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
