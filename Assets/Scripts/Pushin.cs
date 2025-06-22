using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushin : MonoBehaviour //скрипт для пушина, чтобы при нажатии играл звук
{
    public Outline outline;
    public GameObject pushin;

    public GameManager gameManager;
    void Start()
    {
        outline.enabled = false;
    }

    void Update()
    {

    }
    public void OnMouseDown()
    {
        if(gameManager.isBlock == false)
        {
            AudioManager.instance.Play("pisk");
        }
    }
    public void OnMouseEnter()
    {
        if (gameManager.isBlock == false)
        {
            outline.enabled = true;
        }
    }
    public void OnMouseExit()
    {
        outline.enabled = false;
    }
}

