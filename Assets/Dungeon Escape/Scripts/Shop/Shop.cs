using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    //variable for currentItemSelected
    public int currentSelectedItem;
    public int currentItemCost;

    private Player _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if(_player != null)
            {
                UIManager.Instance.OpenShop(_player.diamond);
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

    public void SelectItem(int Item)
    {
        Debug.Log("SelectItem()");

        switch (Item)
        {
            case 0:
                UIManager.Instance.UPdateShopSelection(106);
                currentSelectedItem = 0;
                currentItemCost = 200;
                break;

            case 1:
                UIManager.Instance.UPdateShopSelection(6);
                currentSelectedItem = 1;
                currentItemCost = 400;
                break;

            case 2:
                UIManager.Instance.UPdateShopSelection(-106);
                currentSelectedItem = 2;
                currentItemCost = 100;
                break;


        }
    }

    // Buy method

    public void BuyItemm()
    {
        if(_player.diamond >= currentItemCost)
        {
            if(currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            _player.diamond -= currentItemCost;
            Debug.Log("AwardItem");
            Debug.Log("Purchased" + currentSelectedItem);
            Debug.Log("Remaining gems" + _player.diamond);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Not enough gems");
            shopPanel.SetActive(false);
        }
    }
    // check if the slected item gem is <>= to player gem
    // if enoguh gem then awardItem, subtract gem 
    // or cancle sale. close shop

}
