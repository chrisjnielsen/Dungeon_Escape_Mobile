using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject AcidEffectPrefab;
    public int Health { get; set; }
    //used for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Update()
    {
        
    }

    public override void Movement()
    {
       
    }

    public void Damage()
    {
        if (isDead == true) return;
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;


        }

    }

    public void Attack()
    {
        //instantiate the acid effect
        Instantiate(AcidEffectPrefab, transform.position, Quaternion.identity);
    }

}
