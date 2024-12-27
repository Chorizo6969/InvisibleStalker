using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PrintRandomText : MonoBehaviour
{
    [SerializeField] private TMP_Text _textDialogue;

    [Header("Délai entre les lettres")]
    [SerializeField] private float _letterDelay;

    [Header("Délai lorsque l'on rencontre un point")]
    [SerializeField] private float _punctuationDelay;

    [Header("Délai avant de passer à la lighe suivante")]
    [SerializeField] private float _lineDelay;

    /*[SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _letterSound;*/

    private int _lineIndex = -1;

    public bool IsFinished { get; private set; }

    [Header("lignes de dialogue")]
    public List<string> DialogueLines;

    //public event System.Action OnDialogueFinished; //Potentiel événement après le dialogue

    private void Start()
    {
        if (_textDialogue == null || DialogueLines == null || DialogueLines.Count == 0)
        {
            Debug.LogError("Dialogue system is not properly configured.");
            enabled = false;
        }
    }

    private async void OnEnable()
    {
        await StartDialogue();
    }

    public async Task StartDialogue()
    {
        IsFinished = false;
        _textDialogue.text = string.Empty;
        _lineIndex = -1;

        while (_lineIndex < DialogueLines.Count - 1)
        {
            _lineIndex++;
            string line = DialogueLines[_lineIndex];
            await PrintLineAsync(line);
            await Task.Delay((int)(_lineDelay * 1000));
        }

        IsFinished = true;
        //OnDialogueFinished?.Invoke();
        ClearDialogue();
    }

    private async Task PrintLineAsync(string line)
    {
        _textDialogue.text = string.Empty;
        foreach (char character in line)
        {
            _textDialogue.text += character;
            //_audioSource?.PlayOneShot(_letterSound);
            float delay = IsPunctuation(character) ? _punctuationDelay : _letterDelay;
            await Task.Delay((int)(delay * 1000));
        }
    }

    private void ClearDialogue()
    {
        _textDialogue.text = string.Empty;
    }

    private bool IsPunctuation(char c) => c is '?' or '.' or '!' or ',';
}
