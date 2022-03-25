using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public ShootController shootController;

    // Start is called before the first frame update
    void Start()
    {
        shootController = player.GetComponent<ShootController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Vector3.Scale(shootController.direction.normalized, new Vector3(0.5f,0.5f,0.5f));
        transform.rotation = Quaternion.LookRotation(shootController.direction);
        transform.localRotation *= Quaternion.Euler(-90, 0, 0);
    }
}
