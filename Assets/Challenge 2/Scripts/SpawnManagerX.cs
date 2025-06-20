using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = Random.Range(3f, 5f);
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        Quaternion ballRotation = ballPrefabs[ballIndex].transform.rotation;

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballRotation);
    }

}
