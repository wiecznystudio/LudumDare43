using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIHandle : MonoBehaviour
{
    // variables
    public NavMeshAgent agent;
    public Animator anim;
    public Rigidbody rb;

    private bool isMoving;
    private Vector3 navDestination;

    private bool isDead = false;
    // functions
    private void Awake() {
        //agent.enabled = false;

    }
    void Update() {
        if(!agent.enabled)
            return;
        
        if(!isMoving) {
            SetDestination(this.transform.position + (new Vector3(Random.insideUnitCircle.x, 0, Random.insideUnitCircle.y) * 5f));
        }

        if(isMoving) {
            if(Vector3.Distance(this.transform.position, navDestination) <= 4f) {
                anim.SetBool("isMoving", false);
                isMoving = false;
            }
        }
    }

    public void SetDestination(Vector3 destination) {

        navDestination = destination;
        agent.SetDestination(navDestination);
        anim.SetBool("isMoving", true);
        isMoving = true;
    }

    public void Die() {
        if(isDead)
            return;

        isDead = true;
        anim.SetBool("isMoving", false);
        agent.enabled = false;
        GameplayHandle.Instance.UpdateAztec();
    }
}
