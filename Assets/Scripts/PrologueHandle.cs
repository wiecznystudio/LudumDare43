using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueHandle : MonoBehaviour
{
    // variables
    public Image blackScreen;


    private float startTimer = 0f;

    // functions

    private void Start() {
        blackScreen.color = new Color(0, 0, 0, 1);
    }

    void Update()
    {
        startTimer += Time.deltaTime;

        if(startTimer >= 1f) {
            if(blackScreen.color.a > 0) {
                blackScreen.color = new Color(0, 0, 0, (2f - startTimer));
            }
        }
    }
}
