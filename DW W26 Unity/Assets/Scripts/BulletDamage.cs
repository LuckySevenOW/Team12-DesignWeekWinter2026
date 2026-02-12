using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    Rigidbody2D CurrCollider;
    LayerMask destroyablelayers;
    public GameObject itself;
    int BulDam;
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void setdamage(int damage)
    {
        destroyablelayers = LayerMask.GetMask("ground");
        BulDam = damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //damage collider and despawn self on hit
        if (Rigidbody2D.IsTouchingLayers(destroyablelayers))
        {
            CurrCollider = collision.rigidbody;
            CurrCollider.transform.GetComponent<Destructable>().Hit(BulDam);
        }
        else if (collision.gameObject.CompareTag("player"))
        {
            collision.transform.GetComponent<Rigidbody2D>().linearVelocity = itself.transform.position - collision.transform.position;
        }
            Destroy(itself, 0.01f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
