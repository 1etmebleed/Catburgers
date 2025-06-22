using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Component : MonoBehaviour
{
    public bool salad;
    public bool tomat;
    public bool cheese;
    public bool pikuli;
    public bool onion;
    public bool perec;
    public bool mushrooms;
    public bool potato;

    public int price;
    public TextMeshProUGUI priceTMP;

    public GameManager gameManager;

    public GameObject gameObjectt;

    public Button button;

    public GastroBoxTwo gastroBoxTwo;
    public PotatoBox potatoBox;

    public bool component;

    void Start()
    {
        PriceTextUpdater();
        CheckOpenOrNot();
    }

    public void CheckOpenOrNot()
    {
        if(gameManager.saving.saladOpen && salad)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.tomatOpen && tomat)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.cheeseOpen && cheese)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.pikuliOpen && pikuli)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.onionOpen && onion)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.perecOpen && perec)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.mushroomsOpen && mushrooms)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
        else if (gameManager.saving.potatoOpen && potato)
        {
            priceTMP.text = "Уже куплено";
            button.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = gameManager.closeColor;
        }
    }
    void Update()
    {
        CheckOpenOrNot();
    }
    public void PriceTextUpdater()
    {
        priceTMP.text = "Открыть за: " + price.ToString();
    }

    public void BuyComponent()
    {
        if (gameManager.isBlock == false)
        {
            if (gastroBoxTwo != null && component && gameManager.balance >= price) //если ссылка на компонент назначена и флаг компонент = правда и баланс больше чем цена покупки
            {
                if (salad) //если салат и так далее ниже типо сыр пикули перец вот в скобках, то: 
                {
                    gameManager.saving.saladOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.balance -= price; //отнимаем баланс
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.saving.SaveData();
                    CheckOpenOrNot();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialogueSalad.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialogueSalad[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();

                }
                else if (cheese)
                {
                    gameManager.saving.cheeseOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.balance -= price;
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.saving.SaveData();
                    CheckOpenOrNot();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialogueCheese.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialogueCheese[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();

                }
                else if (tomat)
                {
                    gameManager.saving.tomatOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.balance -= price;
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.saving.SaveData();
                    CheckOpenOrNot();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialogueTomat.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialogueTomat[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();
                }
                else if (pikuli)
                {
                    gameManager.saving.pikuliOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.balance -= price;
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.saving.SaveData();
                    CheckOpenOrNot();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialoguePikuli.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialoguePikuli[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();
                }
                else if (onion)
                {
                    gameManager.saving.onionOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.balance -= price;
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.saving.SaveData();
                    CheckOpenOrNot();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialogueOnion.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialogueOnion[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();
                }
                else if (perec)
                {

                    gameManager.saving.perecOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.balance -= price;
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.saving.SaveData();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialoguePerec.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialoguePerec[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();
                }
                else if (mushrooms)
                {
                    gameManager.saving.mushroomsOpen = true;
                    gastroBoxTwo.CheckOpen();
                    gameManager.saving.SaveData();
                    gameManager.orderAdded.DeleteOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.RefreshOrders(gameManager.ordersPlayer);
                    gameManager.orderAdded.AddDefaultOrders(gameManager.ordersPlayer);
                    gameManager.balance -= price;
                    CheckOpenOrNot();

                    gameManager.dialogue.dialogues.Clear();
                    gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                    for (int i = 0; i < gameManager.dialogue.dialogueManager.dialogueMushrooms.Count; i++)
                    {
                        gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialogueMushrooms[i]);
                    }
                    gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                    gameManager.dialogue.StartComponentsDialogue();
                }
            }
            else
            {
                print("Не хватает денег или GastroBox не назначен");
            }
        }
    }
    public void BuyPotato()
    {
        if (gameManager.isBlock == false)
        {
            if (potatoBox != null && potato && gameManager.balance >= price) //если ссылка на картошк назначена и флаг компонент = правда и баланс больше чем цена покупки
            {
                gameManager.saving.potatoOpen = true;
                potatoBox.CheckPotatoOpen();
                gameManager.balance -= price; 
                gameManager.saving.SaveData();
                CheckOpenOrNot();

                gameManager.dialogue.dialogues.Clear();
                gameManager.dialogue.dialogues.Add("(Тык чтобы продолжить...)");
                for (int i = 0; i < gameManager.dialogue.dialogueManager.dialoguePotato.Count; i++)
                {
                    gameManager.dialogue.dialogues.Add(gameManager.dialogue.dialogueManager.dialoguePotato[i]);
                }
                gameManager.dialogue.textComponent.text = gameManager.dialogue.dialogues[0].ToString();

                gameManager.dialogue.StartComponentsDialogue();
            }
            else
            {
                print("Не хватает денег или potatoBox не назначен");
            }
        }  
    }
}
