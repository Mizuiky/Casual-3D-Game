using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using UnityEngine.EventSystems;

public class UITouch : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Transform _instancePosition;

    [SerializeField]
    private ParticleType _type;

    private ParticleController _controllerReference;

    public delegate ParticleController OnTouchButton();
    public static event OnTouchButton onTouchButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_controllerReference == null)
            _controllerReference = onTouchButton?.Invoke();

        if (_controllerReference != null)
            _controllerReference.PlayParticleByType(_type, _instancePosition.position);
    }
}
