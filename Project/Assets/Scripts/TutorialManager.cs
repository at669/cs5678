using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<GameObject> UIPanels;               // Holds Tutorial text panels
    public GameObject CalibPanel;                   // Non-interactive panel above calibration button
    private ReactionManager ReactionManager;        // Manages timing

    // Start is called before the first frame update
    void Start()
    {
        // Connect object references
        ReactionManager = GameObject.FindObjectOfType<ReactionManager>();
        for (int i = 2; i < UIPanels.Count; i++){
            UIPanels[i].SetActive(false);
        }
    }

    // Called when Calibration button pressed, shows buttons
    public void Calibrated(){
        UIPanels[0].SetActive(false);
        UIPanels[1].SetActive(false);
        UIPanels[2].SetActive(true);
        CalibPanel.SetActive(false);
    }

    // Bottom right button pressed, start timing
    public void BrokenButtonPressed(){
        UIPanels[2].SetActive(false);
        UIPanels[3].SetActive(true);
        ReactionManager.PromptBegin();
    }

}
