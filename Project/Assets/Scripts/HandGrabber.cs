using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OculusSampleFramework;
using TMPro;

public class HandGrabber : OVRGrabber
{
    public GameObject PinchIndicator;
    public GameObject GrabIndicator;
    public TextMeshProUGUI Text;

    private OVRHand hand;
    public float pinchThreshold = 0.7f;
    private bool tmp = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
        PinchIndicator.SetActive(false);
        GrabIndicator.SetActive(false);
    }

    public override void Update(){
        base.Update();
        CheckIndexPinch();
    }
    void CheckIndexPinch(){
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrength > pinchThreshold;
        if (isPinching){
            PinchIndicator.SetActive(true);
        }
        else {
            PinchIndicator.SetActive(false);
        }

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0){
            GrabIndicator.SetActive(true);
            base.GrabBegin();
            tmp = true;
        }
        else if (m_grabbedObj && !isPinching){
            GrabIndicator.SetActive(false);
            base.GrabEnd();
            tmp = false;
        }

        if (m_grabbedObj == null){
            Text.text = tmp.ToString();
        }
        else{
            Text.text = m_grabbedObj.name;
        }
    }
}
