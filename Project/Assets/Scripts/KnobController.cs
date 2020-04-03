using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KnobController : MonoBehaviour
{
    private List<GameObject> KnobList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        KnobList = GameObject.FindGameObjectsWithTag("Knob").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateKnobs(float[] val){
        for (int i = 0; i < KnobList.Count; i++){
            KnobList[i].transform.rotation = new Quaternion(KnobList[i].transform.rotation.x, KnobList[i].transform.rotation.y, val[i], 1);
        }
    }
}
