using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystems : SystemSuper
{
    public ShipSystems()
    {
        hitPointCounter = 10;

    }

    void Start()
    {
        this.subSystem = gameObject;
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = false;
        rigidBody.isKinematic = false;
        rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        operationalRange = subSystem.GetComponent<BoxCollider>();
        operationalRange.size = new Vector3(radius,1,radius);
        operationalRange.isTrigger = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        Dismantle();
    }
}
