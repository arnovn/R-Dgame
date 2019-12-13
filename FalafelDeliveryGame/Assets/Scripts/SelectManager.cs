using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    private Button[] Menu = new Button[4];

    // Start is called before the first frame update
    void Start()
    {
        Menu = this.GetComponentsInChildren<Button>();
        foreach(Button b in Menu)
        {
            Debug.Log(b.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
