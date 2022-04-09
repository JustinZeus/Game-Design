using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealhBar : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    public PlayerStats stats;
    public Slider slider;

    void Start()
    {
        player = GameObject.Find("Player");
        stats = player.GetComponent<PlayerStats>();
        slider.maxValue = stats.health;
        slider.value = stats.current_health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = stats.health;
        slider.value = stats.current_health;
    }
}
