using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RectTransform stick = null;
    [SerializeField] Image Background = null;
    [SerializeField] private int player = 0;

    public float limit = 250f;

    public void OnPointerDown(PointerEventData eventData)
    {
        stick.anchoredPosition = ConverToLocal(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = ConverToLocal(eventData);

        if (pos.magnitude > limit)
            pos = pos.normalized * limit;
        stick.anchoredPosition = pos;

        float x = pos.x / limit;
        float y = pos.y / limit;

        SetHorizontal(player, x);
        SetVertical(player, y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        stick.anchoredPosition = Vector2.zero;
        SetHorizontal(player,0);
        SetVertical(player,0);
    }

    private void OnDisable()
    {
        SetHorizontal(player,0);
        SetVertical(player,0);
    }

    void SetHorizontal(int player, float val)
    {
        InputManager.Instance.SetAxis("Horizontal" + player, val);
    }

    void SetVertical(int player, float val)
    {
        InputManager.Instance.SetAxis("Vertical" + player, val);
    }

    Vector2 ConverToLocal(PointerEventData eventData)
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out newPos);

        return newPos;
    }
}
