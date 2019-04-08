using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystems : SystemSuper
{
    public ShipSystems()
    {
        hitPointCounter = 10.0f;
        maxHitPoints = 10.0f;
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

    void Update()
    {
        updateHealthbar();
    }

    public void OnTriggerEnter(Collider other)
    {
        createHealthbar();

        if (other.gameObject.tag == "DismantlePawn")
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
            explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.transform.SetParent(transform);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        destroyHealthbar();
 
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
