using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon {

    private Animator animator;

    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = gameObject.GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
        Debug.Log("Attacking with " + this.name + "!");
    }

    public void PerformAttack2()    // Sample of another attack and how it would need to reference it's own trigger (part of the animator object)
    {
        animator.SetTrigger("Base_Attack2");
        Debug.Log("Attacking with " + this.name + "!");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
        Debug.Log("Hit: " + col.name);
    }

    public void FireProjectile()
    {
        Fireball fireballInstance = Instantiate(fireball, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
