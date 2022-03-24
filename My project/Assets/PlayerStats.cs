using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float max_health;
    public float health;
    public float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
