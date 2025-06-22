using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    public Outline outline; 

    public GameObject spawnedItem;

    public int itemCount; 

    public GameManager gameManager;

    public GameObject hoverText;
    void Start()
    {
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
    public void ItemCheck()
    {
        hoverText.GetComponent<TextMeshProUGUI>().text = "\u221E";
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
        if (gameManager.makingBurgerComponents.Count <= 7)
        {
            if (gameManager.topBreadInWorld == false)
            {
                if (gameManager.breadBottomReady)
                {
                    AudioManager.instance.Play("sauce");
                    Vector3 spawnLocation = new Vector3(gameManager.craftBurgerOblast.gameObject.transform.position.x,
                    gameManager.craftBurgerOblast.gameObject.transform.position.y + 0.4f,
                    gameManager.craftBurgerOblast.gameObject.transform.position.z);

                    Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                    Instantiate(spawnedItem, spawnLocation, spawnRotation);
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

}

