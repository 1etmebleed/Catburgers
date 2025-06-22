using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Claw : MonoBehaviour
{
    public GameObject thisGO;
    public GameObject cheque;
    public GameManager gameManager;

    public float moveSpeed = 5f;

    void Start() 
    {
        gameManager = FindObjectOfType<GameManager>();
        cheque = GameObject.FindWithTag("cheque");
    }


    void Update()
    {
        
    }
    public IEnumerator MoveLapka()
    {
        GetChild();
        MoveObjectToLeft(cheque);
        MoveObjectToLeft(thisGO);
        yield return new WaitForSeconds(1);
        MoveObjectToRight(thisGO);
        RefuseChild();
        yield return new WaitForSeconds(1);
    }
    public void GoMoveLapka()
    {
        StartCoroutine(MoveLapka());
    }
    public void GetChild()
    {
        if (cheque != null)
        {

            if (cheque.transform.childCount > 0)
            {
                Transform childTransform = cheque.transform.GetChild(0);

                thisGO = childTransform.gameObject;

                thisGO.transform.SetParent(cheque.transform);

                Debug.Log("Получен дочерний объект: " + thisGO.name);
            }
            else
            {
                Debug.LogWarning("У cheque нет дочерних объектов!");
            }
        }
        else
        {
            Debug.LogWarning("Cheque не установлен!");
        }
    }

    public void RefuseChild()
    {
        if (thisGO != null)
        {
            thisGO.transform.SetParent(null);

            thisGO.transform.position = new Vector3(0, 0, 0);

            Debug.Log("Объект " + thisGO.name + " был отделен от cheque.");
        }
        else
        {
            Debug.LogWarning("thisGO не установлен!");
        }
    }
    public void MoveObjectToLeft(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("Переданный объект равен null!");
            return;
        }
        Vector3 targetPosition = gameManager.lapkaLeft.transform.position;

        obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    public void MoveObjectToRight(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("Переданный объект равен null!");
            return;
        }
        Vector3 targetPosition = gameManager.lapkaRight.transform.position;

        obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
