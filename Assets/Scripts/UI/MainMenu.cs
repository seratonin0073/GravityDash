using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Slider Volume;
    public ToggleGroup Levels;
    private Toggle ActiveToggle;
    
    private void Start()
    {
        SaveVar.level = (Level)PlayerPrefs.GetInt("Level");
        Volume.value = PlayerPrefs.GetFloat("Volume");
        Toggle[] tg = Levels.GetComponentsInChildren<Toggle>();
        
        tg[(int)SaveVar.level].isOn = true;
        Debug.Log("Loaded: " + (int)SaveVar.level);
        Debug.Log("Fact: " + tg[(int)SaveVar.level].name);

        foreach (Toggle toggle in tg)
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            ActiveToggle = Levels.GetFirstActiveToggle();
            if (ActiveToggle.name == "Easy") SaveVar.level = Level.Easy;
            else if(ActiveToggle.name == "Medium") SaveVar.level = Level.Medium;
            else if(ActiveToggle.name == "Hard") SaveVar.level = Level.Hard;

            PlayerPrefs.SetInt("Level", (int)SaveVar.level);
            
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void VolumeChanger()
    {
        AudioMixer.SetFloat("Volume", Volume.value);
        PlayerPrefs.SetFloat("Volume", Volume.value);

    }


}
