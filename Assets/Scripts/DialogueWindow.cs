using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    // variables

    public TMP_Text characterName;
    public TMP_Text characterText;

    private string charName;
    private string charText;
    // functions

    void Start()
    {
        SetText("HAhahahaha dziala");

        //if(Input.GetKeyDown("f"))
         StartCoroutine("Text");
    }

    void Update()
    {
        
    }



    private void SetText(string text) {
        charText = text;
    }

    IEnumerator Text() {
        for(int i = 0; i < charText.Length; i++) {
            characterText.text += charText[i];

            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
