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
        if (isDead == true) return;
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            //spawn a diamond
            //change value of diamond to whatever my gem count is
            
        }
    }
}
