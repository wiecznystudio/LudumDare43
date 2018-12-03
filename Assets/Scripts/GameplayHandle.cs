using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private float timer = 0;

    private bool fireballLaunched = false;
    private bool cameraOnPlayer = false;

    private int killedAztec = 0;

    // functions
    private void Update() {
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

        if(timer > 1.5f && !cameraOnPlayer) {
            cam.destination = PlayerHandle.Instance.transform;
            cam.rotation = new Vector3(40, 65, 0);
            cameraOnPlayer = true;
            PlayerHandle.Instance.isControllable = true;
            aztecCount.color = new Color(255, 255, 255, 1);
            storyText.fontSize = 30;
            storyText.text = "Right Mouse to Fireball";
        }
            
    }


    public void UpdateAztec() {
        killedAztec++;
        aztecCount.text = "Killed Aztecs: " + killedAztec + "/20";
    }
}
