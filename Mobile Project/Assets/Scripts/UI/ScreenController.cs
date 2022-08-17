using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen;

namespace Screen
{
    public class ScreenController : MonoBehaviour
    {
        [SerializeField]
        private List<ScreenBase> _screens;

        private ScreenBase _currentScreen;

        public void ShowScreenByType(ScreenType type)
        {
            var nextScreenToShow = _screens.Find(x => x.Type == type);

            _currentScreen.Hide();

            nextScreenToShow.Show();

            _currentScreen = nextScreenToShow;
        }
    }
}



