using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePlatformPrefab;
    public GameObject IcePlatformPrefab;
    private GameObject myPlat;
    private Death death;
    private Bounce platform;
    private BigBounce bigBounce;
    private float range = 22f;
    private float extra = 1f;
    private float generation_axis;
    private int index;
    private bool generating;
    private float[] coords = new float[2];
    private float[] tilesXPositions = new float[] {-4f,3.7f,-3f,3.2f,-2.4f,2.93f,-2.19f,4.26f,-4.71f,0.05f};
    private float[] tilesYPositions = new float[] {41f,36.8f,30.6f,23.9f,16.6f,10.81f,5.84f,0.67f,-3.02f,-8.07f};

    //MAX AFSTAND TUSSEN TILES IS 8.82F!!!!!!!!!
    // Start is called before the first frame update
    void Start()
    {
        generation_axis = player.transform.position.x;
        death = GameObject.Find("DdaCollider").GetComponent<Death>();
        generating = true;
    }
    // Update is called once per frame
    void Update()
    {

    }

    /* Function will check when platform hits platfrom destroyer box collider
     * When it does, it will check which platform has been hit
     * Depending on which one it will replace an existing plaform or create a new one of another type and destroy the other platform.
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(generating){
          GenerateNewPlatform(collision);
        }
    }

    private void updateTileArray(float x_pos, float y_pos){
        for(int i = 9; i>0; i--){

            tilesXPositions[i] = tilesXPositions[i-1];
            tilesYPositions[i] = tilesYPositions[i-1];
          }
        //Debug.Log("Shifted");
        tilesXPositions[0] = x_pos;
        tilesYPositions[0] = y_pos;
    }

    public int getLowestTile(){
      int lowestIndex = 0;
      for(int i = 1; i<10; i++){

        float lowest = tilesYPositions[0];
          Debug.Log(tilesYPositions[i]);
        if(tilesYPositions[i]< lowest && tilesYPositions[i] != 0f){
          Debug.Log("YES");
          lowest = tilesYPositions[i];
          lowestIndex = i;
        }
      }
      Debug.Log("STOP");
      return lowestIndex;
    }

    public void StopGenerating(){
      generating = false;
    }


    private void GenerateNewPlatform(Collider2D collision)
    {

        index = getLowestTile();
        Debug.Log("index : " + index);
          //Debug.Log(tilesXPositions[0]);
          //Debug.Log(tilesYPositions[0]);

        float y_pos = tilesYPositions[0] + 8.82f;
        float x_pos = Random.Range(-5.5f,5.5f);
        //When we collide with normal platform:
        if (collision.gameObject.name.StartsWith("Platform"))
        {

            //1 in 7 we will generate 'bigjump' platform
            int random = Random.Range(1,14);
            if (random == 1)

            {
                Destroy(collision.gameObject);
                tilesXPositions[index] =0f;
                tilesYPositions[index] =0f;
                Instantiate(bigBouncePlatformPrefab, new Vector2(generation_axis + x_pos, y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);

            }
            else if (random == 2){
              Destroy(collision.gameObject);
              tilesXPositions[index] =0f;
              tilesYPositions[index] =0f;
              Instantiate(bigBouncePlatformPrefab, new Vector2(generation_axis + x_pos,  y_pos/*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);
              Instantiate(IcePlatformPrefab, new Vector2(generation_axis + Random.Range(-5.5f, 5.5f),  y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);

            }else
            {
                collision.gameObject.transform.position = new Vector2(generation_axis + x_pos, y_pos/* + Random.Range(extra - 0.5f, extra)*/);
                tilesXPositions[index] =0f;
                tilesYPositions[index] =0f;
            }

        }
        //When we collide with bigjump platform
        else if (collision.gameObject.name.StartsWith("BigJump"))
        {
            //1 in 7 we will replace this bigjump platform, 6 in 7 generate new normal platform.
            if (Random.Range(1, 7) == 1)
            {
              tilesXPositions[index] =0f;
              tilesYPositions[index] =0f;
                collision.gameObject.transform.position = new Vector2(generation_axis + x_pos,  y_pos /*+ Random.Range(extra - 0.5f, extra)*/);
            }
            else
            {
                Destroy(collision.gameObject);
                tilesXPositions[index] =0f;
                tilesYPositions[index] =0f;
                Instantiate(platformPrefab, new Vector2(generation_axis + x_pos,  y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);
            }


        }
        if(collision.gameObject.name.StartsWith("Platform") || collision.gameObject.name.StartsWith("Big")){
          updateTileArray(x_pos,y_pos);
          death.lastPlatformPosition(tilesXPositions[index], tilesYPositions[index]);
        }


    }
}
