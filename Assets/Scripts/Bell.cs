using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bell : MonoBehaviour //скрипт для нажатия по звонку для воспроизведения звука 
{
    public Outline outline;
    void Start()
    {
        outline.enabled = false;
    }
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        AudioManager.instance.Play("orderCreate");
    }
    public void OnMouseEnter() 
    {
        outline.enabled = true;
    }
    public void OnMouseExit()
    {
        outline.enabled = false;
    }
}
