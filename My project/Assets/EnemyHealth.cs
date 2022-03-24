using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    void Start()
    {
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) Destroy(gameObject);
    }
    public void HitEnemy(float damage)
    {
        health -= damage;
    }
}
