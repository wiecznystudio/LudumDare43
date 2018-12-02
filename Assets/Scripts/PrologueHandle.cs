using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class PrologueHandle : MonoBehaviour
{
    // variables
    public Image blackScreen;
    [Header("Camera")]
    public CameraHandle cam;

    [Header("Scene Transforms")]
    public Transform[] firstSceneCameraTransforms;
    public Transform[] secondSceneCameraTransforms;
    public PlayableDirector secondTimeline;

    private float startTimer = 0f;
    private bool[] bools = new bool[10];
    private bool insideCorutine = false;
    private bool changeScene = false;

    // functions
    private void Start() {
        blackScreen.color = new Color(0, 0, 0, 1);
        for(int i = 0; i < bools.Length; i++)
            bools[i] = false;

    }

    void Update()
    {
        // add time
        startTimer += Time.deltaTime;

        if(insideCorutine)
            return;

        if(!bools[0]) {
            StartCoroutine("FirstScene");
        } else if(!bools[1]) {
            StartCoroutine("SecondScene");
        } else if(!bools[2]) {
            //StartCoroutine("SecondScene");
        }

        // firstly make visible screen
        // make screen black to change scene transform
        

        //Debug.Log(startTimer);
    }


    // first scene logic
    IEnumerator FirstScene() {
        // setup all stuff
        cam.SetPoint(firstSceneCameraTransforms[0]);
        RenderSettings.fog = true;

        // we are inside
        insideCorutine = true;

        while(!bools[0]) {
            // change screen black
            if(startTimer >= 1f && startTimer < 3f) {
                if(blackScreen.color.a > 0) {
                    blackScreen.color = new Color(0, 0, 0, (2f - startTimer));
                }
            } else if(startTimer >= 7f && startTimer < 9f) {
                if(blackScreen.color.a < 1) {
                    blackScreen.color = new Color(0, 0, 0, (-7f + startTimer));
                } else changeScene = true;
            }

            // close coroutine when camera is near point 2
            if(cam.ToPoint(firstSceneCameraTransforms[1], 0.005f) && changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[0] = true;
            }
            yield return null;
        }
    }

    // first scene logic
    IEnumerator SecondScene() {
        // setup all stuff
        cam.SetPoint(secondSceneCameraTransforms[0]);

        // we are inside
        insideCorutine = true;
        secondTimeline.Play();

        while(!bools[1]) {
            // change screen black
            if(startTimer >= 1f && startTimer < 3f) {
                if(blackScreen.color.a > 0) {
                    blackScreen.color = new Color(0, 0, 0, (2f - startTimer));
                }
            } else if(startTimer >= 9f && startTimer < 11f) {
                if(blackScreen.color.a < 1) {
                    blackScreen.color = new Color(0, 0, 0, (-9f + startTimer));
                } else changeScene = true;
            }

            // close coroutine when camera is near point 2
            if(cam.ToPoint(secondSceneCameraTransforms[1], 0.005f) && changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[1] = true;
            }
            yield return null;
        }
    }
}
