using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DistanceJoint2D))]
public class Grappler : MonoBehaviour
{
    [Tooltip("The distance the character needs to be from the grapple hook")]
    public float grappleRange;

    [Tooltip("The point on the character for the grappling hand")]
    public Transform grappleHand;

    [Tooltip("The Layers containg the hooks")]
    public LayerMask hooksLayer;

    public LineRenderer rope;

    public KeyCode grappleKey;

    private DistanceJoint2D distanceJoint;

    private GrappleHook hook;

    private GolemController player;

    void Start()
    {
        player = GetComponent<GolemController>();

        this.distanceJoint = GetComponent<DistanceJoint2D>();
        this.distanceJoint.distance = this.grappleRange;
        this.distanceJoint.autoConfigureDistance = false;
        this.distanceJoint.maxDistanceOnly = true;
        this.rope.enabled = false;
        this.rope.useWorldSpace = true;

        UnGrapple();
    }


    void Update()
    {
        bool grappling = Input.GetKey(grappleKey);

        if (grappling)
        {
        
            if (hook == null)
            {
                hook = ScanForGrappleHook();
            }


            if (hook != null && grappling)
            {
                Grapple();
            }
        }
        else if (!grappling)
        {
            UnGrapple();
        }



    }

    private void UnGrapple()
    {
        this.distanceJoint.enabled = false;
        this.distanceJoint.connectedBody = null;
        this.hook = null;

        this.rope.enabled = false;
    }

    private GrappleHook ScanForGrappleHook()
    {
        Collider2D[] detectedHooks = Physics2D.OverlapCircleAll(this.grappleHand.position, this.grappleRange, this.hooksLayer);

        float nearestDistance = this.grappleRange;

        GrappleHook nearestHook = null;

        foreach (Collider2D hookCollider in detectedHooks)
        {

            bool hookInFront = false;

            if (player.facingRight)
            {
                if (hookCollider.transform.position.x > this.transform.position.x)
                {
                    hookInFront = true;
                }
            }
            else
            {
                if (hookCollider.transform.position.x < this.transform.position.x)
                {
                    hookInFront = true;
                }
            }

            if (hookInFront)
            {
                float distanceToHook = Vector2.Distance(this.grappleHand.position, hookCollider.transform.position);

                if (distanceToHook < nearestDistance)
                {
                    nearestDistance = distanceToHook;
                    nearestHook = hookCollider.GetComponent<GrappleHook>();
                }
            }
        }

        return nearestHook;
    }

    private void Grapple()
    {
        this.distanceJoint.connectedBody = hook.GetComponent<Rigidbody2D>();

        this.distanceJoint.enabled = true;

        this.rope.SetPosition(0, this.grappleHand.position);
        this.rope.SetPosition(1, this.hook.transform.position);

        this.rope.enabled = true;

    }


}