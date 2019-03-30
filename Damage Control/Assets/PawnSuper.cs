using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PawnSuper : MonoBehaviour {

    public bool isSelected;
    public NavMeshAgent agent;
    public Collider colliderID;
    public int SparePartCounter;
    public GameObject ButtonPrefab;
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
                if (hit.collider.tag ==  "System")
                {
                    GameObject menubutton1 = Instantiate(ButtonPrefab, gameCanvas.transform.position, gameCanvas.rotation, gameCanvas);
                }
            }
        }
    }
}