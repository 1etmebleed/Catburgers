using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGastro : MonoBehaviour
{
    public GastroBox gastroBox;
    public GastroBoxTwo gastroBoxTwo;
    public GastroBoxThree gastroBoxThree;
    public MeatBox meatBox;
    public PotatoBox potatoBox;

    public GameManager gameManager;

    public bool salad;
    public bool tomat;
    public bool cheese;
    public bool pikuli;
    public bool onion;
    public bool perec;
    public bool mushrooms;
    public bool potato;
    public bool bulka;
    public bool bulkaDown;
    public bool meat;

    void Start()
    {

    }


    void Update()
    {
        
    }
    public void SaveGastroItem()
    {

        if (gastroBox != null)
        {
            gameManager.saving.bulkaCount = gastroBox.itemCount;
        }

            else if (salad && gameManager.saving.saladOpen && gastroBoxTwo != null)
            {
                gameManager.saving.saladCount = gastroBoxTwo.itemCount;
                Debug.Log($"Salad count saved: {gameManager.saving.saladCount}");
            }
            else if (tomat && gameManager.saving.tomatOpen && gastroBoxTwo != null)
            {
                gameManager.saving.tomatCount = gastroBoxTwo.itemCount;
                Debug.Log($"Tomat count saved: {gameManager.saving.tomatCount}");
            }
            else if(cheese && gameManager.saving.cheeseOpen && gastroBoxTwo != null)
            {
                gameManager.saving.cheeseCount = gastroBoxTwo.itemCount;
                Debug.Log($"Cheese count saved: {gameManager.saving.cheeseCount}");
            }
            else if(pikuli && gameManager.saving.pikuliOpen && gastroBoxTwo != null)
            {
                gameManager.saving.pikuliCount = gastroBoxTwo.itemCount;
                Debug.Log($"Pikuli count saved: {gameManager.saving.pikuliCount}");
            }
            else if(onion && gameManager.saving.onionOpen && gastroBoxTwo != null)
            {
                gameManager.saving.onionCount = gastroBoxTwo.itemCount;
                Debug.Log($"Onion count saved: {gameManager.saving.onionCount}");
            }
            else if(perec && gameManager.saving.perecOpen && gastroBoxTwo != null)
            {
                gameManager.saving.perecCount = gastroBoxTwo.itemCount;
                Debug.Log($"Perec count saved: {gameManager.saving.perecCount}");
            }
            else if(mushrooms && gameManager.saving.mushroomsOpen && gastroBoxTwo != null)
            {
                gameManager.saving.mushroomsCount = gastroBoxTwo.itemCount;
                Debug.Log($"Mushrooms count saved: {gameManager.saving.mushroomsCount}");
            }

        else if (meatBox != null)
        {
            if (meat)
            {
                gameManager.saving.meatCount = meatBox.itemCount;
                Debug.Log($"Meat count saved: {gameManager.saving.meatCount}");
            }
        }


        else if(potatoBox != null)
        {
            if (potato && gameManager.saving.potatoOpen)
            {
                gameManager.saving.potatoCount = potatoBox.itemCount; 
                Debug.Log($"Potato count saved: {gameManager.saving.potatoCount}");
            }
        }
    }
    public void LoadGastroItem()
    {

        if (gastroBox != null)
        {
            gastroBox.itemCount = gameManager.saving.bulkaCount;
            Debug.Log($"Bulka count loaded: {gastroBox.itemCount}");
        }

        else if(gastroBoxTwo != null)
        {
            if (gameManager.saving.saladOpen && salad)
            {
                gastroBoxTwo.itemCount = gameManager.saving.saladCount;
                Debug.Log($"Salad count loaded: {gastroBoxTwo.itemCount}");
            }
            else if(gameManager.saving.tomatOpen && tomat)
            {
                gastroBoxTwo.itemCount = gameManager.saving.tomatCount;
                Debug.Log($"Tomat count loaded: {gastroBoxTwo.itemCount}");
            }
            else if(gameManager.saving.cheeseOpen & cheese)
            {
                gastroBoxTwo.itemCount = gameManager.saving.cheeseCount;
                Debug.Log($"Cheese count loaded: {gastroBoxTwo.itemCount}");
            }
            else if (gameManager.saving.pikuliOpen && pikuli)
            {
                gastroBoxTwo.itemCount = gameManager.saving.pikuliCount;
                Debug.Log($"Pikuli count loaded: {gastroBoxTwo.itemCount}");
            }
            else if(gameManager.saving.onionOpen && onion)
            {
                gastroBoxTwo.itemCount = gameManager.saving.onionCount;
                Debug.Log($"Onion count loaded: {gastroBoxTwo.itemCount}");
            }
            else if(gameManager.saving.perecOpen && perec)
            {
                gastroBoxTwo.itemCount = gameManager.saving.perecCount;
                Debug.Log($"Perec count loaded: {gastroBoxTwo.itemCount}");
            }
            else if(gameManager.saving.mushroomsOpen && mushrooms)
            {
                gastroBoxTwo.itemCount = gameManager.saving.mushroomsCount;
                Debug.Log($"Mushrooms count loaded: {gastroBoxTwo.itemCount}");
            }
        }

        else if (meatBox != null)
        {
            meatBox.itemCount = gameManager.saving.meatCount;
            Debug.Log($"Meat count loaded: {meatBox.itemCount}");
        }

        else if (potatoBox != null)
        {
            if (gameManager.saving.potatoOpen)
            {
                potatoBox.itemCount = gameManager.saving.potatoCount;
                Debug.Log($"Potato count loaded: {potatoBox.itemCount}");
            }
        }
        else if(gastroBoxThree != null)
        {
            if (bulkaDown)
            {
                gastroBoxThree.itemCount = gameManager.saving.bulkaCount;
                Debug.Log($"Mushrooms count saved: {gameManager.saving.mushroomsCount}");
            }
        }
    }
}
