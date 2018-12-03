using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    // variables

    public Transform destination;
    public Vector3 rotation = Vector3.zero;

    [SerializeField]
    private float smoothAmount = 10f;
    [SerializeField]
    private Vector3 offset;

    private bool toPoint = false;

    // functions

    private void Update() {
        if(destination == null)
            return;
        else toPoint = false;

        if(toPoint)
            return;

        Vector3 newPosition = Vector3.Lerp(this.transform.position, destination.position + offset, smoothAmount);

        this.transform.position = newPosition;

        if(rotation != Vector3.zero) {
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(rotation), 0.05f);
            if(this.transform.rotation == Quaternion.Euler(rotation))
                rotation = Vector3.zero;
        }
    }

    public void SetPoint(Transform point) {
        toPoint = true;
        this.transform.position = point.position;
        this.transform.rotation = point.rotation;
    }

    public bool ToPoint(Transform point, float speed) {

        if(Vector3.Distance(this.transform.position, point.position) <= 0.05f) {
            toPoint = false;
            return true;
        }
        Vector3 addPos = (point.position - this.transform.position);
        this.transform.position += addPos.normalized * speed;

        return false;
    }
}
