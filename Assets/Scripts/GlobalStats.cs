using UnityEngine;

public class GlobalStats : MonoBehaviour
{
    public static GlobalStats GS;
    public int health;
    public int current_health;
    public float movement_speed;

    public int gunType;

    public float gunDamage()
    {
        if(gunType == 1)
        {
            return 2.0f;
        }
        else if(gunType == 2)
        {
            return 1.0f;
        }
        else if(gunType == 3)
        {
            return 5.0f;
        }
        else
        {
            return 1.0f;
        }
    }

    void start()
    {
        health = 10;
        current_health = health;
        movement_speed = 7.0f;
        gunType = 1;
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
