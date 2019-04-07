using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missiles : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject target;
    public GameObject missilePod;
    public GameObject missile;
    public bool loaded = false;
    public float speed = 5.0f;
    public Vector3 force = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    void Start()
    {
        this.missilePod = gameObject;
        StartCoroutine("fireTimer");
    }

    public IEnumerator fireTimer()
    {
        while(1==1)
        {
            missile = Instantiate(missilePrefab, missilePod.transform.position, missilePrefab.transform.rotation);
            missile.transform.SetParent(missilePod.transform);
            yield return new WaitForSeconds(10);
            loaded = true;
        }
    }

    public Vector3 Calculate()
    {
        force = target.transform.position - missile.transform.position;
        force *= speed;
        return force;
    }

    void Update()
    {
        if (loaded == true && missile != null)
        { 
            force = Calculate();
            velocity += force * Time.deltaTime;
            missile.transform.position += velocity * Time.deltaTime;
        }

        if (missile = null)
        {
            velocity = Vector3.zero;
        }
           
    }
    /*
        DELETE
          
            float timerThrow = (object.position - targetPosition).magnitude;
            float cTime = timerThrow;
            Vector3 startPos = object.position;
            while ((object.position - targetPosition).sqrMagnitude &gt; 0.01F)
            {
                cTime -= 0.4F;
                object.position = Vector3.Slerp(targetPosition, startPos, cTime / timerThrow);
                yield return 0;
            }







         void Update () {
         // calculate current time within our lerping time range
         float cTime = Time.time * 0.2f;
         // calculate straight-line lerp position:
         Vector3 currentPos = Vector3.Lerp(startPos, endPos, cTime);
         // add a value to Y, using Sine to give a curved trajectory in the Y direction
         currentPos.y += trajectoryHeight * Mathf.Sin(Mathf.Clamp01(cTime) * Mathf.PI);
         // finally assign the computed position to our gameObject:
         transform.position = currentPos;
     }




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
