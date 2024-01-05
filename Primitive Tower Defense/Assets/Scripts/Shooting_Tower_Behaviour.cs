using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Tower_Behaviour : MonoBehaviour
{
    public GameObject Projectile;

    private bool readyforproj = true;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("LaunchProjectile", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (readyforproj)
        {
            readyforproj = false;
            StartCoroutine(LaunchProjectile());
        }

    }

    IEnumerator LaunchProjectile()
    {
        Rigidbody instance = Instantiate(Projectile.GetComponent<Rigidbody>());
        //Not sure about that

        Projectile.transform.position = this.gameObject.transform.position;

        instance.velocity = Vector3.forward * 5.0f;
        yield return new WaitForSeconds(1f);
        readyforproj = true;
    }
}
