using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSuper : MonoBehaviour
{
    public int hitPointCounter;
    public int maxHitPoints;
    public GameObject system;
    public int radius = 30;
    public int sparePartCounter;


    public void Dismantle()
    {
        Debug.Log(hitPointCounter);
        Vector3 origin = system.transform.position;

        if (hitPointCounter > 0)
        {
            Collider[] hitColliders = Physics.OverlapSphere(origin, radius);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].tag == "pawn")
                {
                    Debug.Log("Somebody Kill Me");
                    while (hitPointCounter != 0)
                    {
                        hitPointCounter--;
                        sparePartCounter++;
                    }
                }
            }
        }
    }

    public void Repair()
    {
        if (hitPointCounter < maxHitPoints)
        {
            RaycastHit hit;
            Vector3 origin = system.transform.position;

            if (Physics.SphereCast(origin, radius, origin, out hit, 10))
            {
                if (hit.collider.tag == "Pawn")
                {
                    while (hitPointCounter != maxHitPoints)
                    {
                        hitPointCounter++;
                        sparePartCounter--;
                    }
                }
            }
        }
    }
}
