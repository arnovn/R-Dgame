using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image barImage;
    public GameObject user;
    private Finish finish;
    // Start is called before the first frame update
    private void Awake()
    {
        barImage.fillAmount = 0.3f;
        finish = user.GetComponent<Finish>();
    }

    public void Update()
    {
        barImage.fillAmount = calculateProgress();
        //user.gameObject.transform.position.y
        if (user.GetComponent<Rigidbody2D>().position.y -10 > finish.getYPos())
        {
            Debug.Log("end");
            //  user.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private float calculateProgress()
    {

        return user.GetComponent<Rigidbody2D>().position.y / (finish.getYPos()+20);
    }
}
