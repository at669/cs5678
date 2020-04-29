using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OculusSampleFramework;

public class KnobController : MonoBehaviour
{
    private TutorialManager TutorialManager;
    private Transform EnvParent;
    private List<GameObject> StoveList = new List<GameObject>();
    public Material StoveTopMat;
    private float[] tmpGlow = new float[]{0, 0, 0, 0};

    // Start is called before the first frame update
    void Start()
    {
        TutorialManager = GameObject.FindObjectOfType<TutorialManager>();
        EnvParent = GameObject.FindGameObjectWithTag("EnvParent").transform;
        for (int i = 0; i < EnvParent.Find("StoveParent/Stove/Stoves").transform.childCount; i++){
            StoveList.Add(EnvParent.Find("StoveParent/Stove/Stoves").transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int idx = -1; //
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            idx = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            idx = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            idx = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            idx = 3;
        }
        if (idx != -1){
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] < 3){ // less thanhigh
                tmpGlow[idx] += 1f;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void UpButton0(InteractableStateArgs obj)
    {
        int idx = 0;
        if (obj.NewInteractableState == InteractableState.ActionState){
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] < 3){ // less thanhigh
                tmpGlow[idx]++;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void UpButton1(InteractableStateArgs obj)
    {
        int idx = 1;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Up");
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] < 3){ // less thanhigh
                tmpGlow[idx]++;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void UpButton2(InteractableStateArgs obj)
    {
        int idx = 2;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Up");
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] < 3){ // less thanhigh
                tmpGlow[idx]++;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void UpButton3(InteractableStateArgs obj)
    {
        int idx = 3;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Up");
            TutorialManager.BrokenButtonPressed();
            // var renderer = StoveList[idx].GetComponent<Renderer>();
            // if (tmpGlow[idx] < 3){ // less thanhigh
            //     tmpGlow[idx]++;
            // }
            // float newRed = tmpGlow[idx] / 3;
            // renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void DownButton0(InteractableStateArgs obj)
    {
        int idx = 0;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Down");
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] > 0){ // less thanhigh
                tmpGlow[idx]--;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void DownButton1(InteractableStateArgs obj)
    {
        int idx = 1;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Down");
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] > 0){ // less thanhigh
                tmpGlow[idx]--;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void DownButton2(InteractableStateArgs obj)
    {
        int idx = 2;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Down");
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] > 0){ // less thanhigh
                tmpGlow[idx]--;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }

    public void DownButton3(InteractableStateArgs obj)
    {
        int idx = 3;
        if (obj.NewInteractableState == InteractableState.ActionState){
            Debug.Log("Down");
            var renderer = StoveList[idx].GetComponent<Renderer>();
            if (tmpGlow[idx] > 0){ // less thanhigh
                tmpGlow[idx]--;
            }
            float newRed = tmpGlow[idx] / 3;
            renderer.material.color = new Color(newRed, 0, 0);
        }
    }
}
