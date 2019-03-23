using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proche_Reaction : MonoBehaviour {

    static Animator anim;
    public float range = 1.4f;
    public Transform genevieve;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();	
        
	}
	
	// Update is called once per frame
	void Update () {

        float distanceToGenevieve = Vector3.Distance(transform.position, genevieve.transform.position);
        if ((distanceToGenevieve) <= range) {
            transform.LookAt(genevieve);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            anim.SetBool("Proche", true);
        }
        else
        {
            anim.SetBool("Proche", false);
        }
        		
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
