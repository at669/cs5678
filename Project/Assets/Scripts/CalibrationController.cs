using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using OculusSampleFramework;
// using UnityEngine.SceneManagement;
using TMPro;

public class CalibrationController : MonoBehaviour
{
	public GameObject EnvParent;
	public GameObject ButtonPanel;
    public GameObject ParentCube;
    public Vector3 CalibrationOffset;
    public OVRHand lefthand;
    public OVRHand righthand;
	private bool isCalib = false;
	private bool hasPinchedOnce = false;
	private TutorialManager TutorialManager;

    // Start is called before the first frame update
    void Start()
    {
		TutorialManager = GameObject.FindObjectOfType<TutorialManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (!isCalib){
			Vector3 betweenHands = lefthand.PointerPose.position - righthand.PointerPose.position;
			Vector3 tableLine = ParentCube.transform.position - new Vector3(ParentCube.transform.position.x + 0.6f, ParentCube.transform.position.y, ParentCube.transform.position.z);
			float ang0 = Vector2.SignedAngle(new Vector2(tableLine.z, tableLine.x), new Vector2(betweenHands.z, betweenHands.x));
			if (lefthand.GetFingerIsPinching(OVRHand.HandFinger.Index) && righthand.GetFingerIsPinching(OVRHand.HandFinger.Index)){
				hasPinchedOnce = true;
				ParentCube.transform.position = new Vector3(lefthand.PointerPose.position.x + CalibrationOffset.x, lefthand.PointerPose.position.y + CalibrationOffset.y, lefthand.PointerPose.position.z + CalibrationOffset.z);
				ParentCube.transform.localEulerAngles = new Vector3(0, ang0, 0);
			}
		}
    }

    public void CalibrationButtonPressed(InteractableStateArgs obj)
    {
		if (hasPinchedOnce){
			if (obj.NewInteractableState == InteractableState.ActionState){
				ButtonPanel.SetActive(false);
				isCalib = true;
				TutorialManager.Calibrated();
			}
		}
    }
}
