using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public Vector3 endScale;
    public Vector3 inflation = new Vector3(3,3,3);

    void Start()
    {
        explosion = gameObject;
        endScale = new Vector3(3.0f,3.0f,3.0f);
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        transform.localScale += inflation;
        if(transform.localScale.y > endScale.y)
        {
            Destroy(explosion);
        }
        
    }      
}
