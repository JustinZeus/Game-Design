using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public Transform target;
    //public GameObject player;

    public int speed;
    public int damage;

    public bool triggered;
    
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
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
            Vector3 targetPos = new Vector3(target.position.x, transform.position.y,target.position.z);
            //transform.LookAt(target);
            transform.LookAt(targetPos);
            transform.position += transform.forward*speed*Time.deltaTime;
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HitPlayer(damage);
            //Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
        }
        
    }
    
}
