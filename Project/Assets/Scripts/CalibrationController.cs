using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using OculusSampleFramework;
// using UnityEngine.SceneManagement;
using TMPro;

public class CalibrationController : MonoBehaviour
{
	public GameObject EnvParent;				// Holder for scene objects
	public GameObject ButtonPanel;				// Calibration button panel
    public GameObject ParentCube;				// Root object that aligns with table
    public Vector3 CalibrationOffset;			// Manual offset assignment
    public OVRHand lefthand;					// Left hand OVR object
    public OVRHand righthand;					// Right hand OVR object
	public GameObject ButtonHolders;			// Stovetop control buttons
	private KnobController KnobController;		// Knob controller (to set button interactivity)
	private bool isCalib = false;				// True if calibration button pressed
	private bool hasPinchedOnce = false;		// True if calibration began 
	private TutorialManager TutorialManager;

    // Start is called before the first frame update
    void Start()
    {
		// Connect object references
		TutorialManager = GameObject.FindObjectOfType<TutorialManager>();
		KnobController = GameObject.FindObjectOfType<KnobController>();
		// ButtonHolders.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (!isCalib){ // Prevent button press from raycast

			// Calculate angle between hands, table
			Vector3 betweenHands = lefthand.PointerPose.position - righthand.PointerPose.position;
			Vector3 tableLine = ParentCube.transform.position - new Vector3(ParentCube.transform.position.x + 0.6f, ParentCube.transform.position.y, ParentCube.transform.position.z);
			float ang0 = Vector2.SignedAngle(new Vector2(tableLine.z, tableLine.x), new Vector2(betweenHands.z, betweenHands.x));

			// Check if two handed pinch
			if (lefthand.GetFingerIsPinching(OVRHand.HandFinger.Index) && righthand.GetFingerIsPinching(OVRHand.HandFinger.Index)){
				hasPinchedOnce = true;

				// Move and angle scene accordingly
				ParentCube.transform.position = new Vector3(lefthand.PointerPose.position.x + CalibrationOffset.x, lefthand.PointerPose.position.y + CalibrationOffset.y, lefthand.PointerPose.position.z + CalibrationOffset.z);
				ParentCube.transform.localEulerAngles = new Vector3(0, ang0, 0);
			}
		}
    }

	// Turn off pinch calibration assignment
    public void CalibrationButtonPressed(InteractableStateArgs obj)
    {
		if (hasPinchedOnce){
			if (obj.NewInteractableState == InteractableState.ActionState){
				ButtonPanel.SetActive(false);
				isCalib = true;
				TutorialManager.Calibrated();
				KnobController.Calibrated();
				ButtonHolders.SetActive(true);
			}
		}
    }
}
