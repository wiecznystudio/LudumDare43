using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHandle : MonoBehaviour
{
    // singleton
    private static PlayerHandle instance;
    public static PlayerHandle Instance {
        get { return instance;  }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
    }

    // variables
    public NavMeshAgent agent;
    public Camera cam;
    public Animator anim;

    public GameObject fireballPrefab;

    private bool isMoving;
    private Vector3 navDestination;

    public bool isControllable = false;

    // functions
    void Update()
    {
        if(!isControllable)
            return;

        // moving
        if(Input.GetMouseButton(0)) {
            int layerMask = LayerMask.GetMask("Map");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, layerMask)) {
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


        if(Input.GetMouseButtonDown(1)) {
            // shoot the fireball
            int layerMask = LayerMask.GetMask("Map", "OnMap");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f, layerMask)) {
                FireFIREBALL(hit.point);
            }
        }
    }



    private void FireFIREBALL(Vector3 destination) {
        GameObject fireball = Instantiate(fireballPrefab, this.transform.position + new Vector3(0, 15f, 0), Quaternion.identity);
        fireball.GetComponent<FireballHandle>().Target(destination);
    }
}
