using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistroyBox : MonoBehaviour
{
    public GameObject gameManager;
    private bool canDistroy = true;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && canDistroy)
        {
            gameManager.GetComponent<BoxCount>().CountIncrease();
            canDistroy = false;
            Destroy(gameObject,1f);
            
        }
    }
}
