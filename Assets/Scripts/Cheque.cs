using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cheque : MonoBehaviour
{
    public GameObject chequePanel; 
    public Outline outline;

    public int gain; 
    public GameManager gameManager;

    [Header("Состав заказа")]
    public List<string> components;

    public bool goOrder = true; 

    [SerializeField]
    private TextMeshProUGUI orderNameText; 

    [SerializeField]
    private TextMeshProUGUI orderComponentsText; 

    public Order order;

    public Rigidbody body;
    public void Update()
    {
        UpdateOrderText();

    }
    public void Start()
    {
        chequePanel.SetActive(false);

        for(int i = 0; i < components.Count; i++)
        {
            if (components[i] == null)
            {
                components[i] = gameManager.order.components[i];
            }
        }
    }

    public void UpdateOrderText()
    {
        order = gameManager.order;
        if (order != null)
        {
            orderNameText.text = order.orderName;

            string combinedText = "<mspace=5>";
            foreach (var component in components)
            {
                combinedText += component + "\n";
            }
        }
    }

    private void OnMouseEnter()
    {
        if (gameManager.isBlock == false)
        {
            if (outline != null)
            {
                outline.enabled = true;
                chequePanel.SetActive(true);
                UpdateOrderText();
            }
        }
    }

    private void OnMouseExit()
    {
        if (outline != null)
        {
            outline.enabled = false;
            chequePanel.SetActive(false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("plita"))
        {
            body.isKinematic = true;
        }
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] == null)
            {
                components[i] = gameManager.order.components[i];
            }
        }
    }
}