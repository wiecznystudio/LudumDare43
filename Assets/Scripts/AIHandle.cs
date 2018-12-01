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


    // functions
    private void Awake() {
        agent.enabled = false;

    }
    void Update() {
        if(!agent.enabled)
            return;

        SetDestination(PlayerHandle.Instance.transform.position);

        if(isMoving) {
            if(Vector3.Distance(this.transform.position, navDestination) <= 2f) {
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
        anim.SetBool("isMoving", false);
        agent.enabled = false;
    }
}
