using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject target;
    public Vector3 origin;
    public Vector3 trajectory;
    int index;
    float FireTime;
    public float arc;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("System");
        index = Random.Range(0, targets.Length);
        target = targets[index];
        origin = transform.position;
        trajectory = new Vector3(0,0,0);
        FireTime = 0;
        arc = 10;
    }

    void Update()
    {
        FireTime += Time.deltaTime * 0.2f;
        trajectory = Vector3.Lerp(origin, target.transform.position, FireTime);
        trajectory.y += 5 * Mathf.Sin(Mathf.Clamp01(FireTime) * Mathf.PI);
        transform.position = trajectory;
    }
}
