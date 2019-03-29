using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PawnSuper : MonoBehaviour {

    public bool isSelected;
    public NavMeshAgent agent;
    public Collider colliderID;
    public int SparePartCounter;

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
}

