using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandle : MonoBehaviour
{
    // variables

    public NavMeshAgent agent;
    public Camera cam;
    public Animator anim;

    private bool isMoving;
    private Vector3 navDestination;

    // functions
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) {
                navDestination = hit.point;
                agent.SetDestination(navDestination);
                anim.SetBool("isMoving", true);
                isMoving = true;
            }
        }

        if(isMoving) {
            if(Vector3.Distance(this.transform.position, navDestination) <= 2f) {
                anim.SetBool("isMoving", false);
                isMoving = false;
            }
        }
    }
}
