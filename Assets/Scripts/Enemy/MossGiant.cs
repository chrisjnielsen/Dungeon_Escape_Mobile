using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    private AudioSource _audioSource;

    //used for initialization
    public override void Init()
    {
        base.Init();
        //assign health property to our enemy health
        Health = base.health;
        
    }

    public override void Start()
    {
        base.Start();
        _audioSource = GameObject.Find("Sound_6_WalkMossGiant").GetComponent<AudioSource>();

    }

    public override void Update()
    {
        base.Update();

        
       

        if (isMoving==true)
        {
            if (!_audioSource.isPlaying) GameManager.Instance.WalkGiant();
        }
        else _audioSource.Stop();

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
            //UI message that player needs stronger sword
            UIManager.Instance.StatusMessage(1);
        }
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            GameManager.Instance.DeathMonster();
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            //spawn a diamond
            //change value of diamond to whatever my gem count is
            
        }
    }
}
