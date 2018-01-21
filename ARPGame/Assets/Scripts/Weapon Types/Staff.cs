using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : EquippableModel, IWeapon, IProjectileWeapon
{
    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
    }

    public void PerformAttack()
    {
        FireProjectile();
        Debug.Log("Attacking with " + this.name + "!");
    }

    public void PerformAttack2()    // Sample of another attack and how it would need to reference it's own trigger (part of the animator object)
    {
        Debug.Log("Attacking with " + this.name + "!");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage(transform.root.GetComponent<CharacterStats>().stats.Find(x => x.StatName == "STR").GetCalculatedStatValue());
        }
        Debug.Log("Hit: " + col.name);
    }

    public void FireProjectile()
    {
        Fireball fireballInstance = Instantiate(fireball, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
