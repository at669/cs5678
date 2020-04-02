using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OculusSampleFramework;
using TMPro;

public class HandGrabber : OVRGrabber
{
    public float pinchThreshold = 0.7f;
    private OVRHand hand;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    public override void Update(){
        base.Update();
        CheckIndexPinch();
    }
    void CheckIndexPinch(){
        float pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrength > pinchThreshold;

        if (!m_grabbedObj && isPinching && m_grabCandidates.Count > 0){
            base.GrabBegin();
        }
        else if (m_grabbedObj && !isPinching){
            base.GrabEnd();
        }
    }
}
