using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] animalPrefabs;
    [SerializeField] private KeyCode switchkey;

    [SerializeField] private float zSpawn = 20f;
    [SerializeField] private float xRangeSpawn = 15f;

    [SerializeField] private float sideSpawnMinZ;
    [SerializeField] private float sideSpawnMaxZ;
    [SerializeField] private float xSideSpawn = 20f;



    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame

    void Update()
    {

    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-xRangeSpawn, xRangeSpawn), 0, zSpawn);
        Quaternion spawnRotation = animalPrefabs[animalIndex].transform.rotation;

        Instantiate(animalPrefabs[animalIndex], spawnPosition, spawnRotation);
    }
    void SpawnLeftRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition = new Vector3(-xSideSpawn, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(rotation));
    }
    void SpawnRightRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPosition = new Vector3(xSideSpawn, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);

        Instantiate(animalPrefabs[animalIndex], spawnPosition, Quaternion.Euler(rotation));
    }
}
