using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField]
    private GameObject[] _screens;

    public void SetScreenVisibility(ScreenType type, bool enable)
    {
        switch(type)
        {
            case ScreenType.START:
                _screens[0].SetActive(enable);
                break;
            case ScreenType.PAUSE:
                _screens[1].SetActive(enable);
                break;
            case ScreenType.END:
                _screens[2].SetActive(enable);
                break;
        }
    }

    public enum ScreenType
    {
        NONE,
        START,
        END,
        PAUSE
    }
}
