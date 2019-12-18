using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HighscoreTable : MonoBehaviour
{
  private Transform entryContainer;
  private Transform entryTemplate;
  private List<HighscoreEntry> highscoreEntryList;
  private List<Transform> highscoreEntryTransformList;

  private void Awake()
  {
    Highscores highscores;

    entryContainer = transform.Find("HighscoreEntryContainer");
    entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

    entryTemplate.gameObject.SetActive(false);

    if(PlayerPrefs.GetInt("TableInitialized") == 0){
      Debug.Log("Initializing");
      for (int i = 0; i < 10; i++){
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, entryContainer);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0,- templateHeight -30f *i);
        entryTransform.gameObject.SetActive(true);

        int rank = i + 1;
        string rankString;
        switch (rank)
        {
          default: rankString = rank + "TH"; break;
          case 1: rankString = "1ST"; break;
          case 2: rankString = "2ND"; break;
          case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("PosText").GetComponent<Text>().text = rankString;

        int score = i;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();

        string name = "AAA";
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

      }
    highscoreEntryList = new List<HighscoreEntry>(){
      new HighscoreEntry{score = 1, name = "AAA"},
      new HighscoreEntry{score = 2, name = "AAA"},
      new HighscoreEntry{score = 3, name = "AAA"},
      new HighscoreEntry{score = 4, name = "AAA"},
      new HighscoreEntry{score = 10, name = "AAA"},
      new HighscoreEntry{score = 6, name = "AAA"},
      new HighscoreEntry{score = 7, name = "AAA"},
      new HighscoreEntry{score = 8, name = "AAA"},
      new HighscoreEntry{score = 9, name = "AAA"},
      new HighscoreEntry{score = 5, name = "BBB"},
    };

    highscores = new Highscores {highscoreEntryList = highscoreEntryList};
    string json = JsonUtility.ToJson(highscores);
    PlayerPrefs.SetString("highscoreTable" , json);
    PlayerPrefs.Save();
    Debug.Log(PlayerPrefs.GetString("highscoreTable"));

    PlayerPrefs.SetInt("TableInitialized", 1);

  }
    /*string jsonString = PlayerPrefs.GetString("highscoreTable");
    highscores = JsonUtility.FromJson<Highscores>(jsonString);
    */
    //AddHighscoreEntry(10000, "MMM");
    highscores = SortHighScores();
    highscoreEntryList = highscores.highscoreEntryList;

    highscoreEntryTransformList = new List<Transform>();
    foreach (HighscoreEntry highscoreEntry in highscoreEntryList){
      CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
    }
  }

  private Highscores SortHighScores()
  {
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
    //Debug.Log("Size of list : " + highscores.highscoreEntryList.Count);
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
    float templateHeight = 30f;
    Transform entryTransform = Instantiate(entryTemplate, container);
    RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
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

  private class Highscores
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

  public void AddHighscoreEntry(int thisScore, string thisName)
  {
    //Create highscore entry
    //Set new score & name
    thisName = thisName.ToUpper();
    HighscoreEntry highscoreEntry = new HighscoreEntry { score = thisScore, name = thisName };
    Debug.Log("Name for scoreboard is : " + thisName);
    //Get saved highscore table
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    //Add new entry
    Debug.Log("HighScoreEntry : " + highscoreEntry + " highscores : " + highscores + "jsonString : " + jsonString);

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
    PlayerPrefs.SetString("highscoreTable", json);
    PlayerPrefs.Save();
  }

  public int getLowestScore()
  {
    string jsonString = PlayerPrefs.GetString("highscoreTable");
    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

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

  public void ToMenu(){
    SceneManager.LoadScene("Menu");
  }
}
