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
    private Bounce platform;
    private BigBounce bigBounce;
    private float range = 22f;
    private float extra = 1f;
    private float generation_axis;
    private float[] coords = new float[2];
    private float[] tilesXPositions = new float[] {3.2f,-2.4f,2.93f,-2.19f,4.26f,-4.71f,0.05f};
    private float[] tilesYPositions = new float[] {23.9f,16.6f,10.81f,5.84f,0.67f,-3.02f,-8.07f};

    //MAX AFSTAND TUSSEN TILES IS 8.82F!!!!!!!!!
    // Start is called before the first frame update
    void Start()
    {
        generation_axis = player.transform.position.x;
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
        GenerateNewPlatform(collision);

    }

    private void updateTileArray(float x_pos, float y_pos){
        for(int i = 6; i>0; i--){

            tilesXPositions[i] = tilesXPositions[i-1];
            tilesYPositions[i] = tilesYPositions[i-1];
          }
        tilesXPositions[0] = x_pos;
        tilesYPositions[0] = y_pos;
    }

    public float[] getLowestTile(){
      coords[0] = tilesXPositions[4];
      coords[1] = tilesYPositions[4];
      //Debug.Log(coords[1]);
      return coords;
    }

    private void GenerateNewPlatform(Collider2D collision)
    {

          Debug.Log(tilesXPositions[0]);
          Debug.Log(tilesYPositions[0]);

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

                Instantiate(bigBouncePlatformPrefab, new Vector2(generation_axis + x_pos, y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);

            }
            else if (random == 2){
              Destroy(collision.gameObject);
              Instantiate(bigBouncePlatformPrefab, new Vector2(generation_axis + x_pos,  y_pos/*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);
              Instantiate(IcePlatformPrefab, new Vector2(generation_axis + Random.Range(-5.5f, 5.5f),  y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);

            }else
            {
                collision.gameObject.transform.position = new Vector2(generation_axis + x_pos, y_pos/* + Random.Range(extra - 0.5f, extra)*/);
            }
            updateTileArray(x_pos, y_pos);
        }
        //When we collide with bigjump platform
        else if (collision.gameObject.name.StartsWith("BigJump"))
        {
            //1 in 7 we will replace this bigjump platform, 6 in 7 generate new normal platform.
            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(generation_axis + x_pos,  y_pos /*+ Random.Range(extra - 0.5f, extra)*/);
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(generation_axis + x_pos,  y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);
            }
            updateTileArray(x_pos,y_pos);
        }



    }
}
