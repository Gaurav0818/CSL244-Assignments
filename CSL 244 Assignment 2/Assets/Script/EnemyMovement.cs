using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float detectRange;
    public float fallowRange;
    public float attackRange;
    public bool enemyDetected = false;


    public int gizmosType = 0;
    // 0 = green
    // 1 = yellow
    // 2 = red

    private void Update()
    {
        EnemyAI();
        EnemyMovmt();
    }


    #region - Enemy AI / Movement -
    
    private void EnemyAI()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= detectRange)
        {
            DetectAngle();
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
    

    private void EnemyMovmt()
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
