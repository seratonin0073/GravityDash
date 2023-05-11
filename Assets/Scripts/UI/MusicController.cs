using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Slider Volume;
    [SerializeField] private AudioMixer AudioMixer;
    [SerializeField] private AudioClip[] Audio;
    private AudioSource Source;
    private int audioNumber;
    // Start is called before the first frame update
    void Start()
    {
        Volume.value = PlayerPrefs.GetFloat("Volume");
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

    public void VolumeChanger()
    {
        AudioMixer.SetFloat("Volume", Volume.value);
        PlayerPrefs.SetFloat("Volume", Volume.value);
    }
}
