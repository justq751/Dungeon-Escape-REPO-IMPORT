using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public Text playerGemCountText;
    public Image selectionImage;
    public Text gemCountHUD;

    public Image[] healthBars;

    //Инстанс
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is Null");
            }
            return _instance;
        }
    }    

    //Проснись
    private void Awake()
    {
        _instance = this;
    }

    //Апдейт гемасов в шопе
    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    //Обновление количесвта гемасов
    public void UpdateGemCount(int count)
    {
        gemCountHUD.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for (int i=0; i <= livesRemaining; i++)
        {
            if (i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }
}
