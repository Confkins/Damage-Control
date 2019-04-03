using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera cam;
    public int edge = 20;
    public int scrollSpeed = 1;
    private Vector3 scroller;
    public Bounds bBox;
    public Vector3 origin;

    // Start is called before the first frame update
    void Start()
    {
        bBox = new Bounds(cam.transform.position, new Vector3(40, 40, 40));
        origin = cam.transform.position;
        StartCoroutine("moveCamera");
    }

    public IEnumerator moveCamera()
    {
        while (1 == 1)
        {
            scroller = new Vector3(0, 0, 0);
            if (bBox.Contains(cam.transform.position))
            {
                if (Input.mousePosition.x > Screen.width - edge)
                {
                    scroller.x = scrollSpeed;
                }
                else
                {
                    scroller.x = 0;
                }

                if (Input.mousePosition.x < edge)
                {
                    scroller.x = -scrollSpeed;
                }
                if (Input.mousePosition.y > Screen.height - edge)
                {
                    scroller.z = scrollSpeed;
                }
                if (Input.mousePosition.y < edge)
                {
                    scroller.z = -scrollSpeed;
                }

                cam.transform.position += scroller * Time.deltaTime;
            }
            else
            {
                    cam.transform.position = origin;
            }
            yield return null;
        }
    }
}


