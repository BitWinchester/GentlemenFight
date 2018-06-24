using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterHittingGround : MonoBehaviour {

    public float delay = 3f;
    float countDown;
    bool hasExploded = false;
    public GameObject explosionFX;
    public float explosionRadius;

    private void Start()
    {
        countDown = delay; 
    }

    private void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }

    }

    void Explode()
    {
        Instantiate(explosionFX, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            characterScript cs = nearbyObject.GetComponent<characterScript>();

            if( cs != null)
            {
                nearbyObject.GetComponent<characterScript>().Death();
            }
           
        }
        Destroy(gameObject);
    }





}
