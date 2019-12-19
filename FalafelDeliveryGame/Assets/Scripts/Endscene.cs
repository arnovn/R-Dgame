using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Endscene : MonoBehaviour
{
    private HighscoreTable highscores;
    public TextMeshProUGUI newHighscoreValueText;
    public TextMeshProUGUI nameValueText;

    public GameObject NewHighScore;
    public GameObject NoNewHighScore;

    private int score = PlayerPrefs.GetInt("BestScore");
    private int lowestScore;

    // Start is called before the first frame update
    void Awake()
    {
        highscores = GetComponent<HighscoreTable>();
        lowestScore = highscores.getLowestScore();
        if (PlayerPrefs.GetInt("BestScore") > lowestScore)
        {
            NoNewHighScore.SetActive(false);
            NewHighScore.SetActive(true);
            newHighscoreValueText.text = PlayerPrefs.GetInt("BestScore").ToString();

        }
        else
        {
            NewHighScore.SetActive(false);
            NoNewHighScore.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lowestScore = highscores.getLowestScore();
    }

    public void addScore()
    {
          if (PlayerPrefs.GetInt("BestScore") > lowestScore)
        {
            Debug.Log("nameText : " + nameValueText.text);
            highscores.AddHighscoreEntry(PlayerPrefs.GetInt("BestScore"), nameValueText.text);
        }
        SceneManager.LoadScene("Scoreboard");
        resetView();
    }

    private void resetView()
    {
        NewHighScore.SetActive(true);
        NoNewHighScore.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Replay()
    {
            SceneManager.LoadScene("Splitscreen2");
    }

}
