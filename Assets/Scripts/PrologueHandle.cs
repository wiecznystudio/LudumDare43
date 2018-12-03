using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class PrologueHandle : MonoBehaviour
{
    // variables
    public Image blackScreen;
    [Header("Camera")]
    public CameraHandle cam;

    [Header("Scene Transforms")]
    public Transform[] firstSceneCameraTransforms;
    public Transform[] secondSceneCameraTransforms;
    public Transform[] therdSceneCameraTransforms;
    public Transform lastSceneCameraTransform;
    public PlayableDirector firstTimeline;
    public PlayableDirector secondTimeline;
    public PlayableDirector therdTimeline;
    public PostProcessVolume postProccess;
    public StoryHandle storyHandler;
    public TMP_Text storyText;
    public Transform firstObjectsToDisable;
    public Transform secondObjectsToDisable;
    public Transform therdObjectsToDisable;
    public Transform gameplayObjects;
    public GameplayHandle gameplay;

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
            StartCoroutine("BlackBegin");
        } else if(!bools[1]) {
            StartCoroutine("FirstScene");
        } else if(!bools[2]) {
            StartCoroutine("BlackAfterFirst");
        } else if(!bools[3]) {
            StartCoroutine("SecondScene");
        } else if(!bools[4]) {
            StartCoroutine("BlackAfterSecond");
        } else if(!bools[5]) {
            StartCoroutine("TherdScene");
        } else if(!bools[6]) {
            gameplay.isActive = true;
        }

        // firstly make visible screen
        // make screen black to change scene transform


        //Debug.Log(startTimer);
    }


    ////////////////////////////////
    // black at beggining // blacks
    //////////////////////////////// 
    IEnumerator BlackBegin() {
        // we are inside
        insideCorutine = true;
        firstObjectsToDisable.gameObject.active = true;
        gameplayObjects.gameObject.active = false;
        storyHandler.gameObject.active = true;
        storyHandler.SetStoryText("1254 - Horces Cortes", "cos tam cos tam");
        storyHandler.transform.position += new Vector3(-25f, 0);
        ColorGrading colorGrading = null;
        postProccess.profile.TryGetSettings(out colorGrading);
        colorGrading.colorFilter.value = new Vector4(0.1367925f, 0.1514248f, 1.0f);
        RenderSettings.fog = true;

        while(!bools[0]) {
            storyHandler.transform.position += new Vector3(0.05f, 0);
            // change screen black
            if(startTimer > 1f && startTimer <= 2.5f) {
                storyHandler.SetStoryAlpha(startTimer - 1f);
            } else if(startTimer > 7f && startTimer < 8.5f) {
                storyHandler.SetStoryAlpha(8f - startTimer);
            } else if(startTimer >= 8.5f) {
                changeScene = true;
            }
            
            // close coroutine when camera is near point 2
            if(changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[0] = true;
                storyHandler.SetStoryText("", "");
                storyHandler.gameObject.active = false;
            }
            yield return null;
        }
    }

    IEnumerator BlackAfterFirst() {
        // we are inside
        insideCorutine = true;
        secondObjectsToDisable.gameObject.active = true;
        storyHandler.gameObject.active = true;
        storyHandler.transform.position += new Vector3(-25f, 0);
        storyHandler.SetStoryText("1254 - Horces Cortes", "cos tam cos tam");

        while(!bools[2]) {
            storyHandler.transform.position += new Vector3(0.05f, 0);
            // change screen black
            if(startTimer > 1f && startTimer <= 2.5f) {
                storyHandler.SetStoryAlpha(startTimer - 1f);
            } else if(startTimer > 7f && startTimer < 8.5f) {
                storyHandler.SetStoryAlpha(8f - startTimer);
            } else if(startTimer >= 8.5f) {
                changeScene = true;
            }

            // close coroutine when camera is near point 2
            if(changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[2] = true;
                storyHandler.SetStoryText("", "");
                storyHandler.gameObject.active = false;
                firstObjectsToDisable.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    IEnumerator BlackAfterSecond() {
        // we are inside
        insideCorutine = true;
        therdObjectsToDisable.gameObject.active = true;
        storyHandler.gameObject.active = true;
        storyHandler.transform.position += new Vector3(-240f, 0);
        storyHandler.SetStoryText("1254 - Horces Cortes", "cos tam cos tam");
        ColorGrading colorGrading = null;
        postProccess.profile.TryGetSettings(out colorGrading);
        colorGrading.colorFilter.value = new Vector4(0.3372549f, 0.2941177f, 0.6901961f);
        RenderSettings.fog = false;

        while(!bools[4]) {
            storyHandler.transform.position += new Vector3(0.05f, 0);
            // change screen black
            if(startTimer > 1f && startTimer <= 2.5f) {
                storyHandler.SetStoryAlpha(startTimer - 1f);
            } else if(startTimer > 7f && startTimer < 8.5f) {
                storyHandler.SetStoryAlpha(8f - startTimer);
            } else if(startTimer >= 8.5f) {
                changeScene = true;
            }

            // close coroutine when camera is near point 2
            if(changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[4] = true;
                storyHandler.SetStoryText("", "");
                storyHandler.gameObject.active = false;
                secondObjectsToDisable.gameObject.SetActive(false);
            }
            yield return null;
        }
    }

    ////////////////////////////////
    // first scene logic // scenes
    ////////////////////////////////
    IEnumerator FirstScene() {
        // setup all stuff
        cam.SetPoint(firstSceneCameraTransforms[0]);
        storyText.text = "hegegedg";
        // we are inside
        insideCorutine = true;
        firstTimeline.Play();

        while(!bools[1]) {
            // change screen black
            if(startTimer < 1.5f) {
                if(blackScreen.color.a > 0) {
                    blackScreen.color = new Color(0, 0, 0, (1f - startTimer));
                    storyText.color = new Color(255, 255, 255, startTimer - 0.5f);
                }
            } else if(startTimer >= 8f && startTimer < 9.5f) {
                if(blackScreen.color.a < 1) {
                    blackScreen.color = new Color(0, 0, 0, (-8f + startTimer));
                    storyText.color = new Color(255, 255, 255, 9f - startTimer);
                } else changeScene = true;
            }
            cam.ToPoint(firstSceneCameraTransforms[1], 0.005f);
            // close coroutine when camera is near point 2
            if(changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[1] = true;
                storyText.text = "";
            }
            yield return null;
        }
    }


    // second scene logic
    IEnumerator SecondScene() {
        // setup all stuff
        cam.SetPoint(secondSceneCameraTransforms[0]);
        storyText.text = "asdasdasd";
        // we are inside
        insideCorutine = true;
        secondTimeline.Play();

        while(!bools[3]) {
            // change screen black
            if(startTimer < 1.5f) {
                if(blackScreen.color.a > 0) {
                    blackScreen.color = new Color(0, 0, 0, (1f - startTimer));
                    storyText.color = new Color(255, 255, 255, startTimer - 0.5f);
                }
            } else if(startTimer >= 8f && startTimer < 9.5f) {
                if(blackScreen.color.a < 1) {
                    blackScreen.color = new Color(0, 0, 0, (-8f + startTimer));
                    storyText.color = new Color(255, 255, 255, 9f - startTimer);
                } else changeScene = true;
            }
            cam.ToPoint(secondSceneCameraTransforms[1], 0.005f);
            // close coroutine when camera is near point 2
            if(changeScene) {
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[3] = true;
                storyText.text = "";
            }
            yield return null;
        }
    }

    // therd scene
    IEnumerator TherdScene() {
        // setup all stuff
        cam.SetPoint(therdSceneCameraTransforms[0]);
        storyText.text = "zxcvbfb";
        // we are inside
        insideCorutine = true;
        therdTimeline.Play();

        while(!bools[5]) {
            // change screen black
            if(startTimer < 1.5f) {
                if(blackScreen.color.a > 0) {
                    blackScreen.color = new Color(0, 0, 0, (1f - startTimer));
                    storyText.color = new Color(255, 255, 255, startTimer - 0.5f);
                }
            } else if(startTimer >= 11.15f && startTimer < 11.25f) {
                storyText.text = "";
                blackScreen.color = new Color(0, 0, 0, 1);
            } else if(startTimer >= 12.5f && startTimer < 12.6f) {
                therdObjectsToDisable.gameObject.active = false;
                gameplayObjects.gameObject.active = true;
                changeScene = true;
            }

            cam.ToPoint(therdSceneCameraTransforms[1], 0.01f);
            // close coroutine when camera is near point 2
            if(changeScene) {
                cam.SetPoint(lastSceneCameraTransform);
                insideCorutine = false;
                changeScene = false;
                startTimer = 0f;
                bools[5] = true;
                blackScreen.color = new Color(0, 0, 0, 0);
                storyText.fontSize = 50;
                storyText.alignment = TextAlignmentOptions.Center;
                storyText.text = "Press F to SACRIFICE";
            }
            yield return null;
        }
    }

}
