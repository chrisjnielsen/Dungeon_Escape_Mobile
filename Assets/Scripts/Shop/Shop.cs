using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject shopPanel;
    public int currentSelectedItem;
    public int currentItemCost;
    private Player _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
             _player = other.GetComponent<Player>();
            if (_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamonds);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        //0 = flame sword
        //1 = boots of flight
        //2 = key to castle
        Debug.Log("Button Selected");

        //switch between item

        switch (item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(50);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-52);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-160);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;
            default:
                break;
        }

    }

    public void BuyItem()
    {
        if (_player.diamonds >= currentItemCost)
        {
            //award item
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamonds -= currentItemCost;
            Debug.Log("Purchased: " + currentSelectedItem);
            Debug.Log("Remaining Gems: " + _player.diamonds);
            UIManager.Instance.OpenShop(_player.diamonds);
        }
        else
        {
            Debug.Log("You do not have enough gems. Closing shop");
            shopPanel.SetActive(false);
        }

    }

    //BuyItem Method
    //check if player gems is greater than or equal to itemCost
    //if it is, then awarditem (subtract cost from players gems)
    //else cancel sale

}
