using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats GS;
    public int health;
    public int current_health;
    public float movement_speed;

    void start()
    {
        health = 10;
        current_health = health;
        movement_speed = 7.0f;
    }

    void Awake()
     {
        if(GS != null)
                GameObject.Destroy(GS);
            else
                GS = this;
            
            DontDestroyOnLoad(this);
     }
}
