using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public string GameName;

    private Text gameNameText;
    private Text bestScoreText;
    private ScoreScript scoreScript;

    private GameObject pausaObj;

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
        gameNameText = GameObject.Find("GameName").GetComponent<Text>();
        bestScoreText = GameObject.Find("BSValue").GetComponent<Text>();
        pausaObj = GameObject.Find("StartPanel");

        if(GameName != null)
        {
            gameNameText.text = GameName;
        }
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
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else Time.timeScale = 0;
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
}

enum Level
{
    Easy,
    Medium,
    Hard
}