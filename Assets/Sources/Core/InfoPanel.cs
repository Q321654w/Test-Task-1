using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Core
{
    public class InfoPanel : MonoBehaviour
    {
        [SerializeField] private RawImage _indicator;
        [SerializeField] private TMP_Text _test;

        public RawImage Indicator => _indicator;
        public TMP_Text Test => _test;
    }
}