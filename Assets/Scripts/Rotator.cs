using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float X_Speed = 0f;
    public float Y_Speed = 0f;
    public float Z_Speed = 400f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localEulerAngles += new Vector3(
            this.transform.localEulerAngles.x + X_Speed,
            this.transform.localEulerAngles.y + Y_Speed,
            this.transform.localEulerAngles.z + Z_Speed
        ) * Time.deltaTime;
    }
}
