using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public List<GameObject> UIPanels;
    public GameObject CalibPanel;
    private ReactionManager ReactionManager;

    // Start is called before the first frame update
    void Start()
    {
        ReactionManager = GameObject.FindObjectOfType<ReactionManager>();
        for (int i = 2; i < UIPanels.Count; i++){
            UIPanels[i].SetActive(false);
        }
    }

    public void Calibrated(){
        UIPanels[0].SetActive(false);
        UIPanels[1].SetActive(false);
        UIPanels[2].SetActive(true);
        CalibPanel.SetActive(false);
    }

    public void BrokenButtonPressed(){
        UIPanels[2].SetActive(false);
        UIPanels[3].SetActive(true);
        ReactionManager.PromptBegin();
    }

}
