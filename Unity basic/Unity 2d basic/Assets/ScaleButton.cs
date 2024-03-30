using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScaleButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float scale;
    [SerializeField] private float duration;
    [SerializeField] private int vibrato;
    [SerializeField] private float elasticity;

    public void OnPointerClick(PointerEventData eventData)
    {
        transform.DOPunchScale(transform.localScale * scale, duration, vibrato, elasticity);
    }
}
