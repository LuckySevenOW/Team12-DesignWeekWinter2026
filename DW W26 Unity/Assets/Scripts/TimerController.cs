using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    //This equals 5 minutes, we can easily change it in the inspector on the timer manager btw
    public float time = 300f;
    public TextMeshProUGUI Countdown;

    //This is for the 5 second countdown, its to delay my 5 minute game timer
    public float startDelay = 5f;

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

        Countdown.text = ((int)time / 60) + ":" + ((int)time % 60).ToString("00");
    }
}
