using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KnobController : MonoBehaviour
{
    private Transform EnvParent;
    private List<GameObject> KnobList = new List<GameObject>();
    private List<Light> GlowList = new List<Light>();
    private float[] tmpTurns = new float[]{0, 0, 0, 0};

    // Start is called before the first frame update
    void Start()
    {
        EnvParent = GameObject.FindGameObjectWithTag("EnvParent").transform;
        for (int i = 0; i < EnvParent.Find("StoveParent/Stove/Knobs").transform.childCount; i++){
            KnobList.Add(EnvParent.Find("StoveParent/Stove/Knobs").transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < EnvParent.Find("StoveParent/Stove/Glows").transform.childCount; i++){
            GlowList.Add(EnvParent.Find("StoveParent/Stove/Glows").transform.GetChild(i).GetComponent<Light>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            tmpTurns[0] += 1;
            tmpTurns = UpdateKnobs(tmpTurns);
        }
        if (Input.GetKey(KeyCode.S)){
            tmpTurns[1] += 1;
            tmpTurns = UpdateKnobs(tmpTurns);
        }
        if (Input.GetKey(KeyCode.D)){
            tmpTurns[2] += 1;
            tmpTurns = UpdateKnobs(tmpTurns);
        }
        if (Input.GetKey(KeyCode.F)){
            tmpTurns[3] += 1;
            tmpTurns = UpdateKnobs(tmpTurns);
        }
        // for (int i = 0; i < tmpTurns.Length; i++){
        //     Debug.Log(i + " " + tmpTurns[i] + " " + KnobList[i].transform.localEulerAngles.z);
        // }
    }

    public float[] UpdateKnobs(float[] val){
        for (int i = 0; i < KnobList.Count; i++){
            // KnobList[i].transform.Rotate(KnobList[i].transform.rotation.x, KnobList[i].transform.rotation.y, val[i])
            KnobList[i].transform.Rotate(0, 0, val[i]);
            // Debug.Log("val " + val[i] + " " + KnobList[i].transform.eulerAngles);
            GlowList[i].intensity = KnobList[i].transform.localEulerAngles.z / 360 * 500;
            val[i] = 0;
        }
        return val;
    }
}
