using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSuper : MonoBehaviour
{
    public int hitPointCounter;
    public int maxHitPoints;
    public GameObject subSystem;
    public int radius = 3;
    public int sparePartCounter = 0;
    public BoxCollider operationalRange;

    public void Dismantle()
    {
        Debug.Log(hitPointCounter);
        Debug.Log(sparePartCounter);

        while (hitPointCounter != 0)
        {
            hitPointCounter--;
            sparePartCounter++;
        }
    }

    public void Repair()
    {
           
    }
}
