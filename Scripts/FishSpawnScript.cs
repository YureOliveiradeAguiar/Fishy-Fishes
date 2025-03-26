using UnityEngine;

public class FishSpawnScript : MonoBehaviour
{
    public GameObject rightFish;
    public GameObject leftFish;
    public float spawnRate;
    private float timer = 0;
    private int yVariationRange;
    private int ySpawnPoint;

    void Start()
    {
        SpawnFishes();
    }
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            SpawnFishes();
            timer = 0;
        }
    }
    void SpawnFishes()
    {
        yVariationRange = Random.Range(0, 5);
        ySpawnPoint = 80 - (40 * yVariationRange);
        Instantiate(rightFish, new Vector3(210, ySpawnPoint, 0), transform.rotation);

        yVariationRange = Random.Range(0, 4);
        ySpawnPoint = 60 - (40 * yVariationRange);
        Instantiate(leftFish, new Vector3(-210, ySpawnPoint, 0), transform.rotation);
    }
}
