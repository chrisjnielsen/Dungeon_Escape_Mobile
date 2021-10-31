using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            PlayerAnimation anim = collision.GetComponent<PlayerAnimation>();
            player.Health = 0;
            anim.Death();
            //add message on screen that player died
            UIManager.Instance.StatusMessage(5);
        }
    }
}
