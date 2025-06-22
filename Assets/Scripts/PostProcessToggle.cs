using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessToggle : MonoBehaviour //toggle в меню настроек включающий\выключающий пост обработку в меню настроек
{
    public PostProcessVolume postProcessVolume;

    public GameManager gameManager;
    void Start()
    {
        if (postProcessVolume == null)
        {
            postProcessVolume = GetComponent<PostProcessVolume>();
        }
        if (gameManager.saving.isPostProcessing == true)
        {
            gameObject.GetComponent<Toggle>().isOn = true;
            postProcessVolume.enabled = true;

        }
        else if (gameManager.saving.isPostProcessing == false)
        {
            gameObject.GetComponent<Toggle>().isOn = false;
            postProcessVolume.enabled = false;

        }
    }
        public void TogglePostProcessing()
        {
            if (postProcessVolume != null)
            {
                postProcessVolume.enabled = !postProcessVolume.enabled;
            }
        gameManager.saving.balance = gameManager.balance;
        gameManager.saving.SaveData();
        }

}
