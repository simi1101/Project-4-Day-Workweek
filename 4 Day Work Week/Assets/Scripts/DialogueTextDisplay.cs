using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTextDisplay : MonoBehaviour
{
    public TextMeshProUGUI dialog;
    public GameObject dialogBox;
    
    void Start()
    {
        dialogBox.SetActive(false);
    }

    public void PlayDialogue(DialogueHolder dialogue)
    {
        dialogBox.SetActive(true);
        dialog.text = dialogue.sentence;
        StopAllCoroutines();
        StartCoroutine(DialogueDisplayTimer());
    }

    IEnumerator DialogueDisplayTimer()
    {
        yield return new WaitForSeconds(10);
        dialogBox.SetActive(false);
    }
}
