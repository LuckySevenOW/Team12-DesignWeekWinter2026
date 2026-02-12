using UnityEngine;

public class CannonPlayerCheck : MonoBehaviour
{
    public Rigidbody2D Cannon;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().TouchingCannon = true;
            collider.transform.GetComponent<PlayerController>().CurrCannon = Cannon;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().TouchingCannon = false;
            collider.transform.GetComponent<PlayerController>().CurrCannon = null;
            collider.transform.GetComponent<PlayerController>().CanMove = true;
        }
    }
}
