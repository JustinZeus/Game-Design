using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float spawntime;
    // Start is called before the first frame update
    void Start()
    {
      spawntime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      if((Time.time - spawntime) > 10f) Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
      if(collision.collider.gameObject.tag == "Enemies"){
        Destroy(collision.collider.gameObject);
      }
      Destroy(this.gameObject);
    }
}
