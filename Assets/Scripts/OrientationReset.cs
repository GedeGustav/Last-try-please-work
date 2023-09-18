using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationReset : MonoBehaviour
{
    [Header("CameraAngles Controller")]
    public GameObject FirstPersonCam;
    public GameObject TopDownCam;

    void Update()
    {
        if (TopDownCam.activeSelf == true)
            transform.rotation = Quaternion.identity;
    }
}
