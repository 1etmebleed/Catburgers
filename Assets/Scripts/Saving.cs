using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public int balance;

    public bool saladOpen;
    public bool tomatOpen;
    public bool cheeseOpen;
    public bool pikuliOpen;
    public bool onionOpen;
    public bool perecOpen;
    public bool mushroomsOpen;
    public bool potatoOpen;
    public bool gorchicaOpen;
    public bool mayonazeOpen;
    public bool ketchupOpen;
    public bool meatOpen;
    public bool bulkaOpen;

    public bool firstGame;

    public bool isPostProcessing;

    public int saladCount;
    public int tomatCount;
    public int cheeseCount;
    public int pikuliCount;
    public int onionCount;
    public int perecCount;
    public int mushroomsCount;
    public int potatoCount;
    public int bulkaCount;
    public int meatCount;

    public int dayCount;

    public float sliderValueSounds; // Значение слайдера
    public float volumeLevelSounds; // Уровень громкости

    public float sliderValueMusic; // Значение слайдера
    public float volumeLevelMusic; // Уровень громкости
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadData()
    {
        balance = PlayerPrefs.GetInt("balance", 100);
        saladOpen = PlayerPrefs.GetInt("saladOpen", 0) == 1;
        tomatOpen = PlayerPrefs.GetInt("tomatOpen", 0) == 1;
        cheeseOpen = PlayerPrefs.GetInt("cheeseOpen", 0) == 1;
        pikuliOpen = PlayerPrefs.GetInt("pikuliOpen", 0) == 1;
        onionOpen = PlayerPrefs.GetInt("onionOpen", 0) == 1;
        perecOpen = PlayerPrefs.GetInt("perecOpen", 0) == 1;
        mushroomsOpen = PlayerPrefs.GetInt("mushroomsOpen", 0) == 1;
        potatoOpen = PlayerPrefs.GetInt("potatoOpen", 0) == 1;
        gorchicaOpen = PlayerPrefs.GetInt("gorchicaOpen", 0) == 1;
        mayonazeOpen = PlayerPrefs.GetInt("mayonazeOpen", 0) == 1;
        ketchupOpen = PlayerPrefs.GetInt("ketchupOpen", 0) == 1;
        bulkaOpen = PlayerPrefs.GetInt("bulkaOpen", 1) == 1;
        meatOpen = PlayerPrefs.GetInt("meatOpen", 1) == 1;
        firstGame = PlayerPrefs.GetInt("FirstGame", 1) == 1;
        isPostProcessing = PlayerPrefs.GetInt("isPostProcessing", 1) == 1;

        saladCount = PlayerPrefs.GetInt("saladCount", 0);
        tomatCount = PlayerPrefs.GetInt("tomatCount", 0);
        cheeseCount = PlayerPrefs.GetInt("cheeseCount", 0);
        pikuliCount = PlayerPrefs.GetInt("pikuliCount", 0);
        onionCount = PlayerPrefs.GetInt("onionCount", 0);
        perecCount = PlayerPrefs.GetInt("perecCount", 0);
        mushroomsCount = PlayerPrefs.GetInt("mushroomsCount", 0);
        potatoCount = PlayerPrefs.GetInt("potatoCount", 0);
        bulkaCount = PlayerPrefs.GetInt("bulkaCount", 10);
        meatCount = PlayerPrefs.GetInt("meatCount", 5);

        // Загрузка значений слайдера и громкости
        sliderValueSounds = PlayerPrefs.GetFloat("sliderValueSounds", 1.0f); // По умолчанию 1.0
        volumeLevelSounds = PlayerPrefs.GetFloat("volumeLevelSounds", 1.0f); // По умолчанию 1.0

        sliderValueMusic = PlayerPrefs.GetFloat("sliderValueMusic", 0.3f); // По умолчанию 0.3
        volumeLevelMusic = PlayerPrefs.GetFloat("volumeLevelMusic", 0.3f); // По умолчанию 0.3

        dayCount = PlayerPrefs.GetInt("dayCount", 1);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("balance", balance);
        PlayerPrefs.SetInt("saladOpen", saladOpen ? 1 : 0);
        PlayerPrefs.SetInt("tomatOpen", tomatOpen ? 1 : 0);
        PlayerPrefs.SetInt("cheeseOpen", cheeseOpen ? 1 : 0);
        PlayerPrefs.SetInt("pikuliOpen", pikuliOpen ? 1 : 0);
        PlayerPrefs.SetInt("onionOpen", onionOpen ? 1 : 0);
        PlayerPrefs.SetInt("perecOpen", perecOpen ? 1 : 0);
        PlayerPrefs.SetInt("mushroomsOpen", mushroomsOpen ? 1 : 0);
        PlayerPrefs.SetInt("potatoOpen", potatoOpen ? 1 : 0);
        PlayerPrefs.SetInt("gorchicaOpen", gorchicaOpen ? 1 : 0);
        PlayerPrefs.SetInt("mayonazeOpen", mayonazeOpen ? 1 : 0);
        PlayerPrefs.SetInt("ketchupOpen", ketchupOpen ? 1 : 0);
        PlayerPrefs.SetInt("meatOpen", meatOpen ? 1 : 0);
        PlayerPrefs.SetInt("bulkaOpen", bulkaOpen ? 1 : 0);
        PlayerPrefs.SetInt("FirstGame", firstGame ? 1 : 0);
        PlayerPrefs.SetInt("isPostProcessing", isPostProcessing ? 1 : 0);

        PlayerPrefs.SetInt("saladCount", saladCount);
        PlayerPrefs.SetInt("tomatCount", tomatCount);
        PlayerPrefs.SetInt("cheeseCount", cheeseCount);
        PlayerPrefs.SetInt("pikuliCount", pikuliCount);
        PlayerPrefs.SetInt("onionCount", onionCount);
        PlayerPrefs.SetInt("perecCount", perecCount);
        PlayerPrefs.SetInt("mushroomsCount", mushroomsCount);
        PlayerPrefs.SetInt("potatoCount", potatoCount);
        PlayerPrefs.SetInt("bulkaCount", bulkaCount);
        PlayerPrefs.SetInt("meatCount", meatCount);

        PlayerPrefs.SetInt("dayCount", dayCount);

        // Сохранение значений слайдера и громкости
        PlayerPrefs.SetFloat("sliderValueSound", sliderValueSounds);
        PlayerPrefs.SetFloat("volumeLevelSound", volumeLevelSounds);

        PlayerPrefs.SetFloat("sliderValueMusic", sliderValueMusic);
        PlayerPrefs.SetFloat("volumeLevelMusic", volumeLevelMusic);

        PlayerPrefs.Save(); // Сохранение данных
    }
}
