using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotifacationUved : MonoBehaviour
{
    public GameObject notificationPrefab; // Префаб текста уведомления
    public float displayDuration = 2f; // Время отображения уведомления
    public float moveSpeedText = 100f; // Скорость движения текста
    public float fadeDuration = 1f; // Время затухания

    public float xUved, yUved;

    public GameManager gameManager;
    public void ShowTextUved(string showedText)
    {
        StartCoroutine(ShowNotification(showedText));
    }

    private IEnumerator ShowNotification(string text) //показ текста на весь экран. 
    {
        GameObject notificationInstance = Instantiate(notificationPrefab, transform);
        TextMeshProUGUI notificationText = notificationInstance.GetComponent<TextMeshProUGUI>();
        notificationText.text = text;

        RectTransform rectTransform = notificationInstance.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(xUved, yUved);

        Vector2 targetPosition = new Vector2(-320, Screen.height / 2);

        float elapsedTime = 0f;

        while (elapsedTime < displayDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, (elapsedTime / displayDuration) * moveSpeedText * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Color color = notificationText.color;
        float fadeElapsedTime = 0f;

        while (fadeElapsedTime < fadeDuration)
        {
            color.a = Mathf.Lerp(1f, 0f, fadeElapsedTime / fadeDuration);
            notificationText.color = color;
            fadeElapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(notificationInstance);
    }

}
