using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get 
        {
            if(_instance == null)
            {
                Debug.LogError("UI Manager is null");
            }
            return _instance;
        
        }
    }

    public TextMeshProUGUI playerGemCountText;
    public Image selectionImage;
    public TextMeshProUGUI gemCountText;
    public Image[] healthBar;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
        
    }

    public void UPdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }
    
    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        //loop thorught lives
        //i==livesRemaining
        for(int i = 0; i <= livesRemaining; i++)
        {
            //do nothing till we hit max
            if(i==livesRemaining)
            {
                //hide this one
                healthBar[i].enabled = false;
            }
        }

        //hide that one

    }
}
