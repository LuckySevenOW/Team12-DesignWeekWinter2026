using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTarget : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called on bullet hit
    public void Hit(int damage)
    {
        SceneManager.LoadScene(2);
    }
}
