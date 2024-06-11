using UnityEngine;
using UnityEngine.EventSystems;

public class PointerTest : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
{
    [SerializeField] private Surfer surfer;

    private bool isDragging = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        surfer.DoJump();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 mouseUiPos = Input.mousePosition;
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.position = mouseUiPos;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
