using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject target;
    public GameObject missilePod;
    public float time = 0.5f;
    public GameObject missile;
    public bool loaded = false;
    public float speed = 5.0f;

    void Start()
    {
        this.missilePod = gameObject;
        StartCoroutine("fireTimer");
    }

    public IEnumerator fireTimer()
    {
        while(1==1)
        {
            missile = Instantiate(missilePrefab, missilePod.transform.position, missilePrefab.transform.rotation, missilePod.transform);
            loaded = true;
            yield return new WaitForSeconds(10); 
        }
    }

    void Update()
    {
        if (loaded == true)
        {
            missile.transform.position = Vector3.Slerp(missilePod.transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }
/*
    DELETE

        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;

        return desired - velocity;

        force += b.Calculate() * b.weight;

        float f = force.magnitude;
        if (f >= maxForce)
        {
            force = Vector3.ClampMagnitude(force, maxForce);
            break;


        return force;
            void Update()
            {
                force = Calculate();
                Vector3 newAcceleration = force / mass;
                acceleration = Vector3.Lerp(acceleration, newAcceleration, Time.deltaTime);
                velocity += acceleration * Time.deltaTime;

                velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

                if (velocity.magnitude > float.Epsilon)
                {
                    Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
                    transform.LookAt(transform.position + velocity, tempUp);

                    transform.position += velocity * Time.deltaTime;
                    velocity *= (1.0f - (damping * Time.deltaTime));
                }
            }

            
        if (targetGameObject != null)
        {
            target = targetGameObject.transform.position;
        }
        */
}
