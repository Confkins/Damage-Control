﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PawnSuper : MonoBehaviour {

    public bool isSelected;
    public NavMeshAgent agent;
    public Collider colliderID;
    public int SparePartCounter;
    public GameObject ButtonPrefab1;
    public GameObject ButtonPrefab2;
    public GameObject ButtonPrefab3;
    public Transform gameCanvas;

    public IEnumerator Selector()
    {
        while (1 == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    if (hit.collider == colliderID)
                    {
                        isSelected = true;
                    }
                    else
                    {
                        isSelected = false;
                    }
                }
            }
            yield return null;
        }
    }

    public void MoveToClick ()
    {
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }

    public void ChooseAction()
    {
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Debug.Log(hit.transform.position);
                if (hit.collider.tag ==  "System")
                {
                    Vector3 place = hit.transform.position;
                    Vector3 offset = new Vector3(0,0,1);
                    place.y = gameCanvas.transform.position.y;

                    Vector3 buttonPos1 = place;
                    Vector3 buttonPos2 = place - offset;
                    Vector3 buttonPos3 = place - (offset*2);

                    Debug.Log(buttonPos1);
                    Debug.Log(buttonPos2);
                    Debug.Log(buttonPos3);

                    GameObject menubutton1 = Instantiate(ButtonPrefab1, gameCanvas.transform.position, gameCanvas.rotation, gameCanvas);
                    GameObject menubutton2 = Instantiate(ButtonPrefab2, gameCanvas.transform.position, gameCanvas.rotation, gameCanvas);
                    GameObject menubutton3 = Instantiate(ButtonPrefab3, gameCanvas.transform.position, gameCanvas.rotation, gameCanvas);

                    menubutton1.GetComponent<RectTransform>().position = buttonPos1;
                    menubutton2.GetComponent<RectTransform>().position = buttonPos2;
                    menubutton3.GetComponent<RectTransform>().position = buttonPos3;
                }
            }
        }
    }
}