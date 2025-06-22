using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public float typingSpeed = 0.05f; // Скорость печати
    [TextArea(0, 48)] // Ограничиваем ввод текста до 48 символов
    public List<string> dialogues; // Массив текстов для отображения
    private int currentDialogueIndex = 0; // Индекс текущего текста
    private string currentText = ""; // Текущий текст, который будет отображаться

    public TextMeshProUGUI textComponent; // Компонент UI Text, куда будет выводиться текст 
    public GameManager gameManager;

    private bool isTyping = false; 

    public Animator animator; 

    public DialogueManager dialogueManager;

    public GameObject panel;

    public bool isDialogueStart = true;

    public bool isComponentsDialogue;
    public bool isDialogueDefault;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isTyping && isDialogueStart)
        {
            if (currentDialogueIndex >= dialogues.Count)
            {
                currentDialogueIndex = 0; 

                if (isDialogueDefault == true && isComponentsDialogue == false)
                {
                    StopDialogue();
                    print("сработал Update(), функция StopDialogue();");
                }
                else if (isDialogueDefault == false && isComponentsDialogue == true)
                {
                    StopComponentsDialogue();
                    print("сработал Update(), функция StopComponentsDialogue();");
                }
            }

            StartCoroutine(Type(dialogues[currentDialogueIndex]));
            currentDialogueIndex++; 
        }
    }

    public IEnumerator Type(string dialogue)
    {
        isTyping = true; 


        if(isDialogueStart)
        {
            AudioManager.instance.Play("Dialogue");
        }

        animator.SetBool("isTyping", true);

        currentText = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            currentText += letter; 
            textComponent.text = currentText;
            yield return new WaitForSeconds(typingSpeed); 
        }
            AudioManager.instance.Stop("Dialogue");
            animator.SetBool("isTyping", false);

        isTyping = false; 
    }

    public void Start()
    {
        currentText = "";
        textComponent.text = currentText;
        isDialogueStart = true;
    }
    public void SkipDialogue()
    {
        
        if(isComponentsDialogue)
        {
            StopComponentsDialogue();
            print("сработал SkipDialogue(), функция StopComponentsDialogue();");
        }
        else
        {
            StopDialogue();
            print("сработал SkipDialogue(), функция StopDialogue();");
        }
    }
    public void StartDayDialogue()
    {
        if (gameManager.dayCount == 1)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue1.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue1[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 2)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue2.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue2[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 3)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue3.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue3[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 4)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue4.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue4[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 5)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue5.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue5[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 6)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue6.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue6[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 7)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue7.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue7[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 8)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue8.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue8[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 9)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue9.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue9[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount == 10)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");
            for (int i = 0; i < dialogueManager.dialogue10.Count; i++)
            {
                dialogues.Add(dialogueManager.dialogue10[i]);
            }
            textComponent.text = dialogues[0].ToString();
        }
        else if (gameManager.dayCount > 10)
        {
            dialogues.Clear();
            isDialogueDefault = true;
            gameManager.dialogue.dialogues.Add("(...)");

            int x = 0;
            RandomDialogue(x);

            dialogues.Add(dialogueManager.randomDialogue[x]);
        }
        textComponent.text = "(Тык чтобы продолжить..)";
    }
    public void RandomDialogue(int x)
    {
        int rand = Random.Range(0, dialogueManager.randomDialogue.Count);
        x = rand;
    }

    public void StartDialogue()
    {
        isComponentsDialogue = false;
        gameManager.StopTimerOff();
        StartDayDialogue();
        gameManager.makePanel.SetActive(false);
        isDialogueStart = true;
        panel.gameObject.SetActive(true);
        gameManager.isBlock = true;

    }
    public void StartComponentsDialogue()
    {
        gameManager.StopTimerOff();
        isDialogueDefault = false;
        isComponentsDialogue = true;
        isDialogueStart = true;
        panel.gameObject.SetActive(true);
        gameManager.isBlock = true;

    }
    public void StopComponentsDialogue()
    {
        gameManager.StartTimerOffComponent();
        isDialogueDefault = false;
        isComponentsDialogue = true;
        isDialogueStart = false;
        panel.gameObject.SetActive(false);
        gameManager.isBlock = false;

    }
    public void StopDialogue()
    {
        gameManager.makePanel.SetActive(true);
        isDialogueStart = false;
        panel.gameObject.SetActive(false);
        isComponentsDialogue = false;
        gameManager.duration = 300f;
        gameManager.StartTimerOff();
        gameManager.isBlock = false;
        AudioManager.instance.Stop("Dialogue");
    }
}
