using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    //used for initialization
    public override void Init()
    {
        base.Init();
        //assign health property to our enemy health
        Health = base.health;
    }

    public void Damage()
    {
        Debug.Log("Moss Giant Damage");
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            
        }
    }
}
