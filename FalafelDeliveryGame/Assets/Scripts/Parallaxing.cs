using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] backgrounds;         //Array of of backgrounds to be parallaxed
    private float[] parallaxScales;         //The proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f;            //Smoothness of parallax. Set above 0 to make the parallax effect work;
        
    private Transform cam;                  //Refference to the main camera transform
    private Vector3 previousCamPosition;    //Store previous position of the camera

    //Is called before Start()
    void Awake() {
        //Set up the camera reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start() {
        //The previous frame had the current frame's camera position
        previousCamPosition = cam.position;


        //Assign corresponding parallax scales to the backgrounds
        parallaxScales = new float[backgrounds.Length];

        for (int i = 0;i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update() {
        
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //the parallax is the oppposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPosition.y - cam.position.y) * parallaxScales[i];

            //Set a target y position, which is the current position + the parallax
            float backgroundTargetPosY = backgrounds[i].position.y + parallax;

            //Create a target position (the backgrounds current position with it's target x position)
            Vector3 backgroundTargetPos = new Vector3(backgrounds[i].position.x, backgroundTargetPosY, backgrounds[i].position.z);

            //Fade between current and target position (using lerp)
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCamPosition = cam.position;
    }
}
