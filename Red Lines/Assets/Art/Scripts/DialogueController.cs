using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField, TextArea(4,6)] private string[] _dialogueLines;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;

    [SerializeField] private float _time=0.05f;

    private bool _didDialogueStart=false;
    private int _lineIndex;

    private void OnMouseDown()
    {
        
    }
    void Start()
    {
        _dialoguePanel.SetActive(false);
    }

    void Update()
    {
        if (!_didDialogueStart)
        {
            StartDialogue();
        }
    }
    private void StartDialogue()
    {
        _didDialogueStart = true;
        _dialoguePanel.SetActive(true);
        _lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private IEnumerator ShowLine()
    {
        _dialogueText.text = string.Empty;

        foreach(char c in _dialogueLines[_lineIndex])
        {
            _dialogueText.text += c;
            yield return new WaitForSeconds(_time);
        }
    }
}
