using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealhBar : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats stats;
    public Slider slider;

    void Start()
    {
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
