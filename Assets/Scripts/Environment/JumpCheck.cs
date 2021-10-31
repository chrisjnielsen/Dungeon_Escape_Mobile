using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.Instance.HasBootsofFlight == true)
            {
                return;
            }
            else UIManager.Instance.StatusMessage(2);
        }
    }

}
