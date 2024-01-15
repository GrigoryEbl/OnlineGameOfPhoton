using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _changedText;
    [SerializeField] private float _duration;

    private void Start()
    {
        StartCoroutine(Change());
    }

    private IEnumerator Change()
    {
        _changedText.DOText("Changed text", _duration);
        yield return new WaitForSeconds(_duration);

        _changedText.DOText("Added text", _duration).SetRelative();
        yield return new WaitForSeconds(_duration);

        _changedText.DOText("Hack text", _duration, true, ScrambleMode.All);
        yield return new WaitForSeconds(_duration);
    }
}

