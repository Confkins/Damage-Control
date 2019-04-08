using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public static int count;
    public TMP_Text winPrefab;
    public TMP_Text losePrefab;
    public TMP_Text namePrefab;
    TMP_Text systemName;
    TMP_Text win;
    TMP_Text lose;

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

    public void showName()
    {
        Vector3 place = subSystem.transform.position;
        place.y = healthCanvas.transform.position.y;
        place.z = subSystem.transform.position.z - 1;
        systemName = Instantiate(namePrefab, place, healthCanvas.rotation, healthCanvas);
        systemName.text = subSystem.name;
    }

    public IEnumerator winState()
    {
        win = Instantiate(winPrefab, healthCanvas.position, healthCanvas.rotation, healthCanvas);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }

    public IEnumerator loseState()
    {
        lose = Instantiate(losePrefab, healthCanvas.position, healthCanvas.rotation, healthCanvas);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
    }
}
