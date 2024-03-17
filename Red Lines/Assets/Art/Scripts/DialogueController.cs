using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    [SerializeField, TextArea(4,6)] private string[] _dialogueLines;
    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] private TMP_Text _dialogueText;

    [SerializeField] private float _time=0.05f;

    private bool _didDialogueStart=false;
    private int _lineIndex;

    #region methods
    private void StartDialogue()
    {
        _didDialogueStart = true;
        _dialoguePanel.SetActive(true);
        _lineIndex = 0;
        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        _lineIndex++;
        if (_lineIndex < _dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            _didDialogueStart = false;
            SceneManager.LoadScene("Maria");

        }
    }
    private IEnumerator ShowLine()
    {
        _dialogueText.text = string.Empty;

        foreach (char c in _dialogueLines[_lineIndex])
        {
            _dialogueText.text += c;
            yield return new WaitForSeconds(_time);
        }
    }
    #endregion
    void Start()
    {
        _dialoguePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Return))
        {
            if (!_didDialogueStart)
            {
                StartDialogue();
            }
            else if (_dialogueText.text == _dialogueLines[_lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                _dialogueText.text = _dialogueLines[_lineIndex];
            }
        } 
    }
}
