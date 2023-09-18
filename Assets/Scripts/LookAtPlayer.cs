using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Transform Camera;

    Quaternion newRot;


    private void Update()
    {
        Vector3 targetDirection = player.position - Camera.position;
        newRot = Quaternion.LookRotation(targetDirection, Vector3.up);

        Camera.rotation = newRot;
    }
}
