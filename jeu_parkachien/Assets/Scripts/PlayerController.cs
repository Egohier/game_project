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

    bool dogInRange = false;
    bool clickPat = false;

    void Start()
    {
        anim = GetComponent<Animator> ();
        GameManager.instance.SetCursorState();
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

        if (dogInRange && clickPat && timerCaresse <= timerTime)
        {
           timerCaresse += Time.deltaTime / timerTime;
           Debug.Log("Regarde moi m'incrémenter ! : " + timerCaresse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
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
            Debug.Log("tu m'a cliquer dessus olala");
            clickPat = true;
        }

        if (dogInRange && clickPat && timerCaresse > timerTime)
        {
            //todo : faire l'anim bien parce uqe j'y connais pas grand chose
            other.GetComponent<Proche_Reaction>().anim.SetBool("Proche", false);
            anim.SetBool("Caresse", true);
            Debug.Log("J'ai attendu une second");
            other.GetComponent<Proche_Reaction>().anim.SetBool("Congratulations", true);
            timerCaresse = 0.0f;
            clickPat = false;
        }

        //if (other.transform.tag == "Dog")
        //{
        //    other.transform.LookAt(this.transform);
        //    other.transform.eulerAngles = new Vector3(0, other.transform.eulerAngles.y, 0);
        //}
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

