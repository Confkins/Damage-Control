using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystems : SystemSuper
{
    public ShipSystems()
    {
        hitPointCounter = 10;
        maxHitPoints = 10;
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
        if(other.gameObject.tag == "DismantlePawn")
        {
            StartCoroutine("dismantle");
        }
        if(other.gameObject.tag == "RepairPawn")
        {
            StartCoroutine("repair");
        }
        if (other.gameObject.tag == "Missile")
        {
            Destroy(other.gameObject);
            hitPointCounter--;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "DismantlePawn")
        {
            StopCoroutine("dismantle");
        }
        if (other.gameObject.tag == "RepairPawn")
        {
            StopCoroutine("repair");
        }
    }
}
