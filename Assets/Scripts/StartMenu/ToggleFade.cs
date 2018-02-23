using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Code taken and modified from Game Dev Lecture
public class ToggleFade : MonoBehaviour
{

    //Used from class example
    Text text;

    // Use this for initialization
    void Start()
    {
        text = gameObject.GetComponent<Text>(); //Takes text component of GameObject
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f); //Starts as Invisible text
    }

    public void toggleText()
    {
        StartCoroutine("Fade"); //Initiates Co-routine
    }

    //Co-Routine requires this syntax
    private IEnumerator Fade()
    {
        float duration = 0.5f; //0.5 secs
        float currentTime = 0f;
        float startOpacity = 0f; //Initial Transparency
        float endOpacity = 1f; //Resulting Transparency

        //Opacity values change if text is visible
        if (text.color.a > 0.9f)
        {
            startOpacity = 1f;
            endOpacity = 0f;
        }

        //While loop occurs for as long as the duration can allow
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(startOpacity, endOpacity, currentTime / duration); //Updates text opacity based on the duration of the fade
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha); //Updates new value to text
            currentTime += Time.deltaTime; //This is the time between frames
            yield return null;
        }
        yield break;
    }
}
