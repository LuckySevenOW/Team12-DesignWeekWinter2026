using UnityEngine;

public class Destructable : MonoBehaviour
{
       public int health;
    public GameObject thisstructrure;
    public GameObject pointmanager;
    public void Hit(int damage)
    {
        GetComponent<SpriteRenderer>().material.color = Color.red;
        Invoke("ResetColor", 0.1f);
        health -= damage;
        if (health <= 0)
        {
            if (this.gameObject.transform.position.x > 0)
            {
            pointmanager.GetComponent<PointsManager>().Team2Points += 1;
            }
            else
            {
            pointmanager.GetComponent<PointsManager>().Team1Points += 1;
            }
            Destroy(thisstructrure, 0.01f);
        }
    }
    // Update is called once per frame
    public void ResetColor()
    {
        GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
