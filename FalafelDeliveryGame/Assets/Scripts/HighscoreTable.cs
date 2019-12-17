using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(200, "CCC");

        HighScores highscores = SortHighScores();

        highscoreEntryTransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

    }


    private HighScores SortHighScores()
    {
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        return highscores;
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        float templateHeight = 30f;
        entryRectTransform.anchoredPosition = new Vector2(0,- templateHeight -30f *  transformList.Count+1);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count +1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        int score = highScoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = highScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        //color background light red each two entries
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        if (rank == 1)
        {
            //Set first ranked green
            entryTransform.Find("NameText").GetComponent<Text>().color = Color.yellow;
            entryTransform.Find("ScoreText").GetComponent<Text>().color = Color.yellow;
            entryTransform.Find("PosText").GetComponent<Text>().color = Color.yellow;
        }

        switch (rank)
        {
            default:
                entryTransform.Find("falafel").gameObject.SetActive(false); break;
            case 1:
                entryTransform.Find("falafel").GetComponent<Image>().color = Color.yellow;
                break;
            case 2:
                entryTransform.Find("falafel").GetComponent<Image>().color = Color.gray;
                break;
            case 3:
                entryTransform.Find("falafel").GetComponent<Image>().color = Color.red;
                break;


        }

        transformList.Add(entryTransform);
    }

    private class HighScores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    //Represent single highscore entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

    public void AddHighscoreEntry(int score, string name)
    {
        //Create highscore entry
        //Set new score & name
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //Get saved highscore table
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        //Add new entry
        highscores.highscoreEntryList.Add(highscoreEntry);

        SortHighScores();

        
        if (highscores.highscoreEntryList.Count>=10)
        {
            Debug.Log("Entry list size: " + highscores.highscoreEntryList.Count);
            for (int i = highscores.highscoreEntryList.Count; i > 10; i--)
            {
                Debug.Log("Entry list size: " + highscores.highscoreEntryList.Count);
                highscores.highscoreEntryList.RemoveAt(0);
            }
        }
        //Save the new table
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    public int getLowestScore()
    {
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highscores = JsonUtility.FromJson<HighScores>(jsonString);

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    //Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        return highscores.highscoreEntryList[9].score;
    }
}
