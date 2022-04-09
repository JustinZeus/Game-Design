using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int current_health; 
    public float movement_speed;

    public GameObject globalStatic;
    public GlobalStats globalStats;

    public GameObject hatModel;

    public ShootController shootController;
    public int gunType;

    public bool hat;

    // Start is called before the first frame update
    void Start()
    {       
        globalStatic = GameObject.Find("GlobalStatic");
        globalStats = globalStatic.GetComponent<GlobalStats>();
        shootController = GetComponent<ShootController>();
        hat = globalStats.hatUnlocked;
        if(hat)
        {
            hatModel.SetActive(true);
        }
        PullStats();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("g"))
       {
           current_health -= 2;
           PushStats();
       }
    }

    public void PushStats()
    {
        globalStats.health = health;
        globalStats.current_health = current_health;
        globalStats.movement_speed = movement_speed;
        globalStats.gunType = gunType;
    }

    void PullStats()
    {
        health = globalStats.health;
        current_health = globalStats.current_health;
        movement_speed = globalStats.movement_speed;
        gunType = globalStats.gunType;
        shootController.gunType = gunType;
    }

    public void UpdateStats(int _health, int _extra_health, float _movement_speed)
    {
        if(_health != -1) {health = _health;}
        if(_extra_health != -1) {current_health += _extra_health;}
        if(_movement_speed != -1) {movement_speed = _movement_speed;}
        PushStats();
    }
}
