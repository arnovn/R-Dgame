using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
  public GameObject player;
  public GameObject platformPrefab;
  public GameObject bigBouncePlatformPrefab;
  public GameObject IcePlatformPrefab;
  public GameObject FirePlatform;
  public GameObject Moving;
  public GameObject Seagul;
  private GameObject myPlat;

  public GameObject DdaCollider;
  private Death death;
  private Bounce platform;
  private BigBounce bigBounce;
  private DdaParams ddaparamaters;
  private GenerationValues generationValues;
  private MovingTile movingTile;
  private Background background;

  private float range = 22f;
  private float generation_axis;
  private int index;
  private bool generating;
  private float[] coords = new float[2];
  private float[] tilesXPositions;
  private float[] tilesYPositions;

  //Params for DDA: distance between tiles & random range for spawning special tiles
  int skillevel;
  private float tileDistance;

  struct Coord2D
  {
    public float xpos;
    public float ypos;
  }

  //MAX AFSTAND TUSSEN TILES IS 8.82F!!!!!!!!!
  // Start is called before the first frame update
  void Start()
  {

    if(player.gameObject.name.StartsWith("SingleUser")){
      tilesXPositions = new float[] {-4f,3.7f,-3f,3.2f,-2.4f,2.93f,-2.19f,4.26f,-4.71f,0.05f};
      tilesYPositions = new float[] {41f,36.8f,30.6f,23.9f,16.6f,10.81f,5.84f,0.67f,-3.02f,-8.07f};
      generation_axis = 0f;
    }
    else if(player.gameObject.name.StartsWith("User1")){
      tilesXPositions = new float[] {-1.4f,1.1f,-3.8f,1.6f,-2.2f,1.9f,-2.9f,-0.1f};
      tilesYPositions = new float[] {28.6f,24.4f,20.7f,16.2f,10.8f,7.4f,3.91f,-1.75f};
      generation_axis = 0f;

    }
    else if(player.gameObject.name.StartsWith("User2")){
      tilesXPositions = new float[] {101.8f,104.3f,99.4f,104.8f,101f,105.1f,100.3f,101.3f};
      tilesYPositions = new float[] {28.6f,24.4f,20.7f,16.2f,10.8f,7.4f,3.91f,-1.75f};
      generation_axis = 101.9f;
    }

    background = player.GetComponent<Background>();
    movingTile = Moving.GetComponent<MovingTile>();
    generation_axis = player.transform.position.x;
    death = DdaCollider.GetComponent<Death>();
    ddaparamaters = DdaCollider.GetComponent<DdaParams>();
    generationValues = DdaCollider.GetComponent<GenerationValues>();
    skillevel = ddaparamaters.getSkillLevel();
    generationValues.SetSkillLevel(skillevel);
    generating = true;

    //Setting DDA params:
    tileDistance = 7f; //Max 8,72f
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
    if (collision.gameObject.name.StartsWith("enemy"))
    {
      Destroy(collision.gameObject);
      background.resetVelocity();
    }
    else if(generating){
      skillevel = ddaparamaters.getSkillLevel();
      generationValues.SetSkillLevel(skillevel);
      GenerateNewPlatform(collision);
    }
    else if(generating){
      if(collision.gameObject.name.Contains("finish")){

      }
      /*
      else{
        Destroy(collision.gameObject);
        updateTileArray(tilesXPositions[0],tilesYPositions[0]);
      }
      */
    }
  }

  private void updateTileArray(float x_pos, float y_pos){
    for(int i = 7; i>0; i--){

      tilesXPositions[i] = tilesXPositions[i-1];
      tilesYPositions[i] = tilesYPositions[i-1];
    }
    //Debug.Log("Shifted");
    tilesXPositions[0] = x_pos;
    tilesYPositions[0] = y_pos;
  }

  public int getLowestTile(){
    int lowestIndex = 0;
    for(int i = 1; i<8; i++){

      float lowest = tilesYPositions[0];
      //  Debug.Log(tilesYPositions[i]);
      if(tilesYPositions[i]< lowest && tilesYPositions[i] != 0f){
        //  Debug.Log("YES");
        lowest = tilesYPositions[i];
        lowestIndex = i;
      }
    }
    //  Debug.Log("STOP");
    return lowestIndex;
  }

  public float getHighestTilePosition()
  {
    return tilesYPositions[0];
  }

  public void StopGenerating(){
    generating = false;
  }

  public float returnLowestXPosition()
  {
    return tilesXPositions[7];
  }

  public float returnLowestYPosition()
  {
    return tilesYPositions[7]; //other version [9]
  }

  private Coord2D SetNewPlatformPosition()
  {
    float y_pos = tilesYPositions[0] + generationValues.RandomRangeYvalue();//8.82f;
    float x_pos = generation_axis + generationValues.RandomRangeXvalue();
    Coord2D position;
    position.xpos = x_pos;
    position.ypos = y_pos;
    return position;
  }

  private void generateEasyTile(Collider2D collision, Coord2D position)
  {

    int random = generationValues.RandomRangeSpecialPlatform();

    if (random < 5) //Special easy tile generated
    {
      if (checkPlatformType(collision) == 2)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, bigBouncePlatformPrefab);
      }
    }
    else if(random < 10)
    {
      if (checkPlatformType(collision) == 1)
      {
        replaceTile(collision, position);
      }
      else
      {
        movingTile.setSpeed(10f);
        generateNewTile(collision, position, Moving);
      }
    }
    else {
      if (checkPlatformType(collision) == 1)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, platformPrefab);
      }

    }
  }

  private void generateAllTiles(Collider2D collision, Coord2D position)
  {
    int random = generationValues.RandomRangeSpecialPlatform();

    if (random < 3) //Moving
    {
      if (checkPlatformType(collision) == 4)
      {
        replaceTile(collision, position);
      }
      else
      {
        movingTile.setSpeed(50f);
        generateNewTile(collision, position, Moving);
      }
    }
    else if (random == 4 || random == 5) // Fire tile
    {
      if (checkPlatformType(collision) == 3)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, FirePlatform);
      }
    }
    else if (random == 6 || random == 7)
    {
      if (checkPlatformType(collision) == 2)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, bigBouncePlatformPrefab);
      }
    }
    else
    {
      if (checkPlatformType(collision) == 1)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, platformPrefab);
      }
    }
  }

  private void generateDifficultTile(Collider2D collision, Coord2D position)
  {
    int random = generationValues.RandomRangeSpecialPlatform();

    if (random < 6) //Moving
    {
      if (checkPlatformType(collision) == 4)
      {
        replaceTile(collision, position);
      }
      else
      {
        movingTile.setSpeed(100f);
        generateNewTile(collision, position, Moving);
      }
    }
    else if (random == 7 || random == 8) // Fire tile
    {
      if (checkPlatformType(collision) == 3)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, FirePlatform);
      }
    }
    else
    {
      if (checkPlatformType(collision) == 1)
      {
        replaceTile(collision, position);
      }
      else
      {
        generateNewTile(collision, position, platformPrefab);
      }
    }
  }

  //Generates new platform when collided with normal platform
  private void GenerateCollidedPlatform(Collider2D collision, Coord2D position)
  {
    float x_pos = position.xpos;
    float y_pos = position.ypos;

    int random = generationValues.RandomRangeSpecialPlatform();
    if (random == 1)

    {
      generateNewTile(collision, position, bigBouncePlatformPrefab);

    }
    else if (random == 2)
    {
      generateNewTile(collision, position, bigBouncePlatformPrefab);

    }
    else
    {
      replaceTile(collision, position);
    }

  }

  private void GenerateNewPlatform(Collider2D collision)
  {
    index = getLowestTile();
    Coord2D position = SetNewPlatformPosition();

    if (skillevel == 0 || skillevel == 1)
    {//Easy jump
      generateEasyTile(collision, position);
    }
    else if (skillevel == 2)
    {//Skilled jump unskilled enemy
      generateAllTiles(collision, position);
    }
    else if (skillevel ==3)
    {//skilled jump, skilled enemy
      generateAllTiles(collision, position);
    }
    else if (skillevel == 4)
    {//Very skilled jump
      generateDifficultTile(collision, position);

    }

    if (collision.gameObject.name.StartsWith("Platform")){
      updateTileArray(position.xpos,position.ypos);
      death.lastPlatformPosition(tilesXPositions[index], tilesYPositions[index]);
    }
  }

  private int checkPlatformType(Collider2D collision)
  {
    if (collision.gameObject.name.StartsWith("PlatformNormal"))
    {
      return 1;
    }

    else if (collision.gameObject.name.StartsWith("PlatformBig"))
    {
      return 2;
    }
    else if (collision.gameObject.name.StartsWith("PlatformFire"))
    {
      return 3;
    }
    else if (collision.gameObject.name.StartsWith("PlatformMovingTile"))
    {
      return 4;
    }
    return 0;
  }

  private void replaceTile(Collider2D collision, Coord2D position)
  {
    float x_pos = position.xpos;
    float y_pos = position.ypos;
    collision.gameObject.transform.position = new Vector2(x_pos, y_pos /*+ Random.Range(extra - 0.5f, extra)*/);
  }

  private void generateNewTile(Collider2D collision, Coord2D position, GameObject newPlatform)
  {
    float x_pos = position.xpos;
    float y_pos = position.ypos;
    if(collision.gameObject.name.StartsWith("Platform")){
      Destroy(collision.gameObject);
    }
    Instantiate(newPlatform, new Vector2(x_pos, y_pos /*+ Random.Range(extra - 0.5f, extra)*/), Quaternion.identity);
  }
}
