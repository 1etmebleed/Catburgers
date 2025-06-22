using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MeatBox : MonoBehaviour
{
    public bool isMeat = true;
    public GameObject meatGO;

    public Outline outline;

    public int itemCount; 

    public GameManager gameManager;

    public GameObject hoverText;
    public void ItemCheck()
    {
        hoverText.GetComponent<TextMeshProUGUI>().text = itemCount.ToString();
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
    void Start()
    {
        hoverText.SetActive(false);
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false; 
            Debug.Log("Outline component found on " + gameObject.name);
        }
        else
        {
            Debug.LogError("Outline component not found on " + gameObject.name);
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
                            GameObject[] existingMeat = GameObject.FindGameObjectsWithTag("meat");

                            if (existingMeat.Length > 0)
                            {
                                AudioManager.instance.Play("gastroBlock");
                                gameManager.uved.ShowTextUved("Котлета уже на плите");
                                return;
                            }

                            Vector3 spawnLocation = new Vector3(gameManager.meatOblast.gameObject.transform.position.x,
                                gameManager.meatOblast.gameObject.transform.position.y + 0.2f,
                                gameManager.meatOblast.gameObject.transform.position.z);

                            Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                            Instantiate(meatGO, spawnLocation, spawnRotation);

                            AudioManager.instance.Play("gastroClick");

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
                    AudioManager.instance.Play("gastroBlock");
                    gameManager.uved.ShowTextUved("Превышены компоненты (максимум 7)");
                }
            }
            else
            {
                AudioManager.instance.Play("gastroBlock");
                gameManager.uved.ShowTextUved("Не хватает компонентов, купите их в магазине");
            }
        }
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
    }
}
