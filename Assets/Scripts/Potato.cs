using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Potato : MonoBehaviour
{
    public Outline outline;

    public string potatoTag;

    public bool potatoInPlita = false;

    public bool isTimerRunning = false;

    public bool isOutline = false;
    public bool potatoMouse = false;
    public bool doNotTouch = false;

    public GameManager gameManager;

    public float potatoTimer = 0f;

    private Renderer potatoRenderer; 
    private void OnCollisionEnter(Collision collision)
    {
        potatoInPlita = true;

        if (collision.gameObject.CompareTag("potato"))
        {
            AudioManager.instance.Play("potato");
            gameManager.potatoSound = true;
            PlayOilSplashPotato();
        }
    }

    public void Update()
    {
        if (isTimerRunning)
        {
            potatoTimer += Time.deltaTime;
        }

        if (isOutline == true && potatoMouse == true && doNotTouch == false)
        {
            if (gameManager.potatoFried)
            {
                outline.enabled = true;
                Debug.Log("картошка жарена, включен контур.");
            }
            else if (gameManager.potatoBurn)
            {
                outline.enabled = true;
                Debug.Log("картошка сгорела, включен контур.");
            }
        }

        PotatoFried();

        if (!potatoInPlita)
        {
            AudioManager.instance.Stop("potato");
            gameManager.potatoSound = false;
            StopOilSplashPotato();
            Debug.Log("Картошка не во фритюре, остановка звука и масла.");
        }
    }
    public void PlayOilSplashPotato()
    {
        gameManager.oilSplashPotato.Play();
    }
    public void StopOilSplashPotato()
    {
        gameManager.oilSplashPotato.Stop();
    }
    public void PotatoFried()
    {
        if (potatoTimer >= 7f && potatoRenderer.material != gameManager.friedMeat)
        {
            GetComponent<Item>().componentTag = "картошка фри";
            potatoTag = "картошка";
            isOutline = true;
            potatoRenderer.material = gameManager.friedPotato; 
            gameManager.potatoFried = true;
            gameManager.potatoBurn = false;
            gameManager.potatoRaw = false;
            Debug.Log("картошка пожарена!");
        }

        if (potatoTimer >= 15f && potatoRenderer.material != gameManager.burnMeat)
        {
            potatoTag = "горелая картошка";
            GetComponent<Item>().componentTag = "горелая картошка фри";
            potatoRenderer.material = gameManager.burnPotato; 
            gameManager.potatoFried = false;
            gameManager.potatoBurn = true;
            gameManager.potatoRaw = false;
        }
    }
    void OnMouseEnter()
    {
            potatoMouse = true;
            if (outline != null && isOutline == true && doNotTouch == false)
            {
                outline.enabled = true; 
            }
    }

    void OnMouseExit()
    {
        potatoMouse = false;
        if (outline != null)
        {
            outline.enabled = false; 
        }
    }
    public void Start()
    {

        isTimerRunning = true;
        outline = GetComponent<Outline>();
        outline.enabled = false;
        potatoRenderer = GetComponent<Renderer>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.isRawPotato = true;

        GetComponent<Item>().componentTag = "сырая картошка фри";
        potatoTag = "сырая картошка";

        gameManager.fried = false;
    }
    void OnMouseDown()
    {
        if(gameManager.isBlock == false)
        {
            if (doNotTouch == false)
            {
                doNotTouch = true;

                isTimerRunning = false;
                gameManager.AddComponent(potatoTag);
                Debug.Log("Нажато на картошку.");

                gameManager.friedPotatoCheck = true;

                Vector3 currentPosition = this.gameObject.transform.position;

                Vector3 targetPosition = new Vector3(gameManager.potatoOblast.gameObject.transform.position.x,
                     gameManager.potatoOblast.gameObject.transform.position.y + 0.4f,
                     gameManager.potatoOblast.gameObject.transform.position.z);

                Vector3 newPosition = targetPosition + new Vector3(0, 0.4f, 0);
                this.gameObject.transform.position = newPosition;
                Quaternion rotation = Quaternion.Euler(-180, 180, 0);

                Debug.Log($"Перемещение картошки в новую позицию: {newPosition}");

                if (gameManager.potatoFried || gameManager.potatoBurn || gameManager.potatoRaw)
                {
                    isTimerRunning = false;
                    Debug.Log("Таймер остановлен.");
                }
                AudioManager.instance.Stop("potato");
                StopOilSplashPotato();
                Instantiate(gameManager.packedPotato, newPosition, rotation);
                Destroy(this.gameObject); 
            }
        }
        
    }
}
