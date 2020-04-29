using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterManager : MonoBehaviour
{
    private int numTouches = 0;         // Number of times collider entered
    public TextMeshProUGUI num;         // TMPro object
    private bool entered = false;       // Determines if exit valid

    // Start is called before the first frame update
    void Start()
    {
        // Clear text on start
        num.text = "";
    }

    // Begin valid entry
    void OnTriggerEnter(Collider collider){
        entered = true;
    }

    // Exit, increment number of touches if valid
    void OnTriggerExit(Collider collider){
        if (entered){
            numTouches++;
            num.text = numTouches.ToString();
            entered = false;
        }
        
    }
}
