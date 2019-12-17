using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject spawnedEnemey;
  public GameObject thisCanvas;
  public GameObject user;
  public GameObject ddaCollider;

  private direction directionEnemy;
  private DdaParams ddaparam;
  private GenerationValues genval;
  private Death death;
  private Finish finish;

  private int freqOfEnemy;
  private int difficulty = 50;
  private int leftOrRight;
  private float xSpawn;
  private float ySpawn;
  private float speedEnemy = 0.08f;
  private bool followUser = false;
  public enum direction {LEFT, RIGHT }
  private bool hit = false;


  // Start is called before the first frame update
  void Start()
  {
    ddaparam = ddaCollider.GetComponent<DdaParams>();
    genval = ddaCollider.GetComponent<GenerationValues>();
    death = ddaCollider.GetComponent<Death>();
    finish = user.GetComponent<Finish>();

  }

  // Update is called once per frame
  void Update()
  {
        //Debug.Log(finish.getFinished());
    if (spawnedEnemey == null && death.getLives() > 0 && !finish.GetIsFinished()) {
      ddaparam.newEnemy();
      speedEnemy = genval.getEnemySpeed();
      freqOfEnemy = Random.Range(1, 10000);
      // Debug.Log("Freq : " + freqOfEnemy);
      if (freqOfEnemy <= difficulty)
      {
        GenerateEnemy();
      }
            if (finish.GetIsFinished())
            {
                Destroy(spawnedEnemey);
            }
    }

    if (spawnedEnemey != null)
    {
      MoveEnemy();
      DirectionChanger();

    }
  }


  private void DirectionChanger()
  {
    switch (directionEnemy)
    {
      case direction.LEFT:
      if (spawnedEnemey.transform.position.x < thisCanvas.transform.position.x - 15)
      {
        directionEnemy = direction.RIGHT;
        FlipEnemy();
      }
      break;
      case direction.RIGHT:
      if (spawnedEnemey.transform.position.x > thisCanvas.transform.position.x + 15)
      {
        directionEnemy = direction.LEFT;
        FlipEnemy();
      }
      break;
    }
  }

  private void MoveEnemy()
  {
    if(hit){
      float newX = 0;
      switch (directionEnemy)
      {
        case direction.LEFT:
        newX = spawnedEnemey.transform.position.x - speedEnemy*2;
        break;
        case direction.RIGHT:
        newX = spawnedEnemey.transform.position.x + speedEnemy*2;
        break;
      }

      spawnedEnemey.transform.position = new Vector2(newX, spawnedEnemey.transform.position.y + speedEnemy*5);
      if(Mathf.Abs(transform.position.y -spawnedEnemey.transform.position.y) > 30f){
        Destroy(spawnedEnemey);
      }
    }

    else{
      float newX = 0;
      switch (directionEnemy)
      {
        case direction.LEFT:
        newX = spawnedEnemey.transform.position.x - speedEnemy;
        break;
        case direction.RIGHT:
        newX = spawnedEnemey.transform.position.x + speedEnemy;
        break;
      }

      if (user.transform.position.y - spawnedEnemey.transform.position.y == 0)
      {
        spawnedEnemey.transform.position = new Vector2(newX, user.transform.position.y);
      }
      else
      {
        if (Vector2.Distance(user.transform.position, spawnedEnemey.transform.position) > 2)
        {



          if (spawnedEnemey.transform.position.x - user.transform.position.x > 0)
          {
            spawnedEnemey.transform.position = Vector2.MoveTowards(spawnedEnemey.transform.position, new Vector2(user.transform.position.x + 4, user.transform.position.y), speedEnemy);

          }
          else
          {
            spawnedEnemey.transform.position = Vector2.MoveTowards(spawnedEnemey.transform.position, new Vector2(user.transform.position.x - 4, user.transform.position.y), speedEnemy);

          }





        }
        else if (Vector2.Distance(user.transform.position, spawnedEnemey.transform.position) <= 2)
        { //spawnedEnemey.transform.position = new Vector2(newX, user.transform.position.y);
          spawnedEnemey.transform.position = Vector2.MoveTowards(spawnedEnemey.transform.position, new Vector2(spawnedEnemey.transform.position.x, user.transform.position.y), speedEnemy);
        }
      }
    }
  }

  private void GenerateEnemy()
  {
    ySpawn = user.transform.position.y + 20;
    leftOrRight = Random.Range(0, 99);
    if (leftOrRight > 49)
    {
      //right
      xSpawn = thisCanvas.transform.position.x + 13;
      directionEnemy = direction.LEFT;
    }
    else if (leftOrRight <= 49)
    {
      //left
      xSpawn = thisCanvas.transform.position.x - 13;
      directionEnemy = direction.RIGHT;
    }


    spawnedEnemey = Instantiate(enemyPrefab, new Vector2(xSpawn, ySpawn), Quaternion.identity);

    if (leftOrRight > 49)
    {
      //flip enemy

      FlipEnemy();
    }

  }

  private void FlipEnemy()
  {
    Vector3 newScale = spawnedEnemey.transform.localScale;
    newScale.x *= -1;
    spawnedEnemey.transform.localScale = newScale;
  }

  public void Hit( bool newHit){
    hit = newHit;
  }
}
