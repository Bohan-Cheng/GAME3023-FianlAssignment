using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Script_Msg : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;

    [SerializeField] string StartMsg;

    [SerializeField]
    [Range(0.001f, 100000f)]
    float textSpeedCharactersPerSecond = 10;

    // This reference is valid while running the coroutine and null when not
    IEnumerator animateTextRoutine = null;

    private void Start()
    {
        AnimateText(StartMsg);
    }

    public void AnimateText(string message)
    {
        //if coroutine is running
        if(animateTextRoutine != null)
        {
            StopCoroutine(animateTextRoutine);
        }

        // set the reference to the running coroutine
        animateTextRoutine = AnimateTextRoutine(message);
        //start it!
        StartCoroutine(animateTextRoutine);
    }

    IEnumerator AnimateTextRoutine(string message)
    {
        Assert.IsTrue(textSpeedCharactersPerSecond > float.Epsilon);

        string currentMessage = "";

        for(int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            currentMessage += message[currentChar];
            text.text = currentMessage;
            yield return new WaitForSeconds(1/textSpeedCharactersPerSecond);
        }

        //when finished, set reference to null
        animateTextRoutine = null;
    }
}
