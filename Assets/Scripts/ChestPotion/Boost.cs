using TMPro;
using UnityEngine;

namespace ChestPotion
{
    public class Boost : MonoBehaviour
    {
        [SerializeField] private DynamicMovement movement;
        [SerializeField] private float boostEffectTime = 0f;
        [SerializeField] private TextMeshProUGUI bonusCompteur;
        private float _currentSpeed;
        [SerializeField] private float boostedSpeed = 4.2f;
        private float _timeCompteur = 4f;
        private bool _activeBoost;

        private void Awake()
        {
            _timeCompteur = Time.time + boostEffectTime;
            bonusCompteur.text = "";

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Boost")) return;
            _activeBoost = true;
            _currentSpeed = movement.getSpeed();
            Destroy(other.gameObject);
        }


        private void FixedUpdate()
        {
            CheckActiveBoost();
        }

        private void CheckActiveBoost()
        {
            if (_activeBoost)
            {
                if (_timeCompteur > 0)
                {
                    bonusCompteur.text = "Boost for : " + _timeCompteur + " secs";
                    _timeCompteur -= Time.deltaTime;
                    AugmentedSpeed();
                }
                else
                {
                    _timeCompteur = Time.time + 0f;
                    _activeBoost = false;
                    bonusCompteur.text = "";
                    NormalSpeed();
                }
            }
        }

        private void AugmentedSpeed()
        {
            movement.setSpeed(boostedSpeed);
        }

        private void NormalSpeed()
        {
            movement.setSpeed(_currentSpeed);
        }
    }
}