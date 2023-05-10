using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public ToggleGroup Levels;
    private Toggle ActiveToggle;

    private void Start()
    {
        foreach(Toggle toggle in Levels.GetComponentsInChildren<Toggle>())
        {
            toggle.onValueChanged.AddListener(OnToggleChanged);
        }
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            ActiveToggle = Levels.GetFirstActiveToggle();
            Debug.Log(ActiveToggle.name);
            if (ActiveToggle.name == "Easy") SaveVar.level = Level.Easy;
            else if(ActiveToggle.name == "Medium") SaveVar.level = Level.Medium;
            else if(ActiveToggle.name == "Hard") SaveVar.level = Level.Hard;
            
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }


}
