using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nout : MonoBehaviour
{
    public Outline outline;

    public GameManager gameManager;

    [Header("Ноутбук")]
    public GameObject noutPanel;

    [Header("Магазин")]
    public GameObject shopPanel;

    [Header("Компоненты")]
    public GameObject componentsPanel;


    public void BackShopButton()
    {
        shopPanel.SetActive(false);
    }
    public void OpenShopButton()
    {
        shopPanel.SetActive(true);
    }




    public void BackComponentsButton()
    {
        componentsPanel.SetActive(false);
    }
    public void OpenComponentsButton()
    {
        componentsPanel.SetActive(true);
    }


    public void CloseNout()
    {
        gameManager.cameraGO.transform.position = gameManager.noutPoint.transform.position;
        gameManager.buyPanel.SetActive(false);
        gameManager.makePanel.SetActive(true);
    }
    public void OpenNout()
    {
        if(gameManager.isBlock == false)
        {
            gameManager.cameraGO.transform.position = gameManager.noutPokupkiPlace.transform.position;
            gameManager.buyPanel.SetActive(true);
            gameManager.makePanel.SetActive(false);
        }
    }
    public void OnMouseDown()
    {
        if(gameManager.isBlock == false)
        {
            OpenNout();
        }
    }
        void OnMouseEnter()
        {
        
        if (outline != null && gameManager.isBlock == false)
        {
            outline.enabled = true; 
        }
    }

    void OnMouseExit()
    {
        if (outline != null)
        {
            outline.enabled = false; 
        }
    }

    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }


    void Update()
    {
        
    }
}
