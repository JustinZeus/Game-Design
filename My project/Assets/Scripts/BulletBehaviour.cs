using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed = 5f;
    [SerializeField] public Vector3 m_Input; 

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);  
    }
}
