using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterManager : MonoBehaviour
{
    public int id;                      // Which stove this is
    private int numTouches = 0;         // Number of times collider entered
    private KnobController KnobController;  // To get Level
    public TextMeshProUGUI num;         // TMPro object
    private string level;               // Holder for level string
    private bool entered = false;       // Determines if exit valid
    public TextMeshProUGUI lvltext;     // TMPro object for debugging and data
    private SphereCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        // Clear text on start
        num.text = "";
        lvltext.text = "";

        // Connect object references
        KnobController = GameObject.FindObjectOfType<KnobController>();

        collider = this.GetComponent<SphereCollider>();
        collider.enabled = false;
    }

    // Begin valid entry
    void OnTriggerEnter(Collider collider){
        entered = true;
        level = KnobController.GetLevelBroken(id);
    }

    // Exit, increment number of touches if valid
    void OnTriggerExit(Collider collider){
        if (entered){
            numTouches++;
            num.text = numTouches.ToString();
            lvltext.text = level;
            entered = false;
        }
        
    }
}
