using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : SystemSuper
{
    // Start is called before the first frame update
    void Start()
    {
        this.subSystem = gameObject;
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.isKinematic = false;
        rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        operationalRange = subSystem.GetComponent<BoxCollider>();
        operationalRange.size = new Vector3(radius*10, 1, 1);
        operationalRange.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Missile")
        {
            StartCoroutine("openDoor");
        }
    }
}
