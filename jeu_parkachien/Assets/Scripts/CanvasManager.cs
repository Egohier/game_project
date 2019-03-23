using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    
    static public Text pattingDogText;
    // Start is called before the first frame update
    void Start()
    {
        pattingDogText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
