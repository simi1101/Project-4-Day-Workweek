using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueHolder[] dialogue = new DialogueHolder[3];
    bool firstTriggered;
    bool secondTriggered;
    bool thirdTriggered;
    public bool playerDialogue;
    float dialogTimer;

    void Start()
    {
        firstTriggered = false;
        secondTriggered = false;
        thirdTriggered = false;
        dialogTimer = 9;
    }

    private void Update()
    {
        dialogTimer += Time.deltaTime;
    }

    void OnTriggerStay(Collider other)
    {
        if (dialogTimer >= 10)
        {
            if (other.gameObject.CompareTag("Player"))

                if (firstTriggered != true)
                {
                    {
                        FindObjectOfType<DialogueTextDisplay>().PlayDialogue(dialogue[0]);
                        firstTriggered = true;
                        dialogTimer = 0;
                    }
                }
                
            else if (firstTriggered == true && secondTriggered != true)
            {
                FindObjectOfType<DialogueTextDisplay>().PlayDialogue(dialogue[1]);
                secondTriggered = true;
                dialogTimer = 0;
            }
            else if (secondTriggered == true && thirdTriggered != true)
            {
                FindObjectOfType<DialogueTextDisplay>().PlayDialogue(dialogue[2]);
                thirdTriggered = true;
                dialogTimer = 0;
            }
        }
    }
}