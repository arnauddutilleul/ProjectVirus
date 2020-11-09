using UnityEngine;

namespace Spawner
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField] private DropTable.DropTable randomPrefab;

        private Transform myTransform;

        private void Awake()
        {
            myTransform = transform;
        }

        public void Spawn()
        {
            Debug.Log("Spawn");
            var obj = randomPrefab.Drop();
            Instantiate(obj, transform.position, Quaternion.identity);

            obj.layer = gameObject.layer;
            foreach (Transform item in obj.transform)
            {
                item.gameObject.layer = gameObject.layer;
            }
            Debug.Log(obj.name);
        }

    }
}