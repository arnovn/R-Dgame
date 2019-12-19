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
    private InputName InputName;
    //public TextMeshProUGUI title;
    //public TextMeshProUGUI menu;
    //public TextMeshProUGUI replay;

    private int score = PlayerPrefs.GetInt("BestScore");
    private int lowestScore;
    private string PlayerName;

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
        InputName = GetComponent<InputName>();
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
            //Debug.Log("nameText : " + nameValueText.text);
            PlayerName = GetPlayerName();
            highscores.AddHighscoreEntry(PlayerPrefs.GetInt("BestScore"), PlayerName);
        }
        SceneManager.LoadScene("Scoreboard");
    }

    private void resetView()
    {
        NewHighScore.SetActive(false);
        NoNewHighScore.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Replay()
    {
            SceneManager.LoadScene("Splitscreen2");
    }

    string GetPlayerName()
    {
        Debug.Log(InputName.GetNameSet());
        if (InputName.GetNameSet()) { return nameValueText.text; }
        else
        {
            return InputName.GetFinalNameString();
        }
    }
}
