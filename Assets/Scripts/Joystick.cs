using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform container;
    public RectTransform handle;

    private Vector2 inputVector = Vector2.zero;

    public float Horizontal { get { return inputVector.x; } }
    public float Vertical { get { return inputVector.y; } }

    private void Start()
    {
        if (!container) container = GetComponent<RectTransform>();
        if (!handle) handle = GetComponentInChildren<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        Vector2 containerWorldPos = container.position;
        Vector2 direction = position - containerWorldPos;

        inputVector = (direction.magnitude > container.sizeDelta.x / 2f) ?
            direction.normalized :
            direction / (container.sizeDelta.x / 2f);

        inputVector = Vector2.ClampMagnitude(inputVector, 1f);

        if (handle)
            handle.anchoredPosition = inputVector * (container.sizeDelta.x / 2f) * 0.3f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        if (handle)
            handle.anchoredPosition = Vector2.zero;
    }
}
