using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.current_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HitPlayer(int damage)
    {
        stats.current_health -= damage;
        stats.PushStats();
    }
}
