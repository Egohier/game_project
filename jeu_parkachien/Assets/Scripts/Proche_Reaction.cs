using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proche_Reaction : MonoBehaviour {

    [HideInInspector]
    public Animator anim;

    public float range = 1.4f;
    GameObject genevieve;

    public bool isDying = false;
    float timer = 0.0f;
    const float timeAnimRolling = 5.0f;

    float doggoScale = 0.5435f;
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

        if (isDying)
        {
            timer += Time.deltaTime / 1.0f;
            this.transform.localScale = new Vector3(Mathf.Lerp(doggoScale, 0.0f, timer), Mathf.Lerp(doggoScale, 0.0f, timer), Mathf.Lerp(doggoScale, 0.0f, timer));

            Destroy(gameObject, timeAnimRolling);


        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
