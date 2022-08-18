using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine.UI;
using Utils;

namespace Screen
{
    public enum ScreenType
    {
        Main,
        Start,
        Pause,
        Looser,
        Winner,
    }

    public class ScreenBase : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _screenItems;

        [SerializeField]
        private List<TextTyper> _textToType;

        [SerializeField]
        private Image _background;

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


        public void Hide()
        {
            if (gameObject.activeInHierarchy)
                gameObject.SetActive(false);

            _background.enabled = false;
            _screenItems.ForEach(x => x.SetActive(false));
        }

        #region ShowItems

        public void Show()
        {
            if (!gameObject.activeInHierarchy)
                gameObject.SetActive(true);

            _background.enabled = true;
            StartCoroutine(ShowItems());
        }

        private IEnumerator ShowItems()
        {
            if(_textToType.Count > 0)
                yield return StartType();

            yield return ScaleAnimation();
        }

        private IEnumerator StartType()
        {
            for(int i = 0; i < _textToType.Count; i++)
            {
                _textToType[i].StartTextTyper();

                if (i == _textToType.Count - 1)
                    yield return null;

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
