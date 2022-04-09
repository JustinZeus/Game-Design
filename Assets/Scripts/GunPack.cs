using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPack : MonoBehaviour
{
    public float degreesPerSecond = 1.0f;
    public float amplitude = 0.01f;
    public float frequency = 0.75f;

    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();

    public int type;

    void Start()
    {
        posOffset = transform.position;
    }

   
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
 
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
          other.GetComponent<ShootController>().NextGun(type);
          Destroy(gameObject);
        } 
    }
}
