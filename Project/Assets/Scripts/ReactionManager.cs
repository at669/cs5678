using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReactionManager : MonoBehaviour
{
    private float firstTouchTime = 0;
    private float heldTime = 0;
    private bool promptBegan = false;
    private bool firstTouchBool = true;
    private bool touched = false;
    public TextMeshProUGUI firsttouch;
    public TextMeshProUGUI time;
    private bool entered = false;
    
    // Start is called before the first frame update
    void Start()
    {
        firsttouch.text = "";
        time.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (promptBegan && !touched){
            firstTouchTime += Time.deltaTime;
        }

        if (touched && firstTouchBool){
            heldTime += Time.deltaTime;
        }
        
    }

    void OnTriggerEnter(Collider collider){
        touched = true;
        entered = true;
    }

    void OnTriggerExit(Collider collider){
        if (entered){
            firstTouchBool = false;
            firsttouch.text = firstTouchTime.ToString("f2");
            time.text = heldTime.ToString("f2");
        }
    }

    public void PromptBegin(){
        promptBegan = true;
    }
}
