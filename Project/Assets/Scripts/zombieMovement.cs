using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class zombieMovement : MonoBehaviour
{
    private NavMeshAgent m_agent;
    private GameObject m_target;
    private float m_updateTime = 0.2f;

    private void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_target = GameObject.FindGameObjectWithTag("Finish");
        StartCoroutine(UpdateZombie());
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
