using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;
    public float movementSpeed = 1.0f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;

    float timerCaresse = 0.0f;
    const float timerTime = 1.0f;
    float timerDie = 0.0f;
    const float timerAnim = 5.0f;

    bool dogInRange = false;
    bool clickPat = false;
    bool dieDoggo = false;

    Proche_Reaction currentDoggo;

    void Start()
    {
        anim = GetComponent<Animator> ();
        if (null != GameManager.instance)
        {
            GameManager.instance.SetCursorState();
        }
    }

    void Update()
    {
        if (!clickPat)
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

        if (dogInRange && clickPat && timerCaresse <= timerTime)
        {
           timerCaresse += Time.deltaTime / 1.0f;
        }
        if (dieDoggo)
        {
            timerDie += Time.deltaTime / 1.0f;

            if (timerDie > timerAnim)
            {
                currentDoggo.isDying = true;
                timerDie = 0.0f;
                dieDoggo = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        currentDoggo = other.GetComponent<Proche_Reaction>();
        if (other.transform.tag == "Dog")
        {
            dogInRange = true;            
            CanvasManager.pattingDogText.enabled = true;
            other.GetComponent<Proche_Reaction>().anim.SetBool("Proche", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!clickPat && Input.GetMouseButtonDown(0))
        {
            clickPat = true;
            anim.SetBool("Caresse", true);
            CanvasManager.pattingDogText.enabled = false;
            other.GetComponent<Proche_Reaction>().anim.SetBool("Congratulations", true);
        }

        if (dogInRange && clickPat && timerCaresse > timerTime)
        {
            anim.SetBool("Caresse", false);
            other.GetComponent<Proche_Reaction>().anim.SetBool("Proche", false);
            timerCaresse = 0.0f;
            clickPat = false;            
            dieDoggo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Dog")
        {
            dogInRange = false;
            other.GetComponent<Proche_Reaction>().anim.SetBool("Proche", false);
            CanvasManager.pattingDogText.enabled = false;
        }
    }

}

