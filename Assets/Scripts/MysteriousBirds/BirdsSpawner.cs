using UnityEngine;


public class BirdsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject birds;
    [SerializeField] private Transform spwaner = null;
    [SerializeField] private bool enableSpawn;
    [SerializeField] private DestroyBirds destroy;
    private GameObject birdsSpawn;

    private void FixedUpdate()
    {
        if (destroy.isDestroy)
        {
            SpawnBirds();
        }
    }

    public void SpawnBirds()
    {
        Instantiate(birds, spwaner.position, Quaternion.identity);
        destroy.isDestroy = false;
    }
}