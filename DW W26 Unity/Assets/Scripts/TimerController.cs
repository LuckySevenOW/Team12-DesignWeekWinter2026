using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    //This equals 5 minutes, we can easily change it in the inspector on the timer manager btw
    public float time = 300f;
    public TextMeshProUGUI Countdown1;
    public TextMeshProUGUI Countdown2;

    //This is for the 5 second countdown, its to delay my 5 minute game timer
    public float startDelay = 5f;

    //This is for the panel gameobjects that will be the draw screens
    public GameObject DrawScreenDisplay1;
    public GameObject DrawScreenDisplay2;

    private bool hasDrawed = false;

    void Update()
    {
        //This is for the 5 second countdown delay
        if (startDelay > 0f)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        //This is for the 5 minute game timer
        time -= Time.deltaTime;
        if (time < 0) time = 0;

        Countdown1.text = ((int)time / 60) + ":" + ((int)time % 60).ToString("00");
        Countdown2.text = ((int)time / 60) + ":" + ((int)time % 60).ToString("00");

        //Activate the draw screens on both displays
        if (time <= 0f && !hasDrawed)
        {
            hasDrawed = true;

            if (DrawScreenDisplay1 != null)
                DrawScreenDisplay1.SetActive(true);

            if (DrawScreenDisplay2 != null)
                DrawScreenDisplay2.SetActive(true);
        }
    }
}
