using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float spawntime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        spawntime = Time.time;
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.time - spawntime) > 10f) Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemies"){
            collision.gameObject.GetComponent<EnemyHealth>().HitEnemy(damage);
        }
        Destroy(this.gameObject);
    }
}
