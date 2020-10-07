using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidbody;

    [Tooltip("Enabled: W,A,S,D controls" + "\n" + "Disabled: Controlled by the mouse")]
    public bool ControlledByButtons;
    public float speed;

    float yValue;
    Vector3 lastPosition;

    float Horizontal;
    float Vertical;

    void Start()
    {
        yValue = transform.position.y;
        myRigidbody = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        //Controlled by Buttons
        if (ControlledByButtons)
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }

        //Controlled by Mouse
        else
        {
            Horizontal = Input.GetAxisRaw("Mouse X");
            Vertical = Input.GetAxisRaw("Mouse Y");
        }

        Vector3 move = new Vector3(Horizontal, 0, Vertical);
        myRigidbody.velocity = move * speed;

        lastPosition = transform.position;

        if (transform.position.y != yValue)
            transform.position = new Vector3(lastPosition.x, yValue, lastPosition.z);
    }
}
