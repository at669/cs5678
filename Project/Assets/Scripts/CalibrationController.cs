using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using OculusSampleFramework;
// using UnityEngine.SceneManagement;

public class CalibrationController : MonoBehaviour
{
    public GameObject TablePlane;
    public GameObject CalibrationCube;
    public GameObject ButtonPanel;

    // Start is called before the first frame update
    void Start()
    {
        // PlaneLevel = TablePlane.transform.position;
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

                TablePlane.transform.position = CalibrationCube.transform.position;
                // TablePlane.transform.rotation = new Quaternion(TablePlane.transform.rotation.x, CalibrationCube.transform.rotation.y, TablePlane.transform.rotation.z, 1);
			}
		}
}
