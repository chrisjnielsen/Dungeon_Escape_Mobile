using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;
    private Animator _swordAnim;
   
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));   
    }

    public void Jump(bool jump)
    {
        GameManager.Instance.JumpPlayer();               
        _anim.SetBool("Jumping", jump);
    }

    public void Attack()
    {
        GameManager.Instance.AttackPlayer();
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("Sword_Animation");
    }

    public void Death()
    {
        GameManager.Instance.DeathPlayer();
        _anim.SetTrigger("Death");
    }

    IEnumerator PauseforSound()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
