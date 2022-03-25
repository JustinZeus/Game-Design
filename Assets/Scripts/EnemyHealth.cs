using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    private float current_health;
    public Slider slider;
    void Start()
    {
        current_health = health;
        slider.maxValue = health;
        slider.value = current_health;
    }

    // Update is called once per frame
    void Update()
    {
        if (current_health <= 0) Destroy(gameObject);
    }
    public void HitEnemy(float damage)
    {
        current_health -= damage;
        slider.value = current_health;
    }
}
