using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GrapplingGun : MonoBehaviour
{
 
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatisGrappleable;
    public Transform guntip, gunCamera, player;
    private float maxDistance = 50f;
    private SpringJoint joint;
    private Vector3 currentGrapplePosition;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunCamera.position, gunCamera.forward, out hit, maxDistance, whatisGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.4f;
            joint.minDistance = distanceFromPoint * 0.25f;


            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            //movement.airMultiplier = 4;

        }
    }

    private void DrawRope()
    {
        if (!joint) return; 

        lr.SetPosition(0, guntip.position);
        lr.SetPosition(1, grapplePoint);
    }


    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

}
