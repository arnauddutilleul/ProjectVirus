using System.Collections;
using PickableAntidote;
using UnityEngine;

namespace Controllers
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private Movement movement;
        [SerializeField] private Attack attack;
        private float _pressTime;
        private const float PressTimeTollerance = 0.5f;
        [SerializeField] private GameObject exitMenu;
        [SerializeField] private AntidoteManager consumeAntidote;
        private bool _canMove = true;

        public bool CanMove
        {
            set => _canMove = value;
        }

        void Update()
        {
            if (!_canMove)
            {
                movement.Move(0,0);
                return;
            }
            
            var horizontal = Input.GetAxisRaw("Horizontal");
            movement.Move(horizontal,0);
        
            //jump
            if (Input.GetButtonDown("Jump") || (Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0))
                movement.Jump();
        
            //Sit
            if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow))
            {
                if(_pressTime < PressTimeTollerance)
                {
                    _pressTime += Time.deltaTime;
                }
                else
                {
                    movement.Sit();
                }
            }
            else if(Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                if(_pressTime < PressTimeTollerance)
                {
                    movement.Sit();
                }
 
                _pressTime = 0f;
            }
        
            //Menu Eschap
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (exitMenu.activeSelf)
                    exitMenu.SetActive(false);
                else 
                    exitMenu.SetActive(true);
            }
        
            //Potions E
            if (Input.GetKeyDown(KeyCode.E))
            {
                consumeAntidote.ConsumeAntidote();
            }
        
            //Melee Attack
            if (Input.GetButtonDown("Fire1"))
            {
                if (attack.canAttackMelee())
                    attack.AttackEnnemyMelee();
            }

            //LaserAttack
            if (Input.GetButtonDown("Fire2"))
            {
                attack.Lazer();
            }
        }
        
        public void Death()
        {
            _canMove = false;
            StartCoroutine("DeathCouroutine");

        }
    
        public IEnumerator DeathCouroutine()
        {
            yield return new WaitForSeconds(1.2f);
            transform.gameObject.SetActive(false);
            GameManager.GameManager.Instance.LoadScene("Defeat");
        }
    }
}