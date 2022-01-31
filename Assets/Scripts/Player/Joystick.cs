using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image joystick;
    [SerializeField] private Image joystickBackground;
    [SerializeField] private PlayerMovement playerMovement;

    private void Start()
    {
        joystick.rectTransform.localPosition = Vector3.zero;
    }

    private void FixedUpdate()
    {
        playerMovement.Move(MoveDirection());
    }

    public void OnDrag(PointerEventData eventData)
    {
        var maxLen = joystickBackground.rectTransform.rect.width / 2;
        joystick.rectTransform.position = eventData.position;
        if (joystick.rectTransform.localPosition.magnitude > maxLen)
            joystick.rectTransform.localPosition = joystick.rectTransform.localPosition.normalized * maxLen;
    }

    public void OnPointerDown(PointerEventData eventData) {}
    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.rectTransform.localPosition = Vector3.zero;
    }

    public Vector3 MoveDirection()
    {
        if (joystick.rectTransform.localPosition.magnitude > 0.5)
            return joystick.rectTransform.localPosition.normalized;
        return Vector3.zero;
    }

    private void OnDisable()
    {
        joystick.rectTransform.localPosition = Vector3.zero;
    }
}
