using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance 
    {
        get
        {
            if (_instance == null)
                Debug.Log("UI Manager is null");
            return _instance;
        }
    }
    public int index;
    public GameObject blackOverlay;
    public TMP_Text _messageText;
    public TMP_Text _wristMenuSubtitleText;
    private void Awake()
    {
        _instance = this;
    }

    public void PlayDialogue(Dialogue dialogue)
    {
        index = 0;
        StartCoroutine(PlayDialogueRoutine(dialogue));
    }

    private IEnumerator PlayDialogueRoutine(Dialogue dialogue)
    {
        _messageText.transform.localPosition = dialogue.textPos;
        _messageText.transform.localEulerAngles = dialogue.textRotation;
        _messageText.color = dialogue.textColor;
        while(index != dialogue.subtitles.Length)
        {
            _messageText.text = dialogue.subtitles[index].message;
            blackOverlay.transform.localScale = dialogue.subtitles[index].blackOverlaySize;
            yield return new WaitForSeconds(dialogue.subtitles[index].secondsDisplayed);
            index++;
        }
        blackOverlay.transform.localScale = Vector3.zero;
        _messageText.text = "";
    }

    public void ToggleSubtitles()
    {
        if(_messageText.gameObject.activeInHierarchy == true)
        {
            _wristMenuSubtitleText.text = "Subtitles - OFF";
            _messageText.gameObject.SetActive(false);
            blackOverlay.SetActive(false);
        }
        else
        {
            _wristMenuSubtitleText.text = "Subtitles - ON";
            _messageText.gameObject.SetActive(true);
            blackOverlay.SetActive(true);
        }
    }
}
