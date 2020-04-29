using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using OculusSampleFramework;

public class KnobController : MonoBehaviour
{
    private TutorialManager TutorialManager;                        // Manages onboarding UI
    private Transform EnvParent;                                    // Holder for entire scene objects
    private List<GameObject> StoveList = new List<GameObject>();    // Holds stovetops for color
    public Material StoveTopMat;                                    // Material to change colors
    private float[] tmpGlow = new float[]{0, 0, 0, 0};              // Low/medium/high storage

    // Start is called before the first frame update
    void Start()
    {
        // Connect object references
        TutorialManager = GameObject.FindObjectOfType<TutorialManager>();
        EnvParent = GameObject.FindGameObjectWithTag("EnvParent").transform;
        for (int i = 0; i < EnvParent.Find("StoveParent/Stove/Stoves").transform.childCount; i++){
            StoveList.Add(EnvParent.Find("StoveParent/Stove/Stoves").transform.GetChild(i).gameObject);
        }
    }

    // Button callbacks for each individual button
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

    // Broken button; does not change colors
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
