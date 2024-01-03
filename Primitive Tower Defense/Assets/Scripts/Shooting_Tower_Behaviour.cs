using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Tower_Behaviour : MonoBehaviour
{
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LaunchProjectile", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchProjectile()
    {
        Rigidbody instance = Instantiate(Projectile.GetComponent<Rigidbody>());

        instance.velocity = Random.insideUnitSphere * 5.0f;
    }
}
