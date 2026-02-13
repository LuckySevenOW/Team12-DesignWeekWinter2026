using UnityEngine;

public class CannonPlayerCheck : MonoBehaviour
{
    bool movedown;
    public Rigidbody2D Cannon;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().TouchingCannon = true;
            collider.transform.GetComponent<PlayerController>().CurrCannon = Cannon;
        }
        if (collider.gameObject.layer == 6)
        {
            movedown = false;
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

        if (collider.gameObject.layer == 6)
        {
            movedown = true;
        }
    }
    private void Update()
    {
        if (movedown)
        {
            this.transform.localPosition -= new Vector3(0, 0.01f, 0);
        }
    }
}
