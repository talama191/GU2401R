using DG.Tweening;
using UnityEngine;

public class DoMoveInSequence : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] Transform[] points;
    [SerializeField] int loopCount;
    [SerializeField] LoopType loopType;

    void Start()
    {
        FlexibleSequence();
    }

    private void FlexibleSequence()
    {
        Sequence sequence = DOTween.Sequence();

        foreach (var point in points)
        {
            sequence.Append(transform.DOMove(point.position, duration));
        }
        sequence.SetLoops(loopCount, loopType);
        sequence.Play();
    }

    private void SquareSequence()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.position.y + 1, 0.5f));
        sequence.Append(transform.DOMoveX(transform.position.x + 1, 0.5f));
        sequence.Append(transform.DOMoveY(transform.position.y, 0.5f));
        sequence.Append(transform.DOMoveX(transform.position.x, 0.5f));
        sequence.SetLoops(-1, LoopType.Yoyo);
    }
}
