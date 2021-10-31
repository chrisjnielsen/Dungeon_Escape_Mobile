using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    //used for initialization
    public override void Init()
    {
        base.Init();
        //assign health property to our enemy health
        Health = base.health;
        GameManager.Instance.SkeletonSound();
    }

    public override void Update()
    {
        base.Update();
    }

    public void Damage()
    {
        if (isDead == true) return;
        if (GameManager.Instance.HasFlameSword == true)
        {
            Health--;
            anim.SetTrigger("Hit");
            isHit = true;
        }
        else
        {
            //UI message that player needs a stronger sword
            UIManager.Instance.StatusMessage(1);
        }
        
        anim.SetBool("InCombat", true);
        if (Health < 1) 
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;

        }
        
    }
}
