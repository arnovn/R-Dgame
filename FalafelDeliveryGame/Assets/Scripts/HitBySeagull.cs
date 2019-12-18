using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBySeagull : MonoBehaviour
{
  public GameObject ddaCollider;
  public GameObject user;

  private Death death;
  private SUserInterface SUI;
  private DdaParams ddaparams;
  private EnemyController enemy;

  private int lives;
  private bool hit;
  // Start is called before the first frame update
  void Start()
  {
    death = ddaCollider.GetComponent<Death>();
    SUI = ddaCollider.GetComponent<SUserInterface>();
    ddaparams = ddaCollider.GetComponent<DdaParams>();
    enemy = user.GetComponent<EnemyController>();
  }

  // Update is called once per frame
  void Update()
  {
    if(hit){
      enemy.Hit(hit);
    }
    try{
      if(enemy.spawnedEnemey == null){
        hit = false;
        enemy.Hit(hit);
      }
    }
    catch(System.Exception){

    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.name.Contains("enemy seagull"))
    {

      if (!hit)
      {
        death.Died();
        lives = death.getLives();
        ddaparams.enemyHitUser();
        FindObjectOfType<AudioManager>().Play("SeagullSound");

        //Debug.Log("You lost one life, lives left: " + lives);
        hit = true;
      }

    }
  }
  private void OnTriggerExit2D(Collider2D collision)
  {

  }

}
