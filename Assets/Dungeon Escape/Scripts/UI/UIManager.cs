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

}
