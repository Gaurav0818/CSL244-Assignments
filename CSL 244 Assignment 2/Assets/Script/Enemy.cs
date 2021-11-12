using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public GameObject player;
    public float detectRange;
    public float fallowRange;
    public float attackRange;
    public bool enemyDetected = false;
    public CustomCharacterController charChr;


    public int gizmosType = 0;
    // 0 = green
    // 1 = yellow
    // 2 = red

    private void Update()
    {
        EnemyAI();
        EnemyMovement();
        
        if (enemyDetected) animator.SetBool("FallowMode",true);
        else animator.SetBool("FallowMode",false);
    }


    #region - Enemy AI / Movement -
    
    private void EnemyAI()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= detectRange)
        {
            DetectAngle();
            DetectSound();
            
        }

        if (distance > fallowRange)
        {
            enemyDetected = false;
            gizmosType = 0;
        }
        
    }

    private void DetectAngle()
    {
        Vector3 targetAngle = player.transform.position - transform.position;
        float angle = Vector3.Angle(targetAngle, transform.forward);

        if (angle < 30.0f || angle > 330f)
        {
            enemyDetected = true;
            gizmosType = 2;
        }
        else
        {
            if(!enemyDetected)
                gizmosType = 1;
        }
    }

    private void DetectSound()
    {
        if (charChr.shiftPressed)
        {
            enemyDetected = true;
            gizmosType = 2;
        }
    }

    private void EnemyMovement()
    {
        if (enemyDetected == true)
        {
            agent.SetDestination(player.transform.position);
        }

        if (enemyDetected == false)
        {
            agent.SetDestination(transform.position);

        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (gizmosType == 0)
        {
            Gizmos.color=Color.green;
        }
        else if (gizmosType == 1)
        {
            Gizmos.color = Color.yellow;
        }
        else if(gizmosType == 2)
        {
            Gizmos.color=Color.red;
        }
        
        
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
    #endregion
}
