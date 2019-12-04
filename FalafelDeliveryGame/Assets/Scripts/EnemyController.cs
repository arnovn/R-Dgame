using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnedEnemey;
    public GameObject thisCanvas;
    public GameObject user;
    private int freqOfEnemy;
    private int difficulty = 50;
    private int leftOrRight;
    private float xSpawn;
    private float ySpawn;
    private float speedEnemy = 0.08f;
    private bool followUser = false;
    public enum direction {LEFT, RIGHT }
    private direction directionEnemy;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnedEnemey == null) {
            freqOfEnemy = Random.Range(1, 10000);
           // Debug.Log("Freq : " + freqOfEnemy);
            if (freqOfEnemy <= difficulty)
            {
                GenerateEnemy();
                Debug.Log("Enemy spawned");
                Debug.Log("Position: " + spawnedEnemey.transform.position.x);
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

       if (spawnedEnemey.transform.position.y < user.transform.position.y)
        {
            followUser = true;
        }
        if (followUser)
        {
            spawnedEnemey.transform.position = new Vector2(newX, user.transform.position.y);
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

    
}
 