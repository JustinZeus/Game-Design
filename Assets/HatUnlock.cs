using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatUnlock : MonoBehaviour
{
    public GameObject globalStatic;
    public GlobalStats globalStats;


    void Start()
    {
        globalStatic = GameObject.Find("GlobalStatic");
        globalStats = globalStatic.GetComponent<GlobalStats>();
    }


    void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
            globalStats.hatUnlocked = true;
            other.GetComponent<PlayerStats>().hatModel.SetActive(true);
            Destroy(gameObject);
            }
        }
}
