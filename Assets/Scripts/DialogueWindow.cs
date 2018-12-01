using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueWindow : MonoBehaviour
{
    // singleton
    private static DialogueWindow instance;
    public static DialogueWindow Instance {
           get { return instance;  }
    }

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(this.gameObject);
        }
    }

    // variables
    public GameObject dialoguePanel;
    public TMP_Text characterName;
    public TMP_Text characterText;

    struct Dialogue {
        public string charName;
        public string charText;
    }

    List<Dialogue> dialogues = new List<Dialogue>();
    private bool isWrited = false;

    // functions
    void Start()
    {
        
    }

    void Update()
    {
        if(dialogues.Count >= 1) {
            dialoguePanel.SetActive(true);

            if(Input.GetKeyDown(KeyCode.Space)) {
                if(isWrited) {
                    NextDialogue();
                } else {
                    CompleteDialogue();
                }
            }
        } else {
            dialoguePanel.SetActive(false);
        }
    }


    // add new dialogue from anywhere
    public void AddDialogue(string name, string text) {
        Dialogue newDialogue = new Dialogue();
        newDialogue.charName = name;
        newDialogue.charText = text;

        dialogues.Add(newDialogue);  

        if(dialogues.Count == 1) {
            characterName.text = dialogues[0].charName;
            characterText.text = "";
            StartCoroutine("Text");
        }
    }

    // put next dialogue to window
    private void NextDialogue() {
        dialogues.RemoveAt(0);
        isWrited = false;
        if(dialogues.Count <= 0)
            return;

        characterName.text = dialogues[0].charName;
        characterText.text = "";
        StartCoroutine("Text");
    }

    // complete actual writing dialogue
    private void CompleteDialogue() {
        StopCoroutine("Text");
        characterText.text = dialogues[0].charText;

        isWrited = true;
    }

    // add char by char to dialogue window
    IEnumerator Text() {
        for(int i = 0; i < dialogues[0].charText.Length; i++) {
            characterText.text += dialogues[0].charText[i];

            yield return new WaitForSeconds(0.05f);
        }
        isWrited = true;     
    }
}
