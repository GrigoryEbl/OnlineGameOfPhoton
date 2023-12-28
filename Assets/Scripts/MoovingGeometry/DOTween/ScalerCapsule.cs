using UnityEngine;
using DG.Tweening;

namespace DOTween
{
    public class ScalerCapsule : MonoBehaviour
    {
        [SerializeField] private Vector3 _scale;
        [SerializeField] private float _duration;
        [SerializeField] private int _repeats;
        [SerializeField] private LoopType _loopType;

        private void Start()
        {
            transform.DOScale(_scale, _duration).SetLoops(_repeats, _loopType).SetEase(Ease.Linear);
        }
    }
}
