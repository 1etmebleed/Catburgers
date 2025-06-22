using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GastroBoxTwo : MonoBehaviour
{
    public Outline outline; 

    public GameObject spawnedItem; //предмет который появляется когда его берешь

    public int itemCount; //количество предметов в ящике

    public GameManager gameManager;

    public float plusX;
    public float plusY;
    public float plusZ;

    public GameObject hoverText; // Ссылка на объект текста

    public bool isOpen = false; //открыт или нет

    public bool opened = false;


    public GameObject[] blocked;

    public bool salad;
    public bool tomat;
    public bool cheese;
    public bool pikuli;
    public bool onion;
    public bool perec;
    public bool mushrooms;

    public void Update()
    {
        if (hoverText.activeSelf)
        {
            if (hoverText.activeSelf)
            {
                ItemCheck();
                UpdateTextPosition();
            }
        }
        CheckOpen();
    }

    public void CheckOpen()
    {
        if (gameManager.saving.mushroomsOpen && mushrooms)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
        else if(gameManager.saving.perecOpen && perec)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
        else if(gameManager.saving.onionOpen && onion)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
        else if(gameManager.saving.pikuliOpen && pikuli)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
        else if(gameManager.saving.cheeseOpen && cheese)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
        else if(gameManager.saving.tomatOpen && tomat)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
        else if(gameManager.saving.saladOpen && salad)
        {
            for (int i = 0; i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
                opened = true;
            }
        }
    }
    public void ItemCheck()
    {
        if (!opened)
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = "Заблокировано";
        }
        else if (opened)
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = itemCount.ToString();
        }
    }
    void Start()
    {
        hoverText.SetActive(false);
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
        else
        {
            Debug.LogError("Outline component not found on " + gameObject.name);

        }
        opened = false;
        CheckOpen();

    }
    void OnMouseEnter()
    {
        if (gameManager.isBlock == false)
        {
            hoverText.SetActive(true);

            UpdateTextPosition();

            if (outline != null && opened)
            {
                outline.enabled = true;
            }
        }
    }
    void UpdateTextPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        hoverText.transform.position = mousePosition;

        if (!opened)
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = "Заблокировано";
        }
        else if (opened)
        {
            hoverText.GetComponent<TextMeshProUGUI>().text = itemCount.ToString();
        }
    }
    void OnMouseExit()
    {
        hoverText.SetActive(false);

        if (outline != null)
        {
            outline.enabled = false; 
        }
    }

    public void OnMouseDown()
    {
        if (gameManager.isBlock == false)
        {
            if (itemCount > 0)
            {
                if (gameManager.makingBurgerComponents.Count <= 7)
                {
                    if (gameManager.topBreadInWorld == false)
                    {
                        if (gameManager.breadBottomReady)
                        {
                            Vector3 spawnLocation = new Vector3(gameManager.craftBurgerOblast.gameObject.transform.position.x + plusX,
                            gameManager.craftBurgerOblast.gameObject.transform.position.y + plusY,
                            gameManager.craftBurgerOblast.gameObject.transform.position.z + plusZ);

                            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                            Instantiate(spawnedItem, spawnLocation, spawnRotation);

                            AudioManager.instance.Play("gastroClick");

                            itemCount--;
                        }
                        else
                        {
                            gameManager.uved.ShowTextUved("Нет булочки!");
                            AudioManager.instance.Stop("gastroBlock");
                        }
                    }
                    else
                    {
                        gameManager.uved.ShowTextUved("Бургер уже собран");
                        AudioManager.instance.Play("gastroBlock");
                    }
                }
                else
                {
                    gameManager.uved.ShowTextUved("Превышены компоненты (максимум 7)");
                    AudioManager.instance.Play("gastroBlock");
                }
            }
            else
            {
                AudioManager.instance.Play("gastroBlock");
                gameManager.uved.ShowTextUved("Не хватает компонентов, купите их в магазине");
            }
        }   
    }

}
