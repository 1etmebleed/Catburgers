using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GastroBoxThree : MonoBehaviour
{
    public Outline outline; 

    public GameObject spawnedItem; 

    public int itemCount; 

    public GameManager gameManager;

    public GameObject hoverText;

    public GastroBox gastro;

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
        if (itemCount < 0)
        {
            itemCount = 0;
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
        if (gameManager.isBlock == false)
        {
            if (itemCount > 0)
            {
                if (gameManager.topBreadInWorld == false)
                {
                    if (gameManager.breadBottomReady)
                    {
                        if (gameManager.meatInPlita == false)
                        {
                            AudioManager.instance.Play("gastroClick");
                            Vector3 spawnLocation = new Vector3(gameManager.craftBurgerOblast.gameObject.transform.position.x,
                            gameManager.craftBurgerOblast.gameObject.transform.position.y + 0.3f,
                            gameManager.craftBurgerOblast.gameObject.transform.position.z);

                            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                            Instantiate(spawnedItem, spawnLocation, spawnRotation);
                            itemCount--;
                            gastro.itemCount--;
                            gameManager.topBreadInWorld = true;
                            gameManager.readyToSell = true;
                        }
                        else
                        {
                            gameManager.uved.ShowTextUved("Подождите пока дожарится мясо");
                            AudioManager.instance.Play("gastroBlock");
                        }
                    }
                    else
                    {
                        AudioManager.instance.Play("gastroBlock");
                        gameManager.uved.ShowTextUved("Не хватает булочки");
                    }
                }
                else
                {
                    gameManager.uved.ShowTextUved("Булочка уже накрыла бургер");
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
