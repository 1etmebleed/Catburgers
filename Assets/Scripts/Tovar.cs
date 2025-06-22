using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tovar : MonoBehaviour
{
    public bool salad;
    public bool tomat;
    public bool cheese;
    public bool pikuli;
    public bool onion;
    public bool perec;
    public bool mushrooms;
    public bool potato;
    public bool bulka;
    public bool meat;

    public int price; 
    public int ostatok; 

    public TextMeshProUGUI priceTMP; 
    public TextMeshProUGUI ostatokTMP;

    public GameManager gameManager; 

    public GameObject gameObject;

    public Button button; 

    public GastroBox gastroBox;
    public GastroBoxTwo gastroBoxTwo;
    public GastroBoxThree gastroBoxThree;
    public MeatBox meatBox;
    public PotatoBox potatoBox;

    public bool component;

    public int plusItem;

    public int randX;
    public int randY;

    public bool canBuy = false;
    public bool isBuy = false;

    public bool isMeat;
    public bool isBread;

    public bool isOpened;

    private void Start()
    {
        if(isBread)
        {
            isBuy = true;
        }
        if(isMeat)
        {
            isBuy = true;
        }
        OpenChecker();
        if (canBuy)
        {
            GetMoreOstatok();
        }
        UpdateGUI();
        UpdateButtonState();
        if (bulka)
        {
            canBuy = true;
        }
        else if(meat)
        {
            canBuy = true;
        }
    }

    public void UpdateGUI()
    {
        if(isOpened == true)
        {
            priceTMP.text = "Купить за        " + price.ToString() + "кт";
            ostatokTMP.text = "В наличии:           " + ostatok.ToString() + " шт";
        }
    }
    public void OpenChecker()
    {
        if(isBread == true)
        {
            isOpened = true;
        }
        if(isMeat == true)
        {
            isOpened = true;
        }
        if (gameManager.saving.saladOpen == false && salad)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;

        }
        if (gameManager.saving.cheeseOpen == false && cheese)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;

        }
        if (gameManager.saving.tomatOpen == false && tomat)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;
        }
        if (gameManager.saving.pikuliOpen == false && pikuli)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;
        }
        if (gameManager.saving.perecOpen == false && perec)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;
        }
        if (gameManager.saving.onionOpen == false && onion)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;
        }
        if (gameManager.saving.mushroomsOpen == false && mushrooms)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;
        }
        if (gameManager.saving.potatoOpen == false && potato)
        {
            isBuy = false;
            priceTMP.text = "Заблокировано";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
            isOpened = false;
        }

    }
    private void UpdateButtonState()
    {
        if (salad && gameManager.saving.saladOpen) 
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }

        else if (tomat && gameManager.saving.tomatOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }
        else if(cheese && gameManager.saving.cheeseOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }
        else if(pikuli && gameManager.saving.pikuliOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }
        else if(onion && gameManager.saving.onionOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }
        else if(perec && gameManager.saving.perecOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }
        else if(mushrooms && gameManager.saving.mushroomsOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }
        else if(potato && gameManager.saving.potatoOpen)
        {
            isBuy = true;
            canBuy = true;
            button.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = gameManager.openColor;
            isOpened = true;
        }

        button.interactable = canBuy && ostatok > 0;
    }
    public void AddMore()
    {
        if(gameManager.nextDay == true)
        {
            GetMoreOstatok();
            gameManager.nextDay = false;
        }
    }
    public void BuyItem()
    {
        if (ostatok > 0 && button.interactable && gameManager.balance > price && component)
        {
            gastroBoxTwo.itemCount += plusItem;
            gameManager.balance -= price;
            ostatok--; 
            UpdateGUI();
            UpdateButtonState();
            isOpened = true;
        }
        else if (ostatok > 0 && button.interactable && gameManager.balance > price && meat)
        {
            meatBox.itemCount += plusItem;
            gameManager.balance -= price;
            ostatok--; 
            UpdateGUI(); 
            UpdateButtonState();
            isOpened = true;
        }
        else if (ostatok > 0 && button.interactable && gameManager.balance > price && potato )
        {
            potatoBox.itemCount += plusItem;
            gameManager.balance -= price;
            ostatok--; 
            UpdateGUI(); 
            UpdateButtonState();
            isOpened = true;
        }
        else if (ostatok > 0 && button.interactable && gameManager.balance > price && bulka)
        {
            gastroBox.itemCount += plusItem;
            gastroBoxThree.itemCount += plusItem;
            gameManager.balance -= price;
            ostatok--; 
            UpdateGUI(); 
            UpdateButtonState();
            isOpened = true;
        }
    }

    private void Update()
    {
        UpdateButtonState();
        OpenChecker();

        AddMore();

        UpdateGUI();
    }
    public void GetMoreOstatok()
    {
        int rand = Random.Range(randX, randY);
        ostatok += rand;
    }

}
