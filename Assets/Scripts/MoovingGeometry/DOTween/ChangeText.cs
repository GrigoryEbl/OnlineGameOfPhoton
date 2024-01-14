using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text1;
    [SerializeField] private Text _text2;
    [SerializeField] private Text _text3;

    private void Start()
    {
        _text1.DOText("Changed text", 3f);
        _text2.DOText("Added text", 3f).SetRelative();
        _text3.DOText("Hack text", 3f, true, ScrambleMode.All);
    }
}

