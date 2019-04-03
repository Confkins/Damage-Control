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

    public void DoorClose()
    {
        subSystem.transform.Translate(Vector3.back * Time.deltaTime);
    }

    public IEnumerator dismantle()
    {
        while (hitPointCounter != 0)
        {
            yield return new WaitForSeconds(1);
            hitPointCounter--;
            sparePartCounter++;
        }
    }

    public IEnumerator repair()
    {
        while (hitPointCounter != maxHitPoints)
        {
            yield return new WaitForSeconds(1);
            hitPointCounter++;
            sparePartCounter--;
        }
    }

    public IEnumerator openDoor()
    {
        Vector3 origin = subSystem.transform.position;
        Debug.Log(origin);
        subSystem.transform.Translate(Vector3.forward * 300);

        yield return new WaitForSeconds(3);
        Debug.Log(origin);
        subSystem.transform.position = origin;


        yield return null;
    }
}
