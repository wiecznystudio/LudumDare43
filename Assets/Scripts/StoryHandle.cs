using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryHandle : MonoBehaviour
{
    public TMP_Text storyName;
    public TMP_Text storyText;


    public void SetStoryText(string name, string text) {
        storyName.text = name;
        storyText.text = text;
    }

    public void SetStoryAlpha(float alpha) {
        storyName.color = new Color(255, 255, 255, alpha);
        storyText.color = new Color(255, 255, 255, alpha);
    }
}
