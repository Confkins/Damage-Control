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
    }

    public IEnumerator loadMissile()
    {
        while (1==1)
        {
            yield return new WaitForSeconds(5);
            createMissile();
        }
    }

    void createMissile()
    {
        missile = Instantiate(missilePrefab, missilePod.transform.position, missilePrefab.transform.rotation);
        missile.transform.SetParent(missilePod.transform);
    }
}
