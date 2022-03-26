using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats stats;
    public GameObject globalStatic;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        globalStatic = GameObject.Find("GlobalStatic");
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.current_health <= 0)
        {
            
            Destroy(this.gameObject, 0.5f);
            Destroy(globalStatic);

            SceneManager.LoadScene("Select");
        }
    }

    public void HitPlayer(int damage)
    {
        stats.current_health -= damage;
        stats.PushStats();
    }
}
