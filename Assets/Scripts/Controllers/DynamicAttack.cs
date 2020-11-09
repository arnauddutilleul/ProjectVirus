using Ennemie;
using Pooling;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class DynamicAttack : Attack
    {
        [SerializeField] private TextMeshProUGUI timer;
        
        [SerializeField] private int _damageSword = 10;
        [SerializeField] private Animator animator;
        
        private static readonly int Attack = Animator.StringToHash("AttackMelee");
        private bool _attack;
        private Transform collision;
        
        /*[SerializeField] private GameObject laserPrefabs;
        [SerializeField] private Transform laserSpawnPoint;
        [SerializeField] private float laserSpeed;
        public override void AttackEnnemyLaser()
        {
            if (LaserSpawner(out var projectile)) return;
            LaserMovement(projectile);
            projectile.layer = gameObject.layer;
            this.collision.transform.parent.GetComponent<IDomageable>()?.TakeDamage(nbrTakeDamage);
        }

        private void LaserMovement(GameObject projectile)
        {
            var rb = projectile.GetComponent<Rigidbody2D>();
            if (rb)
                rb.velocity = laserSpawnPoint.right * laserSpeed;
        }

        private bool LaserSpawner(out GameObject projectile)
        {
            if (laserPrefabs.TryAcquire(out projectile) == false)
                return true;
            var t = projectile.transform;
            t.position = laserSpawnPoint.position;
            t.rotation = laserPrefabs.transform.localRotation;
            return false;
        }*/

        public override void AttackEnnemyMelee()
        {
            this.collision.transform.parent.GetComponent<IDamageable>()?.TakeDamage(_damageSword);
            animator.SetTrigger(Attack);
        }
        
        [SerializeField] private Damage projectilePrefab;
        [SerializeField] private Transform projectileSpawner;
        [SerializeField] private float projectileSpeed;
        
        public override void Lazer()
        {
            if (projectilePrefab.gameObject.TryAcquire(out var projectile) == false)
                return;
            var t = projectile.transform;
            t.position = projectileSpawner.position;
            t.rotation = projectileSpawner.rotation;
            var rb = projectile.GetComponent<Rigidbody2D>();
            if (rb)
                rb.velocity = projectileSpawner.right * projectileSpeed;
            //projectile.layer = gameObject.layer;
            var damage = projectile.GetComponent<Damage>();
            damage.layerMask &=~ (1 <<gameObject.layer);

        }

        public override bool canAttackMelee()
        {
            return _attack;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ennemies"))
            {
                this._attack = true;
                this.collision = other.transform;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ennemies"))
            {
                this._attack = false;
            }
        }
    
    }
}