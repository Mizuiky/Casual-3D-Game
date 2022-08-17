using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

namespace Screen
{
    public enum ScreenType
    {
        Main,
        Pause,
        Menu
    }

    public class ScreenBase : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _screenItems;

        [SerializeField]
        private ScreenType _type;

        [Header("Animation")]

        [SerializeField]
        private float _scaleDuration;

        [SerializeField]
        private float _animationDelay;

        [SerializeField]
        private Ease _ease;

        public ScreenType Type
        {
            get => _type;
        }

        private void Start()
        {
            Show();
        }

        [Button]
        public void Hide()
        {
            _screenItems.ForEach(x => x.SetActive(false));
        }

        [Button]
        public void Show()
        {
            ShowItems();
        }

        public void ShowItems()
        {
            for(int i = 0; i < _screenItems.Count; i++)
            {
                var obj = _screenItems[i];

                obj.SetActive(true);

                obj.transform.DOScale(0, _scaleDuration).From().SetDelay(i * _animationDelay).SetEase(_ease);
            }
        }
    }
}
