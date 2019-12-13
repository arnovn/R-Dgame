using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  TO DO:
 *      - enemy parameters implementeren
 *          - accuracy (amount of shots needed to kill enemy)
 *          - time between enemy spawned & enemy killed
 *          - amount of times dodged
 *      - distance between two players implmentation
 *      - amount of lives
 */

public class DdaParams : MonoBehaviour
{
    //Connection & variables of player
    public GameObject player;
    public GameObject DdaCollider;

    private Rigidbody2D body;
    private playerSkill currentSkill;
    private Death death;
    bool didEnemyHit = false;
    int shots = 0;

    //Platform object for comparison
    private GameObject currentplatform;

    //Definition of different parameters
    private int stationary_hops = 0;        //Amount of hops on same tile
    private int jumpstreak = 0;             //Amount of hops to different tile without stationary in between
    private int amount_of_jumpstreaks = 0;  //amount of "big" jumpstreaks (>7), indication of very skilled player
    private int player_lives;
    private float x_pos;
    private float y_pos;
    private enum playerSkill {UnskilledBoth, UnskilledJump, UnskilledShoot, Skilled, VerySkilled};

    // Start is called before the first frame update
    void Start()
    {
        x_pos = player.transform.position.x;
        y_pos = player.transform.position.y;

        death = DdaCollider.GetComponent<Death>();

        //Standard we start off easy: unskilledboth
        currentSkill = playerSkill.UnskilledBoth;

        player_lives = death.getLives();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int getSkillLevel()
    {
        switch (currentSkill)
        {
            case playerSkill.UnskilledBoth  :
                return 0;
                break;
            case playerSkill.UnskilledJump  :
                return 1;
                break;
            case playerSkill.UnskilledShoot :
                return 2;
                break;
            case playerSkill.Skilled        :
                return 3;
                break;
            case playerSkill.VerySkilled    :
                return 4;
                break;
            default                         :
                return 0;
        }
    }
    public void ReduceSkill()
    {
        switch (currentSkill)
        {
            case playerSkill.VerySkilled:
                currentSkill = playerSkill.Skilled;
                break;
            case playerSkill.Skilled:
                currentSkill = playerSkill.UnskilledShoot;
                break;
            case playerSkill.UnskilledShoot:
                currentSkill = playerSkill.UnskilledJump;
                break;
            case playerSkill.UnskilledJump:
                currentSkill = playerSkill.UnskilledBoth;
                break;
        }
    }

    private void CheckSkill()
    {
        //TO DO: include enemy params into skull checking
        if (jumpstreak <= 10 && stationary_hops >= 2)
        {
            if (didEnemyHit == true || shots > 2)
            {
                currentSkill = playerSkill.UnskilledBoth;
                //Debug.Log("Skill level set: unskilled both");
            }
            else
            {
                currentSkill = playerSkill.UnskilledJump;
                //Debug.Log("Skill level set: unskilled jump");
            }
        }
        else if (jumpstreak > 10 && jumpstreak <= 20 && stationary_hops >= 2)
        {
            if (didEnemyHit == true || shots > 0)
            {
                currentSkill = playerSkill.UnskilledShoot;
              //  Debug.Log("Skill level set: unskilled enemy");
            }
        }
        else if (jumpstreak > 10 && jumpstreak <= 20 && stationary_hops < 2 && didEnemyHit == false)
        {
            currentSkill = playerSkill.Skilled;
            //Debug.Log("Skill level set: skilled");
        }
        else if (jumpstreak > 20 && stationary_hops < 3 && amount_of_jumpstreaks >= 1 && didEnemyHit == false && shots < 3)
        {
            currentSkill = playerSkill.VerySkilled;
            //Debug.Log("Skill level set: very skilled");
        }
    }

    public void enemyHitUser()
    {
        didEnemyHit = true;
    }

    public void playerShot()
    {
        shots++;
    }

    private void checkStationary(Collider2D collision)
    {

        if (collision.gameObject.name.StartsWith("Platform"))
        {
            body = player.GetComponent<Rigidbody2D>();
            if (body.velocity.y <= 0)
            {
                if (collision.gameObject == currentplatform)
                {
                    stationary_hops++;
                    jumpstreak = 0;
                }
                else
                {
                    stationary_hops = 0;
                    jumpstreak++;
                    currentplatform = collision.gameObject;
                }
            }
        }
    }

    private void ResetParams()
    {
        //Resets amount of jumpstreaks and stationary hops (due to player dieing).
        jumpstreak = 0;
        stationary_hops = 0;
    }

    private bool CheckLives()
    {
      int lives = death.getLives();
        if (player_lives < lives)
        {
            ResetParams();
            player_lives = lives;
            return true;
        }
        else if (player_lives > lives)
        {
            player_lives = lives;
            return false;
        }
        return false;
    }

    public void Died()
    {
        ResetParams();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("amount of shots: " + shots);
        checkStationary(collision);
        if (jumpstreak == 7)
        {
            amount_of_jumpstreaks++;
            //Debug.Log("Amount_of_jumpstreaks of jumpstreak increased: " + amount_of_jumpstreaks);
        }
        CheckSkill();

    }

    public void newEnemy()
    {
        didEnemyHit = false;
        shots = 0;
    }
}
