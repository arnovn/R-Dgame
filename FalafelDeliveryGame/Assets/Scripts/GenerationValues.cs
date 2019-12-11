using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerationValues : MonoBehaviour
{
    int skillLevel = 0;
    int specialRange = 25;
    float enemy_speed;
    int enemy_frequency;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getEnemySpeed()
    {
        switch (skillLevel)
        {
            case 0:     //UnskilledBoth (jump & enemies)
                return 0.08f;
            case 1:     //UnskilledJump -> but skilled enemies, TO DO: change something with enemies
                return 0.12f;
            case 2:     //Skilled both enemy and jumping a bit harder
                return 0.14f;
            case 3:     //Very skilled both enemy gen & jumping most difficult
                return 0.18f;
            default:
                return 0.08f;
        }
    }

    //Gives X range between chich new values are transformed
    public float RandomRangeXvalue()
    {
       
        switch (skillLevel)
        {
            case 0:     //UnskilledBoth (jump & enemies)
                return Random.Range(-5f, 5f);
            case 1:     //UnskilledJump -> but skilled enemies, TO DO: change something with enemies
                return Random.Range(-5f, 5f);
            case 2:     //Skilled both enemy and jumping a bit harder
                return Random.Range(-6f, 6f);
            case 3:     //Very skilled both enemy gen & jumping most difficult
                SetRandomRangeSpecialPlatform(10);
                return Random.Range(-7f, 7f);
            default:
                return Random.Range(-5.5f, 5.5f);
        }
    }

    public float RandomRangeYvalue()
    {
        switch(skillLevel)
        {
            case 0:    //Unskilled both: both enemies and jump easiest
                SetRandomRangeSpecialPlatform(30);
                return Random.Range(2f, 5f);
            case 1:     //UnskilledJump -> but skilled enemies, TO DO: change something with enemies
                SetRandomRangeSpecialPlatform(12);
                return Random.Range(2f, 5f);
            case 2:     //Unskilled enemy skilled jump
                SetRandomRangeSpecialPlatform(14);
                return Random.Range(4f, 6f);
            case 3:     //Skilled both enemy and jumping a bit harder
                SetRandomRangeSpecialPlatform(10);
                return Random.Range(6f, 7.5f);
            case 4:     //Very skilled both enemy gen & jumping most difficult
                SetRandomRangeSpecialPlatform(10);
                return Random.Range(6f, 7.5f);
            default:
                return Random.Range(2f, 7.5f);
        }

    }

    private void SetRandomRangeSpecialPlatform(int newRange)
    {
        specialRange = newRange;
    }

    //Gives back chance for which special platform will be transformed
    public int RandomRangeSpecialPlatform()
    {
        return Random.Range(1, specialRange); //14
    }

    public void SetSkillLevel(int newSkillLevel)
    {
        skillLevel = newSkillLevel;
    }
}
