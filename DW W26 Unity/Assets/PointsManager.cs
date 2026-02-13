using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public int Team1Points;
    public int Team2Points;
    public Sprite Win;
    public Sprite Lose;
    public Sprite Draw;
    public Sprite nothing;
    public SpriteRenderer Screen1;
    public SpriteRenderer Screen2;
    public void Start()
    {
        Screen1.sprite = nothing;
        Screen2.sprite = nothing;
    }
    public void RoundEnd()
    {
        if (Team1Points > Team2Points)
        {
            Screen1.sprite = Win;
            Screen2.sprite = Lose;
        }
        else if (Team2Points > Team1Points)
        {
            Screen1.sprite = Lose;
            Screen2.sprite = Win;
        }
        else
        {

            Screen1.sprite = Draw;
            Screen2.sprite = Draw;
        }

        Invoke("quit", 8f);
    }

    private void quit()
    {
        SceneManager.LoadScene(0);
    }
}
