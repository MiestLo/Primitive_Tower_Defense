using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Bullet_Behaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private bool destroyme = false;
    private bool im_alive = true;

    void Start()
    {
        this.gameObject.tag = "Bullet";
    }

    // Update is called once per frame
    void Update()
    {
        if (im_alive)
        {
            im_alive = false; // will be destroy in a second
            StartCoroutine(DestroyMySelf());
        }

        if (destroyme)
            Destroy(this.gameObject);
    }

    //Do something when the projectile touch an ennemie
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Foe")
        {
            //Destroy the foe and destroy the bullet
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
            
    }

    IEnumerator DestroyMySelf()
    {
        yield return new WaitForSeconds(3f);
        destroyme = true;
    }
}
