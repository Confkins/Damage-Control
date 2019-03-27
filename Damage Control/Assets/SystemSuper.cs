using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSuper : MonoBehaviour
{
    public int hitPointCounter;
    public int maxHitPoints;
    public GameObject subSystem;
    public int radius = 2;
    public int sparePartCounter = 0;

    public void Dismantle()
    {
        Debug.Log(hitPointCounter);
        Debug.Log(sparePartCounter);

        if (hitPointCounter > 0)
        {
            while (hitPointCounter != 0)
            {
                hitPointCounter--;
                sparePartCounter++;
            }
        }
    }

    public void Repair()
    {   
    }
}
