using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen;
using Core.Singleton;

public class MainMenuHelper : MonoBehaviour
{
    [SerializeField]
    private ParticleController _particleController;

    [SerializeField]
    private ScreenType _type;

    private void Start()
    {
        UITouch.onTouchButton += GetParticleController;

        ScreenManager.Instance.HideAll();
        ScreenManager.Instance.ShowByType(_type);
    }

    private void OnDisable()
    {
        UITouch.onTouchButton -= GetParticleController;
    }

    public ParticleController GetParticleController()
    {
        if (_particleController != null)
            return _particleController;

        return null;
    }


}
