using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Enemies")
        {
            Destroy(collision.gameObject);
        }
        Destroy(this.gameObject);
    }
}