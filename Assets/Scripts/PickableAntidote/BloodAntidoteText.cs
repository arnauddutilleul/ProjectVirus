using TMPro;
using UnityEngine;

namespace PickableAntidote
{
    [RequireComponent(typeof(TMP_Text))]
    public class BloodAntidoteText : MonoBehaviour
    {
        private TMP_Text text;
        private int _numberPotions;

        private void Awake()
        {
            text = GetComponent<TMP_Text>();
        }

        public void ChangeNumberAntidote(int value)
        {
            _numberPotions += value;
            text.text = _numberPotions.ToString();
        }
    }
}
