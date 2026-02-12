using UnityEngine;

public class Destructable : MonoBehaviour
{
       public int health;
    public GameObject thisstructrure;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void Hit(int damage)
    {
        GetComponent<Renderer>().material.color = Color.red;
        Invoke("ResetColor", 0.1f);
        health -= damage;
        if (health <= 0)
        {
            Destroy(thisstructrure, 0.01f);
        }
    }
    // Update is called once per frame
    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
