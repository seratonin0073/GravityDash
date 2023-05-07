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
        pausaObj.SetActive(false);
        Time.timeScale = 1;
    }
    public void Dead()
    {
        scoreScript.UpdateScore(scoreScript.Score *-1);
        bestScoreText.text = $"{PlayerPrefs.GetInt("Best")}";
        StartCoroutine(LoadLevel());
        
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
