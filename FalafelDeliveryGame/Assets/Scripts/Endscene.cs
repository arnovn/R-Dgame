using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Endscene : MonoBehaviour
{
    private HighscoreTable highscores;
    public TextMeshProUGUI newScore;
    public TextMeshProUGUI newHighscoreText;
    public TextMeshProUGUI newHighscoreValueText;
    public TextMeshProUGUI highscoreButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI nameValueText;

    public TextMeshProUGUI title;
    public TextMeshProUGUI menu;
    public TextMeshProUGUI replay;

    private int score;
    private int lowestScore;

    // Start is called before the first frame update
    void Awake()
    {

        highscores = GetComponent<HighscoreTable>();
        lowestScore = highscores.getLowestScore();
        int.TryParse(newScore.text.ToString(), out score);
        if (score > lowestScore)
        {
            newHighscoreText.gameObject.SetActive(true);
            newHighscoreValueText.gameObject.SetActive(true);
            highscoreButton.gameObject.SetActive(true);
            nameText.gameObject.SetActive(true);
            nameValueText.gameObject.SetActive(true);

            title.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
            replay.gameObject.SetActive(false);


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
        score = PlayerPrefs.GetInt("BestScore");
        int.TryParse(newScore.text.ToString(), out score);
        Debug.Log("Score string: " + newScore.text.ToString());
        Debug.Log("Score: " + score);
        if (score > lowestScore)
        {
            highscores.AddHighscoreEntry(score, "MAT");
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
