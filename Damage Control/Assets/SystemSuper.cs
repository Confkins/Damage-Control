using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemSuper : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject explosion;
    public float hitPointCounter;
    public float maxHitPoints;
    public GameObject subSystem;
    public int radius = 3;
    public static int sparePartCounter = 0;
    public BoxCollider operationalRange;
    public Slider healthbarPrefab;
    public Transform healthCanvas;
    public float healthpoint;
    Slider healthbar;


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
            if (sparePartCounter > 0)
            {
                yield return new WaitForSeconds(1);
                hitPointCounter++;
                sparePartCounter--;
            }
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

    public void createHealthbar()
    {
        Vector3 place = subSystem.transform.position;
        place.y = healthCanvas.transform.position.y;
        healthbar = Instantiate(healthbarPrefab, place, healthCanvas.rotation, healthCanvas);
    }

    public void updateHealthbar()
    {
        if(healthbar != null)
        {
            healthpoint = hitPointCounter / maxHitPoints;
            healthbar.value = healthpoint;
        }
        
    }

    public void destroyHealthbar()
    {
        Destroy(healthbar.gameObject);
    }
}
