using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Endscene : MonoBehaviour
{
    private HighscoreTable highscores;
    public TextMeshProUGUI newHighscoreText;
    public TextMeshProUGUI newHighscoreValueText;
    public TextMeshProUGUI highscoreButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI nameValueText;

    public TextMeshProUGUI title;
    public TextMeshProUGUI menu;
    public TextMeshProUGUI replay;

    private int score = PlayerPrefs.GetInt("BestScore");
    private int lowestScore;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("1ste debug");
        highscores = GetComponent<HighscoreTable>();
        Debug.Log("2de debug");
        lowestScore = highscores.getLowestScore();
        Debug.Log("3de debug");
        Debug.Log("playerprefs : " + PlayerPrefs.GetInt("BestScore"));
        if (PlayerPrefs.GetInt("BestScore") > lowestScore)
        {
            newHighscoreText.gameObject.SetActive(true);
            newHighscoreValueText.gameObject.SetActive(true);
            highscoreButton.gameObject.SetActive(true);
            nameText.gameObject.SetActive(true);
            nameValueText.gameObject.SetActive(true);

            title.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
            replay.gameObject.SetActive(false);

            newHighscoreValueText.text = PlayerPrefs.GetInt("BestScore").ToString();

        }
        else
        {
            newHighscoreText.gameObject.SetActive(false);
            newHighscoreValueText.gameObject.SetActive(false);
            highscoreButton.gameObject.SetActive(false);
            nameText.gameObject.SetActive(false);
            nameValueText.gameObject.SetActive(false);

            title.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            replay.gameObject.SetActive(true);
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
            SceneManager.LoadScene("Scoreboard");
        }

        resetView();
    }

    private void resetView()
    {
        newHighscoreText.gameObject.SetActive(false);
        newHighscoreValueText.gameObject.SetActive(false);
        highscoreButton.gameObject.SetActive(false);
        nameText.gameObject.SetActive(false);
        nameValueText.gameObject.SetActive(false);

        title.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        replay.gameObject.SetActive(true);
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
