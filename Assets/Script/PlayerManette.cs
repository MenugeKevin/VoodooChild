using UnityEngine;
using System.Collections;
using System;

public class PlayerManette : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerController>().isGrounded())
        {
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            transform.Rotate(0, rotation, 0);
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                GetComponent<PlayerController>().setJumping(true);
                Debug.Log("Jump");
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ActivableObject")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
                other.GetComponent<IActivableObject>().OnAction();
        }
    }

    public float rotationSpeed = 100.0F;
}
