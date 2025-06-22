
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    public Transform currentTransform;
    public bool placePokupki;
    public bool placeMake;
    public VolumeControl musicControl;
    public VolumeControl soundsControl;
    public Slider musicSlider;
    public Slider soundsSlider;
    public GameObject doubleButton;
    public bool isDoubleAdw;
    public Color openColor;
    public Color closeColor;
    string[] trueOrderFraz = new string[] { "Спасибо!", "Ваау", "Вкуснота!", "Крууто!", "Ураа", "Нраааавится" };
    string[] falseOrderFraz = new string[] { "Неправильно", "Не то(", "Фу", "Обидно", "Не нравится" };
    public bool studyGo = false;
    [Header("СЕЙВ")]
    public Saving saving;
    [Header("Таймер")]
    public TextMeshProUGUI timer;

    [Header("Кнопка помощи")]
    public GameObject helpPanel;
    public bool helpPanelFlag;

    [Header("Продажа")]
    public bool readyToSell = false;
    public GameObject buttonSell;
    public GameObject craftBurgerOblast;

    [Header("Булочка")]
    public bool breadBottomReady;

    [Header("Баланс")]
    public int balance;
    public TextMeshProUGUI balanceText;

    [Header("Заказ")]
    public Cheque chequePrefab;
    public Order order;
    public GameObject orderGO;
    public bool orderReady = false;
    public Transform orderSpawnPoint;
    public Image orderImage;

    [Header("Массив заказов")]
    public List<Order> ordersPlayer; 
    public Order[] allOrders;

    [Header("Заработанная сумма")]
    public TextMeshProUGUI balanceForDayText;
    public int balanceForDay;

    [Header("Собираемый бургер")]
    public List<string> makingBurgerComponents = new List<string>();
    public bool trueOrder;
    public bool breadInWorld;
    public bool topBreadInWorld;
    

    [Header("Звуки")]
    public string[] randomMeow;

    [Header("Панели покупки и собирания")]
    public GameObject buyPanel; 
    public GameObject makePanel; 

    [Header("Мясо")]
    public GameObject meatOblast;
    public bool meatReady;
    public ParticleSystem oilSplash;
    public Material friedMeat; 
    public Material burnMeat; 
    public bool isFriedMeat;
    public bool isRawMeat;
    public bool isBurnMeat;
    public bool fried; //false - нельзя готовить новую котлету true- можно готовить новую котлету
    public bool meatInPlita;

    [Header("Лапки")]
    public GameObject[] lapkiGO;
    public GameObject thisLapka;
    public GameObject lapkaLeft;
    public GameObject lapkaRight;
    public float moveSpeed = 5f;
    public bool lapkaIsMoving = false;
    public bool isLeft = true;
    public GameObject chequePlace;
    public float lapkaTimer = 0.3f;

    [Header("Картошка")]
    public GameObject potatoOblast;
    public GameObject friturOblast;
    public bool potatoInWorld;
    public bool potatoSpawned;
    public bool potatoRaw;
    public bool potatoBurn;
    public bool potatoFried;
    public ParticleSystem oilSplashPotato;
    public Material friedPotato;
    public Material burnPotato;
    public GameObject packedPotato;
    public bool friedPotatoCheck; //false - нельзя готовить новую картошку true- можно готовить новую картошку
    public bool potatoReady;
    public bool isRawPotato;

    [Header("Кнопка собирания заново")]
    public GameObject makeAgainButton;

    [Header("Положение камеры")]
    public GameObject plitaPoint;
    public GameObject noutPoint;
    public GameObject cameraGO;

    [Header("Конец дня")]
    public GameObject dayOffPanel;

    [Header("текст баланса")]
    public TextMeshProUGUI balanceTMP;

    [Header("Реклама")]
    public GameObject advPanel;
    public TextMeshProUGUI advTextTMP;

    public float duration = 300f;
    private float remainingTime;
    public bool timerRunning = false;
    public TextMeshProUGUI timerText;

    [Header("Все гастро")]
    public GameObject[] gastros;

    public GameObject noutPokupkiPlace;

    public GameObject nextDayButton;

    private Coroutine timerCoroutine; 

    public GameObject learnYesOrNoGO;

    public GameObject[] StudySlide;
    private int currentSlideIndex = 0; 
    public GameObject SlidesPanel;

    public bool nextDay;
    public int nextDayIndex = 0;

    public GameObject settigsPanel;

    public bool potatoSound;
    public bool meatSound;

    public Tovar[] tovars;

    public GameObject potatoOrder;
    public bool potatoInOrder;

    public OrderAdded orderAdded;

    public TextMeshProUGUI balanceTextNextDay;
    public TextMeshProUGUI rewardForDayNextDay; 
    public TextMeshProUGUI dayCountNextDay; 
    public TextMeshProUGUI burgersCountNextDay;
    public GameObject nextDayButtonNext;

    public int dayCount = 1;
    public int burgersCount; 

    public Dialogue dialogue;

    public bool isBlock;

    public NotifacationUved uved;

    public GameObject oblako;
    public TextMeshProUGUI oblakoText;

    public Toggle postProc;

    public PostProcessToggle toggle;

    public GameObject savingText;

    public void SaveMusicSlider()
    {
        saving.sliderValueMusic = musicControl.slider.value;
        saving.sliderValueSounds = soundsControl.slider.value;

        PlayerPrefs.SetFloat("sliderValueMusic", musicSlider.value);
        PlayerPrefs.SetFloat("sliderValueSounds", soundsSlider.value);
        PlayerPrefs.Save(); 
    }
    public void LoadMusicSlider()
    {
        float sliderValueMusic = PlayerPrefs.GetFloat("sliderValueMusic", 1.0f);
        float sliderValueSounds = PlayerPrefs.GetFloat("sliderValueSounds", 1.0f);

        Debug.Log($"Загруженное значение музыки: {sliderValueMusic}");
        Debug.Log($"Загруженное значение звуков: {sliderValueSounds}");

        musicSlider.value = sliderValueMusic;
        soundsSlider.value = sliderValueSounds;

        SetMixerGroupVolume(musicControl.mixer, musicControl.volumeParametr, sliderValueMusic);
        SetMixerGroupVolume(soundsControl.mixer, soundsControl.volumeParametr, sliderValueSounds);
    }

    private void SetMixerGroupVolume(AudioMixer mixer, string parameterName, float sliderValue)
    {
        float volume = Mathf.Lerp(-80f, 0f, sliderValue);

        mixer.SetFloat(parameterName, volume);
    }
    public void SaveGameButton()
    {
        saving.isPostProcessing = postProc.isOn;
        SaveMusicSlider();
        saving.SaveData();
        StartCoroutine(SavingC());
    }
    public IEnumerator SavingC()
    {
        savingText.SetActive(true);
        yield return new WaitForSeconds(2f);
        savingText.SetActive(false);
    }
    public void PostProcCheck()
    {
        postProc.isOn = saving.isPostProcessing; 
    }
    public void PostProcChecked()
    {
        if(saving.isPostProcessing)
        {
            toggle.postProcessVolume.enabled = true;
        }
        else 
        {
            toggle.postProcessVolume.enabled = false;
        }
    }
    public IEnumerator CatSpeakC(string words)
    {
        oblakoText.text = words;
        oblako.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.4f);
        oblako.gameObject.SetActive(false);
    }

    public void AddMoreTovarsCount()
    {
        for(int i =0;i< tovars.Length;i++)
        {
            if (tovars[i].isBuy)
            {
                int rand = Random.Range(tovars[i].randX, tovars[i].randY);
                tovars[i].ostatok += rand;
                tovars[i].UpdateGUI();
            }
        }
    }
    public void Cheat()
    {
        balance += 1000;
    }
    public void StopTimerOff()
    {
        StopCoroutine(timerCoroutine);
        timerText.text = "5:00";
    }
    public void StartTimerOff()
    {
        StartTimer(duration);
    }
    public void StartTimerOffComponent()
    {
        StartTimer(remainingTime);
    }
    public void LoadDay()
    {
        dayCount = saving.dayCount;
    }
    public void SaveDay()
    {
        saving.dayCount = dayCount;
    }
    public void CloseSettings()
    {
        isBlock = false;
        AudioManager.instance.Play("click");
        settigsPanel.SetActive(false);
    }
    public void OpenSettings()
    {
        isBlock = true;
        AudioManager.instance.Play("click");
        PostProcCheck();
        settigsPanel.SetActive(true);
    }
    public void SaveAllGastro()
    {
        for (int i = 0; i < gastros.Length; i++)
        {
            var saveGastro = gastros[i].GetComponent<SaveGastro>();
            if (saveGastro != null)
            {
                Debug.Log($"Saving gastro item {i}");
                saveGastro.SaveGastroItem();
            }
            else
            {
                Debug.LogWarning($"No SaveGastro component found on {gastros[i].name}");
            }
        }
    }
    public void LoadAllGastroItem()
    {
        if (gastros == null)
        {
            Debug.LogError("gastros array is null.");
            return;
        }

        for (int i = 0; i < gastros.Length; i++)
        {
            if (gastros[i] == null)
            {
                Debug.LogError($"gastros[{i}] is null.");
                continue; 
            }

            SaveGastro saveGastro = gastros[i].GetComponent<SaveGastro>();
            if (saveGastro == null)
            {
                Debug.LogError($"SaveGastro component not found on gastros[{i}].");
                continue; 
            }

            saveGastro.LoadGastroItem();
        }
    }
    public void Study() 
    {
        SlidesPanel.SetActive(true);
        ShowSlide(currentSlideIndex);
    }
    void ShowSlide(int index)
    {
        foreach (GameObject slide in StudySlide)
        {
            slide.SetActive(false);
        }

        if (index >= 0 && index < StudySlide.Length)
        {
            StudySlide[index].SetActive(true);
        }
    }

    void NextSlide()
    {
        currentSlideIndex++; 

        if (currentSlideIndex >= StudySlide.Length)
        {
            currentSlideIndex = 0; 
            SlidesPanel.SetActive(false);
            isBlock = false;
            studyGo = false;
            makePanel.SetActive(true);
        }

        ShowSlide(currentSlideIndex); 
    }
    public void DoubleBalanceADV()
    {

        doubleButton.SetActive(false);
        YG2.RewardedAdvShow("0",() =>  
        {
            balanceForDay = balanceForDay * 2;
            rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        });
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();
        rewardForDayNextDay.text = "Заработано по х2: " + balanceForDay.ToString();

        isDoubleAdw = true;
    }
    public void StartTimer(float dduration)
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine); 
        }

        remainingTime = dduration; 
        timerRunning = true; 
        timerCoroutine = StartCoroutine(TimerCoroutine()); 
    }
    private IEnumerator TimerCoroutine()
    {
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1); 
            remainingTime -= 1; 

            UpdateTimerText(); 
        }

        timerRunning = false; 
        NextDay();
        Debug.Log("Таймер завершен!");
    }
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = $"{minutes:D2}:{seconds:D2}"; 
    }
    public void ShowLearh()
    {
        learnYesOrNoGO.SetActive(true);
        isBlock = true;
        makePanel.SetActive(false);

    }
    public void YesLearn()
    {
        learnYesOrNoGO.SetActive(false);
        SlidesPanel.SetActive(true);
        isBlock = true;
        makePanel.SetActive(false);
        studyGo = true;
        ShowSlide(currentSlideIndex); 
    }
    public void NoLearn()
    {
        learnYesOrNoGO.SetActive(false);
        isBlock = false;
        makePanel.SetActive(true);
        studyGo = false;
    }
    public void NextDay()
    {
        isBlock = true;
        StopTimerOff();
        dayOffPanel.SetActive(true);
        buyPanel.SetActive(false);
        makePanel.SetActive(false);
        StartCoroutine(NextDayPanelShowed());

    }
    public void NextDayForButton()
    {
        AudioManager.instance.Play("click");
        isBlock = true;
        StopTimerOff();
        dayOffPanel.SetActive(true);
        buyPanel.SetActive(false);
        makePanel.SetActive(false);
        StartCoroutine(NextDayPanelShowed());

    }
    public IEnumerator NextDayPanelShowed()
    {
        doubleButton.gameObject.SetActive(false);
        dayCountNextDay.gameObject.SetActive(false);
        burgersCountNextDay.gameObject.SetActive(false);
        rewardForDayNextDay.gameObject.SetActive(false);
        balanceTextNextDay.gameObject.SetActive(false);
        nextDayButtonNext.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        dayCountNextDay.gameObject.SetActive(true);
        dayCountNextDay.text = "День " + dayCount.ToString();
        AudioManager.instance.Play("uved3");

        yield return new WaitForSeconds(0.5f);
        burgersCountNextDay.gameObject.SetActive(true);
        burgersCountNextDay.text = "Бургеров сделано " + burgersCount.ToString();
        AudioManager.instance.Play("uved3");

        yield return new WaitForSeconds(0.5f);
        rewardForDayNextDay.gameObject.SetActive(true);
        rewardForDayNextDay.text = "Заработок: " + balanceForDay.ToString();
        AudioManager.instance.Play("uved2");

        yield return new WaitForSeconds(0.5f);
        int balancee = 0;
        balancee += balance;
        balanceTextNextDay.text = "Баланс: " + balancee.ToString();
        balanceTextNextDay.gameObject.SetActive(true);
        AudioManager.instance.Play("uved2");
        balancee = 0;
        yield return new WaitForSeconds(0.5f);
        nextDayButtonNext.gameObject.SetActive(true);
        doubleButton.gameObject.SetActive(true);
        AudioManager.instance.Play("uved2");
    }
    public IEnumerator NextDayFlag()
    {
        yield return new WaitForSeconds(1);
    }
    
    public void NextDayButton()
    {
        isBlock = false;
        SaveMusicSlider();
        AudioManager.instance.Play("click");
        StopTimerOff();
        balance += balanceForDay;
        balance += 50;
        balanceForDay = 0;
        saving.balance = balance;
        AddMoreTovarsCount();
        SaveAllGastro();
        dayCount++;
        SaveDay();
        saving.isPostProcessing = postProc.isOn;
        saving.SaveData();
        if(isDoubleAdw == false)
        {
            StartCoroutine(ADV());
        }
        else if(isDoubleAdw == true)
        {
            dialogue.StartDialogue();
        }
        isDoubleAdw = false;
        orderAdded.DeleteOrders(ordersPlayer);
        orderAdded.RefreshOrders(ordersPlayer);
        orderAdded.AddDefaultOrders(ordersPlayer);
        dayOffPanel.SetActive(false);
        MakeAgainButton();
        nextDay = true;
        burgersCount = 0;
        nextDayButton.SetActive(false);
        doubleButton.SetActive(true);

    }
    public void ChangeCameraPosToPlita()
    {
        AudioManager.instance.Play("click");
        cameraGO.transform.position = plitaPoint.transform.position;
        placeMake = true;
        placePokupki = false;
    }
    public void ChangeCameraPosToNout()
    {
        AudioManager.instance.Play("click");
        cameraGO.transform.position = noutPoint.transform.position;
        placeMake = false;
        placePokupki = true;
    }
    public void MakeAgainButton()
    {
        NullMakingBurger();

        GameObject[] burgers = GameObject.FindGameObjectsWithTag("burger");
        foreach (GameObject burger in burgers)
        {
            Destroy(burger);
        }

        GameObject[] burgers2 = GameObject.FindGameObjectsWithTag("burger2");
        foreach (GameObject burger2 in burgers2)
        {
            Destroy(burger2);
        }

        GameObject[] burgers3 = GameObject.FindGameObjectsWithTag("burger3");
        foreach (GameObject burger3 in burgers3)
        {
            Destroy(burger3);
        }
        GameObject[] meats = GameObject.FindGameObjectsWithTag("meat");
        foreach (GameObject meat in meats)
        {
            Destroy(meat);
        }
        GameObject[] potatos = GameObject.FindGameObjectsWithTag("potato");
        foreach (GameObject potato in potatos)
        {
            Destroy(potato);
        }
        AudioManager.instance.Stop("friedMeat");
        AudioManager.instance.Stop("potato");

        oilSplashPotato.Stop();
        oilSplash.Stop();

        buttonSell.SetActive(false);
        makeAgainButton.SetActive(false);
        readyToSell = false;
        breadBottomReady = false;
        meatInPlita = false;
    }
    void Update()
    {
        CheckBalance();
        SellChecked();
        CheckBalanceForDay();
        if (order != null)
        {
            orderReady = chequePrefab.goOrder;
        }
        if(isLeft && lapkaIsMoving)
        {
            MoveObjectToLeft(orderGO,0.05f,0.1f);
            MoveObjectToLeft(thisLapka,0,0);
            orderGO.transform.SetParent(null);
        }
        else if(!isLeft && lapkaIsMoving)
        {
            orderGO.transform.SetParent(null);
            MoveObjectToRight(thisLapka,0,0);
        }
        if (remainingTime == 240) 
        {
            nextDayButton.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) && studyGo) 
        {
            NextSlide();
        }
        if(studyGo)
        {
            cameraGO.transform.position = noutPokupkiPlace.transform.position;
        }
        else
        {

            if(placeMake && !placePokupki)
            {
                cameraGO.transform.position = plitaPoint.transform.position;
            }
            else if (!placeMake && placePokupki)
            {
                cameraGO.transform.position = noutPoint.transform.position;
            }
        }
        if (duration == 3)
        {
            AudioManager.instance.Play("timer");
        }
        if(duration == 0 || timerRunning == false)
        {
            AudioManager.instance.Stop("timer");
        }
        
    }

    public IEnumerator MoveLapka()
    {
        isLeft = true;
        //MoveObjectToLeft(orderGO);
        //MoveObjectToLeft(thisLapka);
        yield return new WaitForSeconds(lapkaTimer);
        lapkaIsMoving = false;
        yield return new WaitForSeconds(lapkaTimer);
        isLeft = false;
        lapkaIsMoving = true;
        //MoveObjectToRight(thisLapka);
        RefuseChild();
        yield return new WaitForSeconds(lapkaTimer);
        lapkaIsMoving = false;
        isLeft = true;
    }
    public void GoMoveLapka()
    {
        lapkaIsMoving = true;
        StartCoroutine(MoveLapka());
    }
    public void GetChild()
    {
        if (orderGO != null)
        {
            if (orderGO.transform.childCount > 0)
            {
                Transform childTransform = orderGO.transform.GetChild(0);

                thisLapka = childTransform.gameObject;

                thisLapka.transform.SetParent(orderGO.transform);

                Debug.Log("Получен дочерний объект: " + thisLapka.name);
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
    public IEnumerator ADV()
    {
        yield return new WaitForSeconds(0.001f);
        //advPanel.SetActive(true);
        //advTextTMP.text = "Реклама через 3";
        //yield return new WaitForSeconds(1f);
        //advTextTMP.text = "Реклама через 2";
        //yield return new WaitForSeconds(1f);
        //advTextTMP.text = "Реклама через 1";
        //yield return new WaitForSeconds(1f);
        YG2.InterstitialAdvShow();
        dialogue.StartDialogue();

    }
    public void RefuseChild()
    {
        if (thisLapka != null)
        {
            thisLapka.transform.SetParent(null); 


            thisLapka.transform.position = new Vector3(0, 0, 0); 

            Debug.Log("Объект " + thisLapka.name + " был отделен от cheque.");
        }
        else
        {
            Debug.LogWarning("thisGO не установлен!");
        }
    }
    public void MoveObjectToLeft(GameObject obj, float up,float right)
    {
        if (obj == null)
        {
            Debug.LogError("Переданный объект равен null!");
            return;
        }

        Vector3 targetPosition = new Vector3(lapkaLeft.transform.position.x, lapkaLeft.transform.position.y, lapkaLeft.transform.position.z);
        Vector3 objTargetPos = new Vector3(lapkaLeft.transform.position.x + right, lapkaLeft.transform.position.y + up, lapkaLeft.transform.position.z);


        obj.transform.position = Vector3.MoveTowards(obj.transform.position, objTargetPos, moveSpeed * Time.deltaTime);
    }
    public void MoveObjectToRight(GameObject obj,float up,float right)
    {
        if (obj == null)
        {
            Debug.LogError("Переданный объект равен null!");
            return;
        }

        Vector3 targetPosition = lapkaRight.transform.position;
        Vector3 objTargetPos = new Vector3(lapkaLeft.transform.position.x + right, lapkaLeft.transform.position.y + up, lapkaLeft.transform.position.z);

        obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void ChangeLapka()
    {
        int x = Random.Range(0, lapkiGO.Length);

        Vector3 targetPosition = new Vector3(lapkaLeft.gameObject.transform.position.x - 2.1f,
                                             lapkaLeft.gameObject.transform.position.y,
                                             lapkaLeft.gameObject.transform.position.z);

        if (thisLapka != null)
        {
            Destroy(thisLapka.gameObject);
        }

        Vector3 newPosition = targetPosition + new Vector3(0, 0, 0); 
        thisLapka = Instantiate(lapkiGO[x], newPosition, Quaternion.Euler(-90, 0, 180));
    }

    public void ClearPotato()
    {
        potatoInWorld = false;
        potatoSpawned = false;
    }
    public void SetRandomLapka()
    {
        if (lapkiGO.Length == 0)
        {
            Debug.LogError("Массив моделей пуст!");
            return;
        }

        int randomIndex = Random.Range(0, lapkiGO.Length);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        GameObject modelInstance = Instantiate(lapkiGO[randomIndex], transform.position, transform.rotation);
        modelInstance.transform.SetParent(transform); 
    }
    public void ClearFriedPotato()
    {
        potatoRaw = false;
        potatoBurn = false;
        potatoFried = false;

        potatoReady = false;

        oilSplashPotato.Stop();
        AudioManager.instance.Stop("potato");
    }
    public void ClearFried()
    {
        isFriedMeat = false;
        isRawMeat = false;
        isBurnMeat = false;

        meatReady = false;

        oilSplash.Stop();
        AudioManager.instance.Stop("friedMeat");
    }
    public void GoMakeButton()
    {
        buyPanel.SetActive(false);
        makePanel.SetActive(true);
    }
    public void NullMakingBurger()
    {
        makingBurgerComponents.Clear();

        breadInWorld = false;
        topBreadInWorld = false;

        if(potatoInWorld == true)
        {
            ClearPotato();
        }
        if(meatInPlita)
        {

        }
    }
   
    public void AddComponent(string componentTag)
    {
        makingBurgerComponents.Add(componentTag);
        Debug.Log($"Добавлено в makingBurgerComponents: {componentTag}");
    }
    public void CheckBurgerList(GameObject order, List<string> componentTags)
    {
        if (order == null)
        {
            Debug.LogError("Order is null.");
            trueOrder = false;
            return;
        }

        Cheque cheque = order.GetComponent<Cheque>();
        if (cheque == null)
        {
            Debug.LogError("Cheque component is missing from the order.");
            trueOrder = false; 
            return;
        }

        if (cheque.components == null || cheque.components.Count == 0)
        {
            Debug.LogError("Order components are null or empty.");
            trueOrder = false;
            return;
        }

        if (componentTags.Count == 0 || componentTags.Count < 1 || componentTags == null)
        {
            Debug.LogError("Component tags are null.");
            trueOrder = false; 
            return;
        }

        var orderComponentCount = cheque.components
            .GroupBy(tag => tag)
            .ToDictionary(group => group.Key, group => group.Count());

        bool allMatch = true;
        foreach (var tag in componentTags)
        {
            if (!orderComponentCount.TryGetValue(tag, out int count) || count < componentTags.Count(t => t == tag))
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)
        {
            Debug.Log("Все компоненты совпадают.");
            trueOrder = true;
            if(makingBurgerComponents == null)
            {
                trueOrder = false;
            }
        }
        else
        {
            Debug.Log("Не все компоненты совпадают.");
            trueOrder = false;
        }
    }
    void PrintAllOrders()
    {
        if (ordersPlayer == null || ordersPlayer.Count == 0)
        {
            Debug.LogError("Нет доступных заказов!");
            return;
        }

        foreach (Order o in ordersPlayer)
        {
            if (o != null) 
            {
                Debug.Log($"Заказ: {o.orderName}");
            }
        }
    }
    void AssignRandomOrder()
    {
        List<Order> validOrders = new List<Order>();
        foreach (Order o in ordersPlayer)
        {
            if (o.components != null && o.components.Count > 0)
            {
                validOrders.Add(o);
            }
        }

        if (validOrders.Count == 0)
        {
            Debug.LogError("Нет валидных заказов с компонентами!");
            return;
        }
        int randomIndex = Random.Range(0, validOrders.Count);
        order = validOrders[randomIndex];
        orderImage.sprite = order.sprite;

        Debug.Log($"Выбран заказ: {order.orderName} с компонентами: {string.Join(", ", order.components)}");

        RandomPotato();

        chequePrefab.components.Clear();
        for (int i = 0; i < order.components.Count; i++)
        {

            if (i < chequePrefab.components.Count)
            {
                chequePrefab.components[i] = order.components[i]; 
            }
            else
            {
                chequePrefab.components.Add(order.components[i]); 
            }
        }

        if (potatoInOrder)
        {
            chequePrefab.components.Add("картошка"); 
        }
        Debug.Log($"Компоненты в Cheque: {string.Join(", ", chequePrefab.components)}");

    }
    void Start()
    {
        savingText.SetActive(false);
        isBlock = true;
        studyGo = false;
        saving.LoadData();
        LoadMusicSlider();
        LoadDay();
        LoadAllGastroItem();
        LoadMusicSlider();
        orderAdded.DeleteOrders(ordersPlayer);
        orderAdded.RefreshOrders(ordersPlayer);
        orderAdded.AddDefaultOrders(ordersPlayer);
        //if (!timerRunning)
        //{
        //    StartTimer();
        //}
        placeMake = true;
        placePokupki = false;
        if (saving.firstGame == true)
        {
            saving.firstGame = false;
        }
        balance = saving.balance;
        oilSplashPotato.Stop();
        oilSplash.Stop();
        randomMeow = new string[] { "meow1", "meow2", "meow3" };
        AudioManager.instance.Play("soundtrack");
        AssignRandomOrder();
        buttonSell.gameObject.SetActive(false);
        PrintAllOrders();
        StartCoroutine(NextOrderIEforStart());
        nextDayButton.SetActive(false);
        PostProcChecked();
        dialogue.StopDialogue();
        dialogue.StartDialogue();
        if (dialogue.dialogues.Count > 0)
        {
            dialogue.dialogues.RemoveAt(0);
            print("Первый элемент был удален.");
        }
        dialogue.textComponent.text = "(Тык чтобы продолжить...)";
        if (saving.firstGame == true)
        {
            learnYesOrNoGO.SetActive(true);
        }
        else
        {
            learnYesOrNoGO.SetActive(false);
        }
        SlidesPanel.SetActive(false);
    }
    public void CheckBalanceForDay()
    {
        balanceForDayText.text = "Заработано:" + balanceForDay.ToString();
    }
    public void SellChecked()
    {
        buttonSell.SetActive(readyToSell);
        makeAgainButton.SetActive(readyToSell);
    }
    public void CheckBalance()
    {
        balanceTMP.text = balance.ToString();
    }
    public void ButtonSell()
    {
        chequePrefab.body.isKinematic = true;
        CheckBurgerList(orderGO, makingBurgerComponents);
        GetGain(makingBurgerComponents);

        GameObject[] burgers = GameObject.FindGameObjectsWithTag("burger");
        foreach (GameObject burger in burgers)
        {
            Destroy(burger); 
        }

        GameObject[] burgers2 = GameObject.FindGameObjectsWithTag("burger2");
        foreach (GameObject burger2 in burgers2)
        {
            Destroy(burger2);
        }

        buttonSell.SetActive(false);
        makeAgainButton.SetActive(false);
        readyToSell = false;
        breadBottomReady = false;

        if (trueOrder)
        {
            balanceForDay += chequePrefab.gain;
            string randomPositivePhrase = GetRandomPhrase(trueOrderFraz);
            StartCoroutine(CatSpeakC(randomPositivePhrase));
            burgersCount++;
        }
        else
        {
            string randomNegativePhrase = GetRandomPhrase(falseOrderFraz);
            StartCoroutine(CatSpeakC(randomNegativePhrase));
        }
        order = null;
        orderReady = false; 

        NullMakingBurger();

        StartCoroutine(NextOrderIE());
    }
    private string GetRandomPhrase(string[] phrases)
    {
        int rand = Random.Range(0, phrases.Length);
        return phrases[rand];
    }
    public void NoneCats()
    {
    }
    public void TrueCats()
    {

    }
    public void BalanceTextUpdate()
    {
        balanceText.text = "Заработано: " + balance.ToString();
    }

    public void GetGain(List<string> componentTags)
    {
        int gain = 0;

        Dictionary<string, int> prices = new Dictionary<string, int>
        {
            { "салат", 50 },
            { "томат", 50 },
            { "котлета", 100 },
            { "сыр", 50 },
            { "пикули", 50 },
            { "красный перец", 80 },
            { "картошка", 200 },
            { "лук", 80 },
            { "грибы", 120 },
            { "горчица", 20 },
            { "кетчуп", 20 },
            { "майонез", 20 }
        };

        foreach (var component in componentTags)
        {
            if (prices.TryGetValue(component, out int price))
            {
                gain += price;
            }
        }

        chequePrefab.gain = gain;
    }

    public void NextOrder()
    {
        if (orderReady == false)
        {
            AssignRandomOrder();
            Debug.Log("Заказ рандомится");
        }
        else
        {
            Debug.Log("Заказ уже готов.");
        }
    }

    public IEnumerator NextOrderIE()
    {
        int randomIndex = Random.Range(0, 2);
        AudioManager.instance.Play(randomMeow[randomIndex]);

        yield return new WaitForSeconds(1f);

        AudioManager.instance.Play("money");

        GetChild();
        Vector3 targetPosition = new Vector3(chequePlace.gameObject.transform.position.x,
                                     chequePlace.gameObject.transform.position.y,
                                     chequePlace.gameObject.transform.position.z);
        // Телепортируем orderGO в позицию chequePlace
        orderGO.transform.position = targetPosition; // Замените chequePlace на вашу точку назначения
        ChangeLapka();
        // Привязываем orderGO к руке
        orderGO.transform.SetParent(thisLapka.gameObject.transform); // handTransform - это объект руки, куда вы хотите привязать orderGO

        Debug.Log("Объект телепортирован и привязан к руке");
        yield return new WaitForSeconds(1f);
        NextOrder();
        chequePrefab.UpdateOrderText();
        GoMoveLapka();
        yield return new WaitForSeconds(1.6f);
        chequePrefab.body.isKinematic = false;

        AudioManager.instance.Play("orderCreate");
        Debug.Log("Звук заказа создан");


        // Если нужно, можно включить объект обратно, если он был отключен ранее
        // orderGO.gameObject.SetActive(true);
        Debug.Log("Объект включен (если был отключен)");
    }
    private IEnumerator StartCountdown()
    {
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            Debug.Log($"Оставшееся время: {remainingTime:F2} секунд");
            remainingTime -= Time.deltaTime; // Уменьшаем оставшееся время
            yield return null; // Ждем следующий кадр
        }

        Debug.Log("Таймер завершен!");
    }
    public IEnumerator NextOrderIEforStart()
    {
        GetChild();
        Vector3 targetPosition = new Vector3(chequePlace.gameObject.transform.position.x,
                                     chequePlace.gameObject.transform.position.y,
                                     chequePlace.gameObject.transform.position.z);
        // Телепортируем orderGO в позицию chequePlace
        orderGO.transform.position = targetPosition; // Замените chequePlace на вашу точку назначения
        ChangeLapka();
        // Привязываем orderGO к руке
        orderGO.transform.SetParent(thisLapka.gameObject.transform); // handTransform - это объект руки, куда вы хотите привязать orderGO

        Debug.Log("Объект телепортирован и привязан к руке");
        yield return new WaitForSeconds(1f);
        NextOrder();
        chequePrefab.UpdateOrderText();
        GoMoveLapka();
        yield return new WaitForSeconds(1.6f);
        chequePrefab.body.isKinematic = false;

        // Если нужно, можно включить объект обратно, если он был отключен ранее
        // orderGO.gameObject.SetActive(true);
        Debug.Log("Объект включен (если был отключен)");
    }
    public void RandomPotato()
    {
        if(saving.potatoOpen)
        {
            int randomPotato = Random.Range(1, 3); // 1 - без картошки
                                                   // 2 - с картошкой
            if (randomPotato == 1)
            {
                potatoOrder.SetActive(false);
                potatoInOrder = false;
            }
            else if (randomPotato == 2)
            {
                potatoOrder.SetActive(true);
                potatoInOrder = true;
            }
        }
        else
        {
            potatoOrder.SetActive(false);
        }
    }
}
