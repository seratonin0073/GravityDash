using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class UIScript : MonoBehaviour
{

    private Text bestScoreText;
    private ScoreScript scoreScript;

    private GameObject pausaObj;

    public static UnityEvent OnPause = new UnityEvent();
    public static UnityEvent OnResume = new UnityEvent();

    private void Awake()
    {
        GameObject[] SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPosition");
        if(SaveVar.level == Level.Easy)
        {
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                    SpawnPoints[i].SetActive(false);
            }
        }
        else if (SaveVar.level == Level.Hard)
        {
            GameObject.FindObjectOfType<SpawnScript>().SpawnTime = 0.4f;
            GameObject.FindObjectOfType<SpawnScript>().FoodChance = 40;
        }
    }
    void Start()
    {
        scoreScript = GameObject.Find("UIManager").GetComponent<ScoreScript>();
        bestScoreText = GameObject.Find("BSValue").GetComponent<Text>();
        pausaObj = GameObject.Find("StartPanel");

        bestScoreText.text = $"{PlayerPrefs.GetInt("Best")}";
        Time.timeScale = 0;

    }
    public void StartGame()
    {
        scoreScript.UpdateScore(scoreScript.Score * -1);
        pausaObj.SetActive(false);
        Time.timeScale = 1;
    }
    public void Dead()
    {
        SaveVar.score = scoreScript.Score;
        scoreScript.UpdateScore(0);
        bestScoreText.text = $"{PlayerPrefs.GetInt("Best")}";
        StartCoroutine(LoadLevel());
        
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        OnPause.Invoke();
    }
    public void Resume()
    {
        OnResume.Invoke();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

struct SaveVar
{
    public static int score = 0;
    public static Level level = Level.Easy;
    public static int volume = 0;
}

enum Level
{
    Easy,
    Medium,
    Hard
}