using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{

    public GameObject missilePrefab;
    public GameObject missilePod;
    GameObject missile;

    
    // Start is called before the first frame update
    void Start()
    {
        missilePod = gameObject;
        StartCoroutine("loadMissile");
        Debug.Log("This happened");
    }

    public IEnumerator loadMissile()
    {
        Debug.Log("Coroutine Started happened");
        while (1==1)
        {
            yield return new WaitForSeconds(10);
            createMissile();
        }
    }

    void createMissile()
    {
        Debug.Log("Function happened");
        missile = Instantiate(missilePrefab, missilePod.transform.position, missilePrefab.transform.rotation);
        missile.transform.SetParent(missilePod.transform);
    }
}
