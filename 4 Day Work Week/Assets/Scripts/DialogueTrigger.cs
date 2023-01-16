using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueHolder dialogue;
    bool isTriggered;
    public bool playerDialogue;

    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))

            if (isTriggered != true)
            {
                {
                    FindObjectOfType<DialogueTextDisplay>().PlayDialogue(dialogue);
                    isTriggered = true;
                }
            }
    }
}