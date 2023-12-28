using UnityEngine;
using DG.Tweening;

namespace DOTween
{
    public class RotateCube : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _repeats;
        [SerializeField] private LoopType _loopType;

        private void Start()
        {
            transform.DORotate(new Vector3(0, 360, 0), _duration, RotateMode.FastBeyond360)
                .SetLoops(_repeats, _loopType)
                .SetEase(Ease.Linear);
        }
    }
}
