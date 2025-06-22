using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GastroBox : MonoBehaviour
{
    public Outline outline; 

    public GameObject spawnedItem; //предмет который появляется когда его берешь

    public int itemCount; //количество предметов в ящике

    public GameManager gameManager;

    public GameObject hoverText;

    public GastroBoxThree gastro;
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
    }

    public void ItemCheck()
    {
        hoverText.GetComponent<TextMeshProUGUI>().text = itemCount.ToString();
        print("Текст обьекта = \u221E");
    }
    void OnMouseEnter()
    {
        if (gameManager.isBlock == false)
        {
            hoverText.SetActive(true);

            UpdateTextPosition();

            if (outline != null)
            {
                outline.enabled = true; 
            }
        }
            
    }
    void UpdateTextPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        hoverText.transform.position = mousePosition;
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
        if(gameManager.isBlock == false)
        {
            if (itemCount > 0)
            {
                if (gameManager.makingBurgerComponents.Count <= 7)
                {
                    if (gameManager.breadInWorld == false)
                    {
                        if (spawnedItem.GetComponent<Item>().isBread == true)
                        {
                            AudioManager.instance.Play("gastroClick");
                            gameManager.breadBottomReady = true;

                            if (gameManager.breadBottomReady)
                            {
                                Vector3 spawnLocation = new Vector3(gameManager.craftBurgerOblast.gameObject.transform.position.x,
                                    gameManager.craftBurgerOblast.gameObject.transform.position.y + 0.7f,
                                    gameManager.craftBurgerOblast.gameObject.transform.position.z);

                                Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                                Instantiate(spawnedItem, spawnLocation, spawnRotation);

                                itemCount--;
                                gastro.itemCount--;

                                gameManager.breadInWorld = true;
                            }
                        }
                        else if (spawnedItem.GetComponent<Item>().isBread == false)
                        {
                            gameManager.uved.ShowTextUved("Не хватает булочки");
                            AudioManager.instance.Play("gastroBlock");
                        }
                    }
                    else
                    {
                        gameManager.uved.ShowTextUved("Булочка уже лежит");
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
                gameManager.uved.ShowTextUved("Не хватает компонентов, купите их в магазине");
                AudioManager.instance.Play("gastroBlock");
            }
        }
    }

}
