using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHandle : MonoBehaviour
{

    // variable
    public Transform fireBall;
    public Transform fireTrail;

    private Vector3 targetDestination;
    private Vector3 velocity;

    private float explosionForce = 80f;
    private float explosionRange = 7f;

    // functions
    private void Update() {
        if(Vector3.Distance(this.transform.position, targetDestination) > 0.5f) {
            this.transform.position += velocity;
        } else {
            Explode();
            Destroy(this.gameObject, 3.0f);
        }
            
    }

    public void Target(Vector3 destination) {
        targetDestination = destination;
        velocity = (destination - this.transform.position);
        velocity.Normalize();
        velocity *= 0.3f;
    }

    private void Explode() {
        fireBall.gameObject.SetActive(false);
        fireTrail.GetComponent<ParticleSystem>().Stop();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange);

        for(int i = 0; i < colliders.Length; i++) {
            if(colliders[i].tag == "Knuckle") {
                AIHandle ai = colliders[i].GetComponent<AIHandle>();
                if(ai != null) {
                    ai.Die();
                }
                Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
                if(rb != null) {
                    rb.useGravity = true;
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRange);
                }
            }
        }
    }
}
