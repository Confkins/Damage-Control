using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    public int edge = 30;
    public int scrollSpeed = 1;
    public Vector3 scroller = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x > Screen.width - edge)
        {
            scroller.x = scrollSpeed;
            cam.transform.position += scroller * Time.deltaTime;
        }

        if (Input.mousePosition.x < edge)
        {
            scroller.x = -scrollSpeed;
            cam.transform.position += scroller * Time.deltaTime;
        }
        if (Input.mousePosition.y > Screen.height - edge)
        {
            scroller.z = scrollSpeed;
            cam.transform.position += scroller * Time.deltaTime;
        }
        if (Input.mousePosition.y < edge)
        {
            scroller.z = -scrollSpeed;
            cam.transform.position += scroller * Time.deltaTime;
        }
    }
}


