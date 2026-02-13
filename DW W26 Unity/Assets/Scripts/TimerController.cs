using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    //This equals 5 minutes, we can easily change it in the inspector on the timer manager btw
    public float time = 300f;
    public TextMeshProUGUI Countdown1;
    public TextMeshProUGUI Countdown2;

    //This is for the 5 second countdown, its to delay my 5 minute game timer
    public float startDelay = 5f;
    public  GameObject points;
    //This is for the panel gameobjects that will be the draw screens
    public GameObject DrawScreenDisplay1;
    public GameObject DrawScreenDisplay2;

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


        //Activate the draw screens on both displays
        if (time <= 0f)
        {
            points.transform.GetComponent<PointsManager>().RoundEnd();
        }
    }
}
