using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip[] Audio;
    private AudioSource Source;
    private int audioNumber;
    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
        if(Audio != null)
        {
            audioNumber = Random.Range(0, Audio.Length);
            Source.clip = Audio[audioNumber];
            Source.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!Source.isPlaying)
        {
            int temp = Random.Range(0, Audio.Length);
            while(temp == audioNumber)
            {
                temp = Random.Range(0, Audio.Length);
            }
            audioNumber = temp;
            Source.clip = Audio[audioNumber];
            Source.Play();
        }
    }
}
