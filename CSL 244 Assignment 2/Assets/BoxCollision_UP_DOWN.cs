using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollision_UP_DOWN : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("GoUP",true);
            print("player");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("GoUP",false);
        }
    }
}
