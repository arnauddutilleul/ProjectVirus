using UnityEngine;
using UnityEngine.Events;

namespace PickableAntidote
{
    public class AntidoteManager : MonoBehaviour, IAntidote
    {
        [SerializeField] private int maxAmountAntidote;
        [SerializeField] private int _nbrAntidote;
        
        [SerializeField] private Contamination.Contamination contamination;
        [SerializeField] private BloodAntidoteText bloodAntidoteUI;
        [SerializeField] private UnityEvent healingSound;
        [SerializeField] private UnityEvent messageNoPotions;
        [SerializeField] private UnityEvent soundNoPotionsLeft;

        public void TakeAntidote()
        {
            _nbrAntidote++;
            bloodAntidoteUI.ChangeNumberAntidote(+1);
        }

        public void ConsumeAntidote()
        {
            if (_nbrAntidote > 0)
            {
                if (contamination.Heal())
                {
                    _nbrAntidote--;
                    bloodAntidoteUI.ChangeNumberAntidote(-1); 
                    healingSound.Invoke();
                }
            }
            else
            {
                soundNoPotionsLeft?.Invoke();
                messageNoPotions?.Invoke();
            }
            
        }
    }
}