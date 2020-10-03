// Code used for all text. Attach to a text object and reference.
// Auther: James Hopkins
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIFade : MonoBehaviour
{
    Text inputText;
    float time = 0.0f;

    public void FadeTimer(string input)
    {
        inputText = GetComponent<Text>();
        inputText.text = input;
        StartCoroutine(FadeTextToFullAlpha(0.5f, inputText));
    }

    private IEnumerator FadeTextToFullAlpha(float t, Text UITextObject)
    {
        UITextObject.color = new Color(UITextObject.color.r, UITextObject.color.g, UITextObject.color.b, 0);
        while (UITextObject.color.a < 1.0f)
        {
            UITextObject.color = new Color(UITextObject.color.r, UITextObject.color.g, UITextObject.color.b, UITextObject.color.a + (Time.deltaTime / t));
            if (UITextObject.color.a >= 1.0f)
            {
                yield return new WaitForSeconds(1);
                StartCoroutine(FadeTextToNullAlpha(1f, UITextObject));
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator FadeTextToNullAlpha(float t, Text UITextObject)
    {
        time += Time.deltaTime;
        UITextObject.color = new Color(UITextObject.color.r, UITextObject.color.g, UITextObject.color.b, 1);
        while (UITextObject.color.a > 0.0f)
        {
            UITextObject.color = new Color(UITextObject.color.r, UITextObject.color.g, UITextObject.color.b, UITextObject.color.a - (time / t));
            if (UITextObject.color.a <= 0.0f)
                yield break;
            yield return null;
        }
    }
}