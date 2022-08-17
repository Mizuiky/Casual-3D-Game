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
        Pause
    }

    public class ScreenBase : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _screenItems;

        [SerializeField]
        private List<TextTyper> _textToType;

        [SerializeField]
        private bool _hideOnStart;

        [SerializeField]
        private ScreenType _type;

        [Header("Scale Animation")]

        [SerializeField]
        private float _scaleDuration;

        [SerializeField]
        private float _animationDelay;

        [SerializeField]
        private Ease _ease;

        [Header("Typer Animation")]

        [SerializeField]
        private  float _delayBetweenPhrases;

        public ScreenType Type
        {
            get => _type;
        }

        private void Start()
        {
            if (_hideOnStart)
                Hide();

            Show();
        }

        [Button]
        public void Hide()
        {
            _screenItems.ForEach(x => x.SetActive(false));
        }

        #region ShowItems

        [Button]
        public void Show()
        {
            StartCoroutine(ShowItems());
        }

        private IEnumerator ShowItems()
        {
            yield return StartType();

            yield return ScaleAnimation();
        }

        private IEnumerator StartType()
        {
            foreach (TextTyper text in _textToType)
            {
                text.TypeText();

                yield return new WaitForSeconds(_delayBetweenPhrases);
            }
        }

        public IEnumerator ScaleAnimation()
        {
            for(int i = 0; i < _screenItems.Count; i++)
            {
                var obj = _screenItems[i];

                obj.SetActive(true);

                obj.transform.DOScale(0, _scaleDuration).From().SetDelay(i * _animationDelay).SetEase(_ease);
            }

            yield return null;
        }

        #endregion
    }
}
