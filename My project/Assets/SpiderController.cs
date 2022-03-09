using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public Transform target;
    public GameObject player;

    public int health;
    public int speed;

    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        health = 2;
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(!triggered) {
            if(Vector3.Distance(transform.position,target.position) <= 7) {
                triggered = true;
            }
        } else{
            transform.LookAt(target);
            transform.position += transform.forward*speed*Time.deltaTime;
        }


        if(health <= 0) Destroy(this.gameObject);
    }

    public void GetHit(int damage){
        health -= damage;
    }
}
