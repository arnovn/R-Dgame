using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    private Button[] Menu = new Button[4];

    public bool Enabled;

    private void Awake()
    {
        Menu = this.GetComponentsInChildren<Button>();
        foreach (Button b in Menu)
        {
            Debug.Log(b.name);
        }
    }

    private void OnEnable()
    {
        Menu[0].Select(); 
        Menu[0].OnSelect(null);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
