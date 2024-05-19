using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                UIManager.Instance.OpenShop(player.diamond);
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
                break;

            case 1:
                UIManager.Instance.UPdateShopSelection(6);
                break;

            case 2:
                UIManager.Instance.UPdateShopSelection(-106);
                break;


        }
    }
}
