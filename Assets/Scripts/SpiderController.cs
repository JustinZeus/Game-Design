using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public Transform target;
    public GameObject player;

    public int speed;
    public int damage;

    public bool triggered;

    private EnemyHealth enemyHealth;

    [SerializeField] private Animator spiderAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        triggered = false;
        speed = 5;
        spiderAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!triggered) {
            if (enemyHealth.current_health < enemyHealth.health)
                triggered = true;

            if(Vector3.Distance(transform.position,target.position) <= 7) {
                triggered = true;
            }
        } else{
            spiderAnimator.Play("Running");

            Vector3 targetPos = new Vector3(target.position.x, transform.position.y,target.position.z);
            //transform.LookAt(target);
            transform.LookAt(targetPos);
            transform.position += transform.forward*speed*Time.deltaTime;
        }

        if(enemyHealth.current_health <= 0)
        {
            DestroyAnimated();
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().HitPlayer(damage);
            //Destroy(collision.collider.gameObject);
            //DestroyAnimated();          
        }
        
    }

    public void DestroyAnimated()
    {
        speed = 0;
        spiderAnimator.Play("Death");
        Destroy(this.gameObject, 0.5f);
    }
    
}
