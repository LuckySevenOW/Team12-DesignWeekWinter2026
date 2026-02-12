using UnityEngine;

public class LadderClimb : MonoBehaviour
{
    // trigger when object enters
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().OnLadder(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().OnLadder(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
