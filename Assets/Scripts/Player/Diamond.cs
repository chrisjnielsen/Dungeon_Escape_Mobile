using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{

    //ontriggerenter to collect
    //check for player
    //add the value of diamonds to player
    public int gems = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //collect me
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.AddGems(gems);
               
                Destroy(this.gameObject);
            }
            
        }


    }

}
