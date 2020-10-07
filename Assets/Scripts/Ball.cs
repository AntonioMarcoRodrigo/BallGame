using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IPooledObject
{
    public int initialSpeed;//500
    public int maxSpeed;    //50
    Rigidbody myRigidbody;
    bool rigidbodyCalculated;
    float deviation;

    public void OnObjectSpawn()
    {
        myRigidbody = GetComponent<Rigidbody>();
        deviation = Random.Range(-1f, 1f);
        myRigidbody.AddRelativeForce((transform.forward + new Vector3(transform.forward.x, transform.forward.y, transform.forward.z + deviation)) * initialSpeed);
        rigidbodyCalculated = false;
    }

    void FixedUpdate()
    {
        if (rigidbodyCalculated == false)
        {
            myRigidbody = GetComponent<Rigidbody>();
            rigidbodyCalculated = true;
        }

        if (myRigidbody.velocity.magnitude > maxSpeed)
        {
            myRigidbody.velocity = myRigidbody.velocity.normalized * maxSpeed;
        }       
    }
}
