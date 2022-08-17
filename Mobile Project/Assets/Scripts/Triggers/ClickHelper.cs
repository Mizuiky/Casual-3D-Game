using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHelper : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Exit();
    }

    protected virtual void Enter() { }

    protected virtual void Exit() { }
}
