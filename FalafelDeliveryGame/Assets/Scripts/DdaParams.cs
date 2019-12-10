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
    private int player_lives;
    private Rigidbody2D body;
    private float x_pos;
    private float y_pos;
    private enum playerSkill {UnskilledBoth, UnskilledJump, UnskilledShoot, Skilled, VerySkilled};
    playerSkill currentSkill;
    private Death death1;
    private Death death2;

    //Platform object for comparison
    private GameObject currentplatform;

    //Definition of different parameters
    private int stationary_hops = 0;        //Amount of hops on same tile
    private int jumpstreak = 0;             //Amount of hops to different tile without stationary in between
    private int amount_of_jumpstreaks = 0;  //amount of "big" jumpstreaks (>7), indication of very skilled player

    // Start is called before the first frame update
    void Start()
    {
        x_pos = player.transform.position.x;
        y_pos = player.transform.position.y;

        death1 = GameObject.Find("DdaCollider1").GetComponent<Death>();
        death2 = GameObject.Find("DdaCollider2").GetComponent<Death>();
        //Standard we start off easy: unskilledboth
        currentSkill = playerSkill.UnskilledBoth;

        player_lives = death1.getLifes();
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
        if (jumpstreak <= 10 && stationary_hops >= 3)
        {
            currentSkill = playerSkill.UnskilledJump;
            Debug.Log("Skill level set: unskilled both");
        }
        else if (jumpstreak > 10 && jumpstreak <= 20 && stationary_hops >= 3)
        {
            currentSkill = playerSkill.UnskilledShoot;
            Debug.Log("Skill level set: unskilled enemy");
        }
        else if (jumpstreak > 10 && jumpstreak <= 20 && stationary_hops < 3)
        {
            currentSkill = playerSkill.Skilled;
            Debug.Log("Skill level set: skilled");
        }
        else if (jumpstreak > 20 && stationary_hops < 3 && amount_of_jumpstreaks >= 1)
        {
            currentSkill = playerSkill.VerySkilled;
            Debug.Log("Skill level set: very skilled");
        }
    }

    private void checkStationary(Collider2D collision)
    {

        if (collision.gameObject.name.StartsWith("Platform") || collision.gameObject.name.StartsWith("Big"))
        {
            body = player.GetComponent<Rigidbody2D>();
            if (body.velocity.y <= 0)
            {
                if (collision.gameObject == currentplatform)
                {
                    stationary_hops++;
                    jumpstreak = 0;
                    Debug.Log("Stationary hops: " + stationary_hops);
                    Debug.Log("Jumpstreak: " + jumpstreak);
                }
                else
                {
                    stationary_hops = 0;
                    jumpstreak++;
                    currentplatform = collision.gameObject;
                    Debug.Log("Stationary hops: " + stationary_hops);
                    Debug.Log("Jumpstreak: " + jumpstreak);
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
        if (player_lives < death1.getLifes())
        {
            ResetParams();
            player_lives = death1.getLifes();
            return true;
        }
        else if (player_lives > death1.getLifes())
        {
            player_lives = death1.getLifes();
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
        Debug.Log("Test");
        checkStationary(collision);
        if (jumpstreak == 7)
        {
            amount_of_jumpstreaks++;
            Debug.Log("Amount_of_jumpstreaks of jumpstreak increased: " + amount_of_jumpstreaks);
        }
        CheckSkill();

    }
}
