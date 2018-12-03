using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameplayHandle : MonoBehaviour
{
    // singelot
    private static GameplayHandle instance;
    public static GameplayHandle Instance {
        get { return instance; }
    }
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(this.gameObject);
        }
    }
    // variables
    public bool isActive = false;
    public FireballHandle fireball;
    public CameraHandle cam;
    public TMP_Text aztecCount;
    public TMP_Text storyText;
    public Image blackScreen;
    public Transform gameplayObjects;
    public StoryHandle storyHandler;

    private float timer = 0;

    private bool fireballLaunched = false;
    private bool cameraOnPlayer = false;
    private bool endGame = false;
    private bool endText = false;

    private int killedAztec = 0;

    // functions
    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }


        if(!isActive)
            return;

        if(!fireballLaunched) {
            if(Input.GetKeyDown(KeyCode.F)) {
                fireball.Target(new Vector3(41, 32, 17));
                fireballLaunched = true;
            }
        }

        if(!fireballLaunched)
            return;

        timer += Time.deltaTime;

        if(timer > 1.5f && !cameraOnPlayer && !endGame) {
            cam.destination = PlayerHandle.Instance.transform;
            cam.rotation = new Vector3(40, 65, 0);
            cameraOnPlayer = true;
            PlayerHandle.Instance.isControllable = true;
            aztecCount.color = new Color(255, 255, 255, 1);
            storyText.fontSize = 30;
            storyText.text = "Right Mouse to Fireball";
        }

        if(!endGame && killedAztec >= 20) {
            endGame = true;
            storyText.text = "";
            aztecCount.text = "";
            timer = 0f;
        }


        if(!endGame)
            return;

        if(blackScreen.color.a < 1) {
            blackScreen.color = new Color(0, 0, 0, timer);
            return;
        } else gameplayObjects.gameObject.active = false;


        if(!endText) {
            StartCoroutine("EndText");
            timer = 0f;
            endText = true;
        }

            
    }


    public void UpdateAztec() {
        killedAztec++;
        aztecCount.text = "Killed Aztecs: " + killedAztec + "/20";
    }



    IEnumerator EndText() {
        bool inside = true;

        storyHandler.gameObject.active = true;
        storyHandler.SetStoryText("2018 - History lesson", "Here is the real version how the Aztec civilization collapsed.");

        while(inside) {

            if(timer > 1f && timer <= 2.5f) {
                storyHandler.SetStoryAlpha(timer - 1f);
            } else if(timer > 9f && timer <= 10.5f) {
                storyHandler.SetStoryAlpha(10f - timer);
            } else if(timer > 10.5f && timer <= 11f) {
                storyHandler.SetStoryText("ESC to Exit", "Thank You for playing our game! Hope You like it! See You soon :D");
                storyHandler.SetStoryAlpha(timer - 10.5f);
            } else if(timer > 18.5f && timer <= 19f) {
                storyHandler.SetStoryAlpha(19.5f - timer);
            }

            yield return null;
        }

        
    }
}
