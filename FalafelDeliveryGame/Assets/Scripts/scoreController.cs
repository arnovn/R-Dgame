using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreController : MonoBehaviour
{
    public GameObject user1;
    public GameObject user2;
    public GameObject DdaCollider1;
    public GameObject DdaCollider2;
    public GameObject fireworkPrefab;
    public GameObject PfDestroyer1;
    public GameObject PfDestroyer2;

    private GameObject firework;
    private Finish f1;
    private Finish f2;
    private Timer t1;
    private Timer t2;
    private Death d1;
    private Death d2;
    private float time1;
    private float time2;
    private float lives1;
    private float lives2;
    private float score1;
    private float score2;
    private bool scoreFound;
    private TileGenerator tg;
    private float x_pos;

    // Start is called before the first frame update
    void Start()
    {
        f1 = user1.GetComponent<Finish>();
        f2 = user2.GetComponent<Finish>();
        t1 = user1.GetComponent<Timer>();
        t2 = user2.GetComponent<Timer>();
        d1 = DdaCollider1.GetComponent<Death>();
        d2 = DdaCollider2.GetComponent<Death>();
        scoreFound = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("user1: " + f1.GetIsFinished() + "  user 2:  " + f2.GetIsFinished());
        if (f1.GetIsFinished() && f2.GetIsFinished() && !scoreFound) {
            time1 = t1.GetTime();
            time2 = t2.GetTime();
            lives1 = d1.getLives();
            lives2 = d2.getLives();
            score1 = time1 - 10 * lives1;
            score2 = time2 - 10 * lives2;

            WinnerCheck();


            scoreFound = true;
        }
    }

    void WinnerCheck() {
        GameObject winner;
        float scoreWinner;
        float timeWinner;
        float livesWinner;

        if (score1 < score2) {
            winner = user1; scoreWinner = score1;timeWinner = time1;livesWinner = lives1;
            tg = PfDestroyer1.GetComponent<TileGenerator>();
            x_pos = user1.GetComponent<Rigidbody2D>().position.x;
        }
        else if(score1 > score2) {
            winner = user2; scoreWinner = score2; timeWinner = time2; livesWinner = lives2;
            tg = PfDestroyer2.GetComponent<TileGenerator>();
            x_pos = user2.GetComponent<Rigidbody2D>().position.x;
        }

        firework = Instantiate(fireworkPrefab, new Vector2(x_pos, tg.getHighestTilePosition() + 5f), Quaternion.identity);
        firework.transform.eulerAngles = new Vector3(-90, 0, 0);


    }
}
