using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAndDetection : MonoBehaviour
{
    public GameObject headlight1;
    public GameObject headlight2;
    public LayerMask layerInteractable;
    public LayerMask layerCollectable;


    public float detectRange;


    private void Update()
    {
        RaycastForDetection();
    }

    private void RaycastForDetection()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, detectRange, layerInteractable))
        {
            headlight1.GetComponent<Light>().color=Color.green;
            headlight2.GetComponent<Light>().color=Color.green;
        }
        else if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out hit,detectRange,layerCollectable))
        {
            headlight1.GetComponent<Light>().color=Color.yellow;
            headlight2.GetComponent<Light>().color=Color.yellow;
        }
        else
        {
            headlight1.GetComponent<Light>().color=Color.white;
            headlight2.GetComponent<Light>().color=Color.white;
        }
    }
}
