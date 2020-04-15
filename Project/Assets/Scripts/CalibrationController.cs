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
    public GameObject TestCube;
    // public GameObject CalibrationCube;
    // public GameObject ButtonPanel;
    public Vector3 CalibrationOffset;
    public OVRHand lefthand;
    public OVRHand righthand;
	// public TextMeshProUGUI LeftText;
	// public TextMeshProUGUI RightText;
	// public TextMeshProUGUI ArcTanText;
	// public TextMeshProUGUI ArcTanText1;
	// public TextMeshProUGUI ArcTanText2;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		// LeftText.text = lefthand.PointerPose.position.x.ToString("n2") + " " + lefthand.PointerPose.position.y.ToString("n2") + " " + lefthand.PointerPose.position.z.ToString("n2");
		// RightText.text = righthand.PointerPose.position.x.ToString("n2") + " " + righthand.PointerPose.position.y.ToString("n2") + " " + righthand.PointerPose.position.z.ToString("n2");

		Vector3 betweenHands = lefthand.PointerPose.position - righthand.PointerPose.position;
		Vector3 tableLine = TestCube.transform.position - new Vector3(TestCube.transform.position.x + 0.6f, TestCube.transform.position.y, TestCube.transform.position.z);
		float ang0 = Vector2.SignedAngle(new Vector2(tableLine.z, tableLine.x), new Vector2(betweenHands.z, betweenHands.x));

		// ArcTanText.text = ang0.ToString("n2");
		

		if (lefthand.GetFingerIsPinching(OVRHand.HandFinger.Index) && righthand.GetFingerIsPinching(OVRHand.HandFinger.Index)){
			// TestCube.transform.position = lefthand.PointerPose.position;
			TestCube.transform.position = new Vector3(lefthand.PointerPose.position.x + CalibrationOffset.x, lefthand.PointerPose.position.y + CalibrationOffset.y, lefthand.PointerPose.position.z + CalibrationOffset.z);
			TestCube.transform.localEulerAngles = new Vector3(0, ang0, 0);
		}
    }

    // public void CalibrationButtonPressed(InteractableStateArgs obj)
    // {
	// 	if (obj.NewInteractableState == InteractableState.ActionState){
	// 		CalibrationCube.SetActive(false);
	// 		ButtonPanel.SetActive(false);

	// 		EnvParent.transform.position = new Vector3(CalibrationCube.transform.position.x + CalibrationOffset.x, CalibrationCube.transform.position.y + CalibrationOffset.y, CalibrationCube.transform.position.z + CalibrationOffset.z);
	// 	}
    // }
}
