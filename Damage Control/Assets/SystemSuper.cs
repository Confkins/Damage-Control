using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSuper : MonoBehaviour
{
    public int hitPointCounter;
    public int maxHitPoints;
    public GameObject subSystem;
    public int radius = 3;
    public static int sparePartCounter = 0;
    public BoxCollider operationalRange;

    public void Dismantle()
    {
        StartCoroutine("dismantleTime");
    }

    public void Repair()
    {
        StartCoroutine("repairTime");
    }

    public IEnumerator dismantleTime()
    {
        while (hitPointCounter != 0)
        {
            yield return new WaitForSeconds(1);
            hitPointCounter--;
            sparePartCounter++;
        }
    }

    public IEnumerator repairTime()
    {
        while (hitPointCounter != maxHitPoints)
        {
            yield return new WaitForSeconds(1);
            hitPointCounter++;
            sparePartCounter--;
        }
    }
}
