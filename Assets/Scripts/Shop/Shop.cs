using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;
    private Player _player;

    public int currentselecteditem;
    public int currentItemCost;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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

    //Выделение айтема
    public void SelectItem(int item)
    {
        Debug.Log("SelectedItem" + item);

        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(51);
                currentselecteditem = 0;
                currentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-59);
                currentselecteditem = 1;
                currentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-161);
                currentselecteditem = 2;
                currentItemCost = 100;
                break;
        }
    }

    //Покупка
    public void BuyItem()
    {
        if (_player.diamonds >= currentItemCost)
        {
            if (currentselecteditem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }
            _player.diamonds -= currentItemCost;
            Debug.Log("Purchased " + currentselecteditem);
        }
        else
        {
            Debug.Log("No moneys");
        }
    }
}
