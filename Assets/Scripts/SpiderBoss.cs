using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBoss : MonoBehaviour
{
    public float interval;
    public float prevTime;
    public int special;

    public float dashTimer;
    public bool jumping;

    public SpiderController spiderController;

    void Start()
    {
        interval = 10.0f;
        prevTime = Time.time;
        spiderController = GetComponent<SpiderController>();
        spiderController.triggered = true;
        jumping = false;
        JumpAttack();
    }

    void Update()
    {
        if(Time.time - prevTime > interval){
            special = Random.Range(0,1);
            prevTime = Time.time;
            UseMove(special);
        }

        if(jumping && Time.time - dashTimer < 2.0f)
        {
           transform.position = new Vector3(transform.position.x,transform.position.y+0.05f,transform.position.z);
        }

        if(!jumping && transform.position.y > 0.63f)
        {
           transform.position = new Vector3(transform.position.x,transform.position.y-0.1f,transform.position.z);
        }

        if(Time.time - dashTimer > 1.0f)
        {
            spiderController.speed = 5;
            jumping = false;
        }
    }

    void UseMove(int special)
    {
        switch(special)
        {
            case 0:
                JumpAttack();
                break;
            case 1:
                DashAttack();
                break;
        }
    }

    void JumpAttack()
    {
        spiderController.speed = 25;
        jumping = true;
        dashTimer = Time.time;
    }

    void DashAttack()
    {
        spiderController.speed = 35;
        dashTimer = Time.time;
    }
}
