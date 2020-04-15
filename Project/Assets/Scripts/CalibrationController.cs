using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using OculusSampleFramework;
// using UnityEngine.SceneManagement;

public class CalibrationController : MonoBehaviour
{
    public GameObject EnvParent;
    public GameObject CalibrationCube;
    public GameObject ButtonPanel;
    public Vector3 CalibrationOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalibrationButtonPressed(InteractableStateArgs obj)
		{
			if (obj.NewInteractableState == InteractableState.ActionState)
			{
                CalibrationCube.SetActive(false);
                ButtonPanel.SetActive(false);

                EnvParent.transform.position = new Vector3(CalibrationCube.transform.position.x + CalibrationOffset.x, CalibrationCube.transform.position.y + CalibrationOffset.y, CalibrationCube.transform.position.z + CalibrationOffset.z);
			}
		}
}
