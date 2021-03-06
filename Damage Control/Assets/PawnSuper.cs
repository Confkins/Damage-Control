﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class PawnSuper : MonoBehaviour {

    public GameObject pawn;
    public bool isSelected;
    public NavMeshAgent agent;
    public Collider colliderID;
    public int SparePartCounter;
    public Button ButtonPrefab1;
    public Button ButtonPrefab2;
    public Button ButtonPrefab3;
    Button menubutton1;
    Button menubutton2;
    Button menubutton3;
    public Transform gameCanvas;
    public Transform healthCanvas;
    public TMP_Text namePrefab;
    TMP_Text pawnName;


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
                if (hit.collider.tag ==  "System")
                {
                    gameObject.tag = "Pawn";

                    if (menubutton1)
                    {
                        destroyButton();
                    }

                    Vector3 place = hit.transform.position;
                    Vector3 offset = new Vector3(0,0,1);
                    place.y = gameCanvas.transform.position.y;

                    Vector3 buttonPos1 = place;
                    Vector3 buttonPos2 = place - offset;
                    Vector3 buttonPos3 = place - (offset*2);

                    menubutton1 = Instantiate(ButtonPrefab1, buttonPos1, gameCanvas.rotation, gameCanvas);
                    menubutton2 = Instantiate(ButtonPrefab2, buttonPos2, gameCanvas.rotation, gameCanvas);
                    menubutton3 = Instantiate(ButtonPrefab3, buttonPos3, gameCanvas.rotation, gameCanvas);

                    if (menubutton1 != null)
                    {
                        menubutton1.onClick.AddListener(destroyButton);
                        menubutton2.onClick.AddListener(destroyButton);
                        menubutton3.onClick.AddListener(destroyButton);

                        menubutton1.onClick.AddListener(setPlayerAsDismantle);
                        menubutton2.onClick.AddListener(setPlayerAsRepair);
                        menubutton3.onClick.AddListener(stopPlayer);
                    }

                    StartCoroutine("killMenu");
                }
            }
        }
    }

    void destroyButton()
    {
        Destroy(menubutton1.gameObject);
        Destroy(menubutton2.gameObject);
        Destroy(menubutton3.gameObject);
    }

    void setPlayerAsRepair()
    {
        gameObject.tag = "RepairPawn";
    }

    void setPlayerAsDismantle()
    {
        gameObject.tag = "DismantlePawn";
    }

    void stopPlayer()
    {
        agent.destination = agent.transform.position;
    }

    public IEnumerator killMenu()
    {
        yield return new WaitForSeconds(5);
        if (menubutton1 != null)
        {
            destroyButton();
        }
        yield return null;
    }

    public void showName()
    {
        Vector3 place = pawn.transform.position;
        place.y = healthCanvas.transform.position.y;
        place.z = pawn.transform.position.z + 1;
        pawnName = Instantiate(namePrefab, place, healthCanvas.rotation, healthCanvas);
        pawnName.text = pawn.name;
    }

    public void updateName()
    {
        Vector3 place = pawn.transform.position;
        place.y = healthCanvas.transform.position.y;
        place.z = pawn.transform.position.z + 1;
        pawnName.transform.position = place;
    }
}