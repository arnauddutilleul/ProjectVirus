using UnityEngine;

namespace Contamination
{
    public class PoisonZone : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject poisonZone;
        [SerializeField] private float followSpeed;


        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
    
        // Update is called once per frame
        void FixedUpdate()
        {
            FollowPlayer();
        }


        private void FollowPlayer()
        {
            var directionPlayer = player.transform.position - poisonZone.transform.position;
            rb2d.velocity = directionPlayer.normalized * followSpeed;
        }
    
    }
}