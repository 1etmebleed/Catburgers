using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset; 

    private RectTransform uiPanel;

    void Start()
    {
        uiPanel = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.transform.position);
            uiPanel.position = screenPoint + offset; 
        }
    } 
}
