using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepAndGroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    private void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
