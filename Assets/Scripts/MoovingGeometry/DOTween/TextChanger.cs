using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _changedText;
    [SerializeField] private Text _addedText;
    [SerializeField] private Text _hackedText;
    [SerializeField] private float _duration;

    private void Start()
    {
        _changedText.DOText("Changed text", _duration);
        _addedText.DOText("Added text", _duration).SetRelative();
        _hackedText.DOText("Hack text", _duration, true, ScrambleMode.All);
        
    }
}

