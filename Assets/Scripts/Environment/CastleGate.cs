using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleGate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.Instance.HasKeyToCastle == true)
            {
                UIManager.Instance.StatusMessage(6);
                AudioManager.instance.PlaySound("Win");
            }
            else UIManager.Instance.StatusMessage(3);
        }
    }
}
