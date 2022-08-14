using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public Dialogue highSanity, lowSanity;
    public PlayerHealth playerHealth;
    public float trashold;
    public GameObject theCreatureStartButton;
    public bool hasTriggered;
    public GameObject gameOver;
    public GameObject dialogueBox;

    void Update()
    {
        if (playerHealth.sanity<trashold)
        { 
            theCreatureStartButton.GetComponent<DialogueTrigger>().dialogue = lowSanity;
        }
        else 
        {
            theCreatureStartButton.GetComponent<DialogueTrigger>().dialogue = highSanity;
        }

        if (dialogueBox.activeInHierarchy)
            hasTriggered = true;
        if (hasTriggered && !dialogueBox.activeInHierarchy)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }
}
