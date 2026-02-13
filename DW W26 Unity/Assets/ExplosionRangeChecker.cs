using System.Linq;
using UnityEngine;

public class ExplosionRangeChecker : MonoBehaviour
{
    LayerMask ExplosionLayers;
    public Rigidbody2D Bullet;
    public int Damage;
    public int Knockback;
    public Rigidbody2D itself;
    private void Start()
    {
    ExplosionLayers = LayerMask.GetMask("ground","player");
    Damage = Bullet.transform.GetComponent<BulletDamage>().ExplosiveDam;
    Knockback = Bullet.transform.GetComponent<BulletDamage>().ExplosiveKnockback;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        print("hit");
        if (collider.transform.CompareTag("ground"))
        {
            print("hitwall");
            collider.transform.GetComponent<Destructable>().Hit(Damage);
        }
        else if (collider.gameObject.CompareTag("player"))
        {
            print("hitplayerl");
            collider.transform.GetComponent<Rigidbody2D>().linearVelocity = (collider.transform.position - itself.transform.position) * Knockback;
        }
    }
}
