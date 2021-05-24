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
    private scoreUpdate score;
    private generateEnemy enemy;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        score = GetComponent<scoreUpdate>();
        enemy = GetComponent<generateEnemy>();
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

        if (col.gameObject.tag == "Arrow")

        {
            animator.SetTrigger("ArrowTrigger");
            m_agent.isStopped = true;
            score.AddScore();
            Invoke("destroyZombie", 2);
            enemy.decrementEnemyCount();
        }
    }

    private void destroyZombie () {
        Destroy(m_agent);
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
