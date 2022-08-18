using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Utils
{
    public class TextTyper : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private string _textToShow;

        [SerializeField]
        private float _timeBetweenLetters;

        private void Awake()
        {
            _text.text = "";
        }

        public void StartTextTyper()
        {
            StartCoroutine(Type());
        }

        private IEnumerator Type()
        {
            var letterList = _textToShow.ToCharArray();

            foreach (char c in letterList)
            {
                _text.text += c;

                yield return new WaitForSeconds(_timeBetweenLetters);
            }
        }
    }
}

