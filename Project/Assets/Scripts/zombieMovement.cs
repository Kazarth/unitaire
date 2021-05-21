using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class zombieMovement : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private GameObject m_target;
    private float m_updateTime = 0.2f;

    private Animator animator;



    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_target = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(UpdateZombie());
        animator = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        if (!m_agent)
            return;

        if (m_agent.isStopped == false)
        {
            Gizmos.color = Color.red;
            foreach (var point in m_agent.path.corners)
            {
                Gizmos.DrawSphere(point, 0.25f);
            }
        }
    }

    private void OnTriggerEnter(Collider col)

    {
        if (col.gameObject.tag == "ZombieWall")

        {
            animator.SetTrigger("AttackTrigger");
        }

        
    }

    IEnumerator UpdateZombie()
    {
        WaitForSeconds wait = new WaitForSeconds(m_updateTime);
        while (true)
        {

            yield return wait;
            m_agent.SetDestination(m_target.transform.position);

        }
    }
}


