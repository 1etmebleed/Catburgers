using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meat : MonoBehaviour
{
    public Outline outline;

    public string meatTag;

    public bool meatInPlita = false;

    public bool isTimerRunning = false;

    public bool isOutline = false;
    public bool meatMouse = false;
    public bool doNotTouch = false;

    public GameManager gameManager;

    public float meatTimer = 0f;

    private Renderer meatRenderer;

    public bool meatReady = false;

    private void OnCollisionEnter(Collision collision)
    {
        meatInPlita = true;

        if (collision.gameObject.CompareTag("plita"))
        {
            AudioManager.instance.Play("friedMeat");
            gameManager.potatoSound = true;
            PlayOilSplash();
        }
    }
    public void Update()
    {
        if(meatReady == false) 
        {
            gameManager.meatInPlita = meatInPlita;
        }

        if (isTimerRunning)
        {
            meatTimer += Time.deltaTime;
        }

        if (isOutline == true && meatMouse == true && doNotTouch == false)
        {
            if (gameManager.isFriedMeat)
            {
                meatReady = true;
                outline.enabled = true;
                Debug.Log("Мясо жареное, включен контур.");
            }
            else if (gameManager.isBurnMeat)
            {
                meatReady = true;
                outline.enabled = true;
                Debug.Log("Мясо сгорело, включен контур.");
            }
        }

        MeatFried();

        if (!meatInPlita)
        {
            AudioManager.instance.Stop("friedMeat");
            gameManager.potatoSound = false;
            StopOilSplash();
            Debug.Log("Мясо не в плите, остановка звука и масла.");
        }
    }
    void PlayOilSplash()
    {
        gameManager.oilSplash.Play(); 
    }
    void StopOilSplash()
    {
        gameManager.oilSplash.Stop();
    }
    public void Start()
    {
        isTimerRunning = true;
        outline = GetComponent<Outline>();
        outline.enabled = false;
        meatRenderer = GetComponent<Renderer>();
        gameManager = FindObjectOfType<GameManager>();
        gameManager.isRawMeat = true;

        GetComponent<Item>().componentTag = "сырая котлета";
        meatTag = "сырая котлета";

        gameManager.fried = false;
    }
    public void MeatFried()
    {
        if (meatTimer >= 7f && meatRenderer.material != gameManager.friedMeat)
        {
            GetComponent<Item>().componentTag = "котлета";
            meatTag = "котлета";
            isOutline = true;
            meatRenderer.material = gameManager.friedMeat; 
            gameManager.isFriedMeat = true;
            gameManager.isBurnMeat = false;
            gameManager.isRawMeat = false;
            Debug.Log("Мясо пожарено!");
        }

        if (meatTimer >= 15f && meatRenderer.material != gameManager.burnMeat)
        {
            meatTag = "горелая котлета";
            GetComponent<Item>().componentTag = "горелая котлета";
            meatRenderer.material = gameManager.burnMeat;
            gameManager.isFriedMeat = false;
            gameManager.isBurnMeat = true;
            gameManager.isRawMeat = false;
        }
    }
    void OnMouseEnter()
    {
        meatMouse = true;
        if (outline != null && isOutline == true && doNotTouch == false)
        {
            outline.enabled = true;
        }
    }

    void OnMouseExit()
    {
        meatMouse = false;
        if (outline != null)
        {
            outline.enabled = false; 
        }
    }
    void OnMouseDown()
    {
        if (gameManager.isBlock == false)
        {
            if (doNotTouch == false)
            {
                doNotTouch = true;

                isTimerRunning = false;
                gameManager.AddComponent(meatTag);
                Debug.Log("Нажато на мясо.");

                gameManager.fried = true;

                Vector3 currentPosition = this.gameObject.transform.position;

                Vector3 targetPosition = new Vector3(gameManager.craftBurgerOblast.gameObject.transform.position.x,
                     gameManager.craftBurgerOblast.gameObject.transform.position.y + 0.2f,
                     gameManager.craftBurgerOblast.gameObject.transform.position.z);

                Quaternion spawnRotation = Quaternion.Euler(-90, 0, 0);

                Vector3 newPosition = targetPosition + new Vector3(0, 0.2f, 0);
                this.gameObject.transform.position = newPosition;

                Debug.Log($"Перемещение мяса в новую позицию: {newPosition}");
                meatReady = true;
                gameManager.meatInPlita = false;

                gameManager.ClearFried();

                if (gameManager.isFriedMeat || gameManager.isBurnMeat || gameManager.isRawMeat)
                {
                    isTimerRunning = false;
                    Debug.Log("Таймер остановлен.");
                }
            }
        }
    }
}
