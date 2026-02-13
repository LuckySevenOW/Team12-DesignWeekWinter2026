using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTarget : MonoBehaviour
{
    public GameObject points;
    public bool Rightside;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called on bullet hit
    public void Hit(int damage)
    {
        if (Rightside)
        {
            points.transform.GetComponent<PointsManager>().Team1Points += 100;
        }
        else
        {
            points.transform.GetComponent<PointsManager>().Team2Points += 100;
        }
        points.transform.GetComponent<PointsManager>().RoundEnd();
    }
}
