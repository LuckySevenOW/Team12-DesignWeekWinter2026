using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    Rigidbody2D CurrCollider;
    LayerMask destroyablelayers;
    public GameObject itself;
    public SpriteRenderer Sprite;
    public Rigidbody2D Explosion;
    public bool Explodes;
    public int BulDam;
    public int ExplosiveDam;

    public int BulletKnockback;
    public int ExplosiveKnockback;
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
            if (CurrCollider)
          {
            if (CurrCollider.transform.GetComponent<Destructable>())
                {
                    CurrCollider.transform.GetComponent<Destructable>().Hit(BulDam); 
                }
            else
            {
                if (CurrCollider.transform.GetComponent<WinTarget>())
                {
                    CurrCollider.transform.GetComponent<WinTarget>().Hit(BulDam);
                }
            }
          }
        }
        else if (collision.gameObject.CompareTag("player"))
        {
            collision.transform.GetComponent<Rigidbody2D>().linearVelocity = (itself.transform.position - collision.transform.position) * BulletKnockback;
        }
        if (Explodes)
        {
            Explosion.transform.position = itself.transform.position;
        }
        Destroy(itself, 0.02f);
    }
    private void Update()
    {
        Sprite.transform.Rotate(new Vector3(0,0,5));
    }
}
