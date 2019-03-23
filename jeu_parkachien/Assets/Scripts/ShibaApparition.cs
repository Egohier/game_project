using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShibaApparition : MonoBehaviour
{

    [SerializeField]
    GameObject[] shibas;

    // Start is called before the first frame update
    void Start()
    {
        int result = Random.Range(0, shibas.Length);

        if (result <= shibas.Length)
        {
            GameObject go = Instantiate(shibas[result]);
            go.transform.position = this.transform.position;
        }
    }
}
