using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandle : MonoBehaviour
{
    // variables

    public Transform destination;

    [SerializeField]
    private float smoothAmount = 10f;
    [SerializeField]
    private Vector3 offset;

    // functions

    private void Update() {
        if(destination == null)
            return;

        Vector3 newPosition = Vector3.Lerp(this.transform.position, destination.position + offset, smoothAmount);

        this.transform.position = newPosition;
    }
}
