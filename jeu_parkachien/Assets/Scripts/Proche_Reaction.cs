using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proche_Reaction : MonoBehaviour {

    [HideInInspector]
    public Animator anim;

    public float range = 1.4f;
    GameObject genevieve;

	// Use this for initialization
	void Start ()
    {
        genevieve = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();	
        
	}
	
	// Update is called once per frame
	void Update ()
    {

        float distanceToGenevieve = Vector3.Distance(transform.position, genevieve.transform.position);

        if ((distanceToGenevieve) <= range)
        {
            transform.LookAt(genevieve.transform);
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
