using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{
    char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    char[] name = new char[10];
    private int nameCount = 0;
    private int alphaCount = 0;
    public TextMeshProUGUI nameValueText;
    bool nameSet = false;

    private void Awake()
    {
        name[nameCount] = alphabet[alphaCount];
    }

    private void Update()
    {
        if (nameSet == false)
        {
            string nameString = new string(name);
            nameValueText.SetText(nameString);
        }
    }

    public void LeftChar()
    {
        if (alphaCount == 0)
        {
            alphaCount = 25;
        }
        else
        {
            alphaCount--;
        }
        name[nameCount] = alphabet[alphaCount];
    }

    public void RightChar()
    {
        if (alphaCount == 25)
        {
            alphaCount = 0;
        }
        else
        {
            alphaCount++;
        }
        name[nameCount] = alphabet[alphaCount];
    }

    public void SetName()
    {
        nameSet = true;
    }

    public void NextChar()
    {
        nameCount++;
    }
}
