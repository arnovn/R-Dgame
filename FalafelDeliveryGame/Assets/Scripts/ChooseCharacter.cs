using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseCharacter : MonoBehaviour
{

    public SpriteRenderer user;
    public string userString;
    public TextMeshProUGUI text;

    public Sprite DefaultSprite;
    public Sprite AstronautSprite;
    public Sprite BrakkeSprite;
    public Sprite NinjaSprite;
    public Sprite SantaSprite;

    public ReadArduino ra;
    public int ReadValueNumber;

    public TextMeshProUGUI confirm;

    Sprite[] AllSprites;
    int SpriteCount = 0;
    int JoystickWait = 0;
    bool confirmed = false;

    // Start is called before the first frame update
    void Start()
    {
        AllSprites = new Sprite[5] { DefaultSprite, SantaSprite, AstronautSprite, NinjaSprite, BrakkeSprite };
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("userString : " + userString);
        SpriteChange();
        if (JoystickWait > 17 && !confirmed)
        {
            JoystickCheck();
            CheckConfirm();
        }
        else { JoystickWait++; }
    }

    void SpriteChange()
    {
        switch (SpriteCount)
        {
            case 0:
                Default();
                break;
            case 1:
                Santa();
                break;
            case 2:
                Astronaut();
                break;
            case 3:
                Ninja();
                break;
            case 4:
                Brakke();
                break;
            default:
                Default();
                break;
        }
    }

    void JoystickCheck()
    {
        //Debug.Log(SpriteCount);
        if (ra.ValuesArduino()[ReadValueNumber] <= 60)
        {
            SpriteCount++;
            if (SpriteCount > 4)
            {
                SpriteCount = 0;
            }
            JoystickWait = 0;
        }
        else if (ra.ValuesArduino()[ReadValueNumber] >= 200)
        {
            SpriteCount--;
            if (SpriteCount < 0)
            {
                SpriteCount = 4;
            }
            JoystickWait = 0;
        }
    }

    void CheckConfirm()
    {
        if(ra.ValuesArduino()[ReadValueNumber + 4] == 1)
        {
            confirmed = true;
            confirm.gameObject.SetActive(true);

        }
    }

    public bool GetConfirmed() { return confirmed; }

    void Default()
    {
        user.sprite = DefaultSprite;
        text.text = "classic";
        PlayerPrefs.SetInt(userString, 1);
        //Debug.Log("Current sprite : " + PlayerPrefs.GetInt(userString,1));
    }

    void Santa()
    {
        user.sprite = SantaSprite;
        text.text = "santa";
        PlayerPrefs.SetInt(userString, 2);
        //Debug.Log("Current sprite : " + PlayerPrefs.GetInt(userString,1));

    }

    void Astronaut()
    {
        user.sprite = AstronautSprite;
        text.text = "astronaut";
        PlayerPrefs.SetInt(userString, 3);
        //Debug.Log("Current sprite : " + PlayerPrefs.GetInt(userString,1));

    }

    void Ninja()
    {
        user.sprite = NinjaSprite;
        text.text = "ninja";
        PlayerPrefs.SetInt(userString, 4);
        //Debug.Log("Current sprite : " + PlayerPrefs.GetInt(userString,1));

    }

    void Brakke()
    {
        user.sprite = BrakkeSprite;
        text.text = "brak";
        PlayerPrefs.SetInt(userString, 5);
        //Debug.Log("Current sprite : " + PlayerPrefs.GetInt(userString,1));

    }
}
