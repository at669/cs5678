using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using OculusSampleFramework;

public class CalibrationController : MonoBehaviour
{
    public GameObject TablePlane;
    public GameObject CalibrationCube;
    private Vector3 PlaneLevel;

    // Start is called before the first frame update
    void Start()
    {
        PlaneLevel = TablePlane.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalibrationButtonPressed(InteractableStateArgs obj)
		{
			if (obj.NewInteractableState == InteractableState.ActionState)
			{
				// _locomotive.StartStopStateChanged();
                CalibrationCube.SetActive(false);
                PlaneLevel.y = CalibrationCube.transform.position.y;
                TablePlane.transform.position = PlaneLevel;
			}
		}
}
