using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReactionManager : MonoBehaviour
{
    private float firstTouchTime = 0;           // Time between prompt and first touch
    private float heldTime = 0;                 // Time between first touch and release
    private bool promptBegan = false;           // Bool to start timing first touch
    private bool firstTouchBool = true;         // If first touch is still active
    private bool touched = false;               // If the panel has been touched at all
    public TextMeshProUGUI firsttouch;          // TMPro object for debugging and data
    public TextMeshProUGUI time;                // TMPro object for debugging and data
    private bool entered = false;               // Determines if exit valid
    
    // Start is called before the first frame update
    void Start()
    {
        // Clear text on startup
        firsttouch.text = "";
        time.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Begin first touch and prompt timing
        if (promptBegan && !touched){
            firstTouchTime += Time.deltaTime;
        }

        // Begin first touch hold timing
        if (touched && firstTouchBool){
            heldTime += Time.deltaTime;
        }
        
    }

    // Entering the stovetop collider
    void OnTriggerEnter(Collider collider){
        touched = true;
        entered = true;
    }

    // Exiting the stovetop collider; increment count and time
    void OnTriggerExit(Collider collider){
        if (entered){
            firstTouchBool = false;
            firsttouch.text = firstTouchTime.ToString("f2");
            time.text = heldTime.ToString("f2");
        }
    }

    // Called to start first touch timing
    public void PromptBegin(){
        promptBegan = true;
    }
}
