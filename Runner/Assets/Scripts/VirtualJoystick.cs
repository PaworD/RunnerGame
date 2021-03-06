﻿using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour , IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image back;
    private Image joystick;
    private Vector3 inputVector;


    private void Start()
    {
        back = GetComponent<Image>();
        joystick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(back.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / back.rectTransform.sizeDelta.x);
            pos.y = (pos.y / back.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);

            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;


            joystick.rectTransform.anchoredPosition = new Vector3(inputVector.x * (back.rectTransform.sizeDelta.x / 3), inputVector.z * (back.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector3.zero;
        joystick.rectTransform.anchoredPosition = Vector3.zero;
    }


    public float Horizontal()
    {
        if(inputVector.x != 0)
        {
            return inputVector.x;
        } else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float Vertical()
    {
        if (inputVector.z != 0)
        {
            return inputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
    