using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueHandle : MonoBehaviour
{
    // variables
    public Image blackScreen;


    private float startTimer = 0f;
    private bool[] bools = new bool[10];
    // functions

    private void Start() {
        //blackScreen.color = new Color(0, 0, 0, 1);
        for(int i = 0; i < bools.Length; i++)
            bools[i] = true;
    }

    void Update()
    {
        startTimer += Time.deltaTime;



        if(startTimer >= 1.5f) {
            if(!bools[0]) {
                DialogueWindow.Instance.AddDialogue("Rafau", "NIKT NIE SPODZIEWAL SIE HISZPANSKIEJ INKWIZYCJI!!!!!!!!111!11!");
                DialogueWindow.Instance.AddDialogue("Robert", "Ja sie spodziewalem! :>");
                DialogueWindow.Instance.AddDialogue("Rafau", "Nooo ale system to zrobiles fajowy tych dialuf");
                DialogueWindow.Instance.AddDialogue("Rafau", "Wiem wiem tesz mi sie mega podoba");
                bools[0] = true;
            }
        }
        if(startTimer >= 1f) {
            if(blackScreen.color.a > 0) {
                blackScreen.color = new Color(0, 0, 0, (2f - startTimer));
            }
        }
    }
}
