using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Projectile : MonoBehaviour
{
    [SerializeField] float m_velocity;
    [SerializeField] Rigidbody m_rigidBody;
    [SerializeField] float m_life;

    private void Start()
    {
        m_rigidBody.velocity += transform.forward * m_velocity;
        StartCoroutine(EndMe());
    }

    private IEnumerator EndMe()
    {
        yield return new WaitForSeconds(m_life);
        Destroy(gameObject);
    }
}
