using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    static Animator anim;
    public float movementSpeed = 1.0f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;

    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            movementSpeed = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
            movementSpeed = 0.3f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }

    void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}

