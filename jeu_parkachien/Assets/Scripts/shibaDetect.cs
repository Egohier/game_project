using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shibaDetect : MonoBehaviour {

    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int shibaMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    public float genevieveRayLength = 1.0f;          // The length of the ray from the camera into the scene.
    GameObject genevieve;
    GameObject shiba;

    void Awake()
    {
        // Create a layer mask for the floor layer.
        shibaMask = LayerMask.GetMask("Shiba");

        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        shiba = GetComponent<GameObject>();
        genevieve = GetComponent<GameObject>();
    }

    void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Detect()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit shibaHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out shibaHit, genevieveRayLength, shibaMask))
        {

        }
    }

}
