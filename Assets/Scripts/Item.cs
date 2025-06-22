using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string componentTag;

    public bool needName = false;

    public bool isBread;

    public bool isBreadTop;

    public bool isMeat;

    public GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (needName && isMeat == false && gameManager.makingBurgerComponents.Count <= 7)
        {
            gameManager.AddComponent(componentTag);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("burger"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            transform.SetParent(other.transform);
        }

        if (other.CompareTag("burger2"))
        {
            Collider burgerCollider = GetComponent<Collider>();
            if (burgerCollider != null)
            {
                gameObject.tag = "burger2";
                Debug.Log("Тег изменён на burger2");
            }
        }
    }
}
