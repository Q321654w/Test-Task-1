using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Sources.Core
{
    public class Script : MonoBehaviour
    {
        private const string START_TEXT = "Start";
        private const string STOP_TEXT = "Stop";

        [SerializeField] private Button _toggleButton;
        [SerializeField] private TMP_Text _toggleButtonText;
        [SerializeField] private InfoPanel _panel1;
        [SerializeField] private InfoPanel _panel2;

        [SerializeField] private Color _waitColor;
        [SerializeField] private Color _awaitingColor;
        [SerializeField] private Color _runColor;

        private Coroutine _rootRoutine;
        private bool _isActive;

        private void Awake()
        {
            _toggleButton.onClick.AddListener(HandleToggle);
        }

        private void HandleToggle()
        {
            _isActive = !_isActive;

            if (_isActive)
                _rootRoutine = StartCoroutine(Signal());
            else
                Reset(_rootRoutine);
        }

        private void Reset(Coroutine routine)
        {
            if (routine != null)
                StopCoroutine(routine);

            _panel1.Indicator.color = _waitColor;
            _panel2.Indicator.color = _waitColor;

            _panel1.Test.text = "0s";
            _panel2.Test.text = "0s";

            _toggleButtonText.text = START_TEXT;
        }

        private void SetUp()
        {
            _toggleButtonText.text = STOP_TEXT;
        }

        private IEnumerator Signal()
        {
            SetUp();
            IEnumerator routine;
            
            while (true)
            {
                routine = Routine(_panel1);
                while (routine.MoveNext())
                    yield return routine.Current;

                routine = Routine(_panel2);
                while (routine.MoveNext())
                    yield return routine.Current;
            }
        }

        private IEnumerator Routine(InfoPanel infoPanel)
        {
            infoPanel.Indicator.color = _awaitingColor;
            var awaitTime = Random.Range(10, 20);

            while (awaitTime > 0)
            {
                infoPanel.Test.text = $"{awaitTime}s";
                yield return new WaitForSeconds(1);
                awaitTime--;
            }

            infoPanel.Indicator.color = _runColor;
            infoPanel.Test.text = "0s";
        }
    }
}