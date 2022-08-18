using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen;

namespace Screen
{
    public class ScreenHelper : MonoBehaviour
    {
        [SerializeField]
        private ScreenType _screenToShow;

        public void OnClick()
        {
            ScreenManager.Instance.ShowByType(_screenToShow);
        }
    }
}
