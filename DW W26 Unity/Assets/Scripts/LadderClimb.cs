using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    public Rigidbody2D Collision;
    // trigger when object enters
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().OnLadder(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().OnLadder(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
