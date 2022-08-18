using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Screen;
using Core.Singleton;

namespace Screen
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        [SerializeField]
        private List<ScreenBase> _screens;

        [SerializeField]
        private ScreenType _startScreen;

        private ScreenBase _currentScreen;

        public void ShowByType(ScreenType type)
        {
            if (_currentScreen != null)
                _currentScreen.Hide();

            var nextScreenToShow = _screens.Find(x => x.Type == type);

            nextScreenToShow.Show();

            _currentScreen = nextScreenToShow;
        }        

        public void HideAll()
        {
            _screens.ForEach(x => x.Hide());
        }
    }
}



