using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().OnAmmo = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("player"))
        {
            collider.transform.GetComponent<PlayerController>().OnAmmo = false;
        }
    }
}
