using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PotatoBox : MonoBehaviour
{
    public Outline outline; 

    public GameObject spawnedItem; 

    public int itemCount; 

    public GameManager gameManager;

    public GameObject spawnPointObject;

    public GameObject hoverText;

    public GameObject[] blocked;

    public bool opened;

    public bool isPotato = true;

    void Start()
    {
        opened = false;
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
        CheckPotatoOpen();

    }

    void Update()
    {
        if (hoverText.activeSelf)
        {
            if (hoverText.activeSelf)
            {
                ItemCheck();
                UpdateTextPosition();
            }
        }
        if(gameManager.saving.potatoOpen)
        {
            for(int i = 0;i < blocked.Length; i++)
            {
                blocked[i].gameObject.SetActive(false);
            }
        }
        CheckPotatoOpen();
    }
    public void CheckPotatoOpen()
    {
        if (gameManager.saving.potatoOpen)
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
    }
    void OnMouseExit()
    {
            hoverText.SetActive(false);
            if (gameManager.saving.potatoOpen)
            {
                if (outline != null)
                {
                    outline.enabled = false; 
                }
            }
    }

    public void OnMouseDown()
    {
        if (gameManager.isBlock == false)
        {
            if (gameManager.saving.potatoOpen)
            {
                if (itemCount != 0 && itemCount > 0)
                {
                    if (gameManager.potatoInWorld == false)
                    {
                        if (gameManager.makingBurgerComponents.Count <= 7)
                        {
                            if (gameManager.topBreadInWorld == false)
                            {
                                if (gameManager.breadBottomReady)
                                {
                                    AudioManager.instance.Play("gastroClick");
                                    Vector3 spawnLocation = new Vector3(gameManager.friturOblast.gameObject.transform.position.x,
                                    gameManager.friturOblast.gameObject.transform.position.y + -0.1f,
                                    gameManager.friturOblast.gameObject.transform.position.z);

                                    Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                                    Instantiate(spawnedItem, spawnLocation, spawnRotation);
                                    gameManager.potatoInWorld = true;
                                    itemCount--;
                                }
                                else
                                {
                                    gameManager.uved.ShowTextUved("Сначала положите нижнюю булочку");
                                    AudioManager.instance.Play("gastroBlock");
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
                        gameManager.uved.ShowTextUved("Картошка уже готова");
                        AudioManager.instance.Play("gastroBlock");
                    }
                }
                else
                {
                    gameManager.uved.ShowTextUved("Не хватает компонентов, купите их в магазине");
                    AudioManager.instance.Play("gastroBlock");
                }
            }
            else
            {
                gameManager.uved.ShowTextUved("Картошка заблокирована");
                AudioManager.instance.Play("gastroBlock");
            }
        }   
    }
}
