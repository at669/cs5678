using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterManager : MonoBehaviour
{
    private int numTouches = 0;
    public TextMeshProUGUI num;
    private bool entered = false;

    // Start is called before the first frame update
    void Start()
    {
        num.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider){
        entered = true;
    }

    void OnTriggerExit(Collider collider){
        if (entered){
            numTouches++;
            num.text = numTouches.ToString();
            entered = false;
        }
        
    }
}
