using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CannonBulletSpawn : MonoBehaviour
{
    public int Damage;
    public int ShotVelocity;
    public int RemainingShots = 0;
    public Rigidbody2D BulletSpawn;
    public GameObject Bullet;
    public SpriteRenderer AmmoIndicator;
    public void Shoot()
    {
        //check for ammo
        if (RemainingShots > 0)
        {
            //shoot
         
        GameObject spawnedbullet = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity);
        spawnedbullet.GetComponent<Rigidbody2D>().linearVelocity = (BulletSpawn.transform.position - transform.position) * ShotVelocity;
        spawnedbullet.GetComponent<BulletDamage>().setdamage(Damage);
            //reduce ammo
        RemainingShots -= 1;
        }

    }
    private void Update()
    {
        //ammo indicator code
        if (RemainingShots > 0)
        {
            AmmoIndicator.enabled = false;
        }
        else
        {
            AmmoIndicator.enabled = true;
        }
    }
    public void AddAmmo(int AddAmmo)
    {
        RemainingShots += AddAmmo;
        if (RemainingShots > 1)
        {
            RemainingShots = 1;
        }

    }
}
