using DG.Tweening;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    private readonly float _duration = 3f;

    private void Start()
    {
        AnimateWater();
    }

    private void AnimateWater()
    {
        var startPosition = transform.localPosition;
        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMove(_targetPosition, _duration)).SetEase(Ease.Linear);
        sequence.Append(transform.DOLocalMove(startPosition, _duration)).SetEase(Ease.Linear);
        sequence.SetLoops(-1);
    }
}