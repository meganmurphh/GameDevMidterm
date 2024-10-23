using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    public GameObject cratePrefab; 
    public float spawnInterval = 20f; 
    public float spawnRangeX = 100f; 

    private void Start()
    {
        InvokeRepeating("SpawnCrate", 0f, spawnInterval);
    }

    private void SpawnCrate()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPosition = new Vector3(randomX, 1f, -26.5f);

        GameObject crateObject = Instantiate(cratePrefab, spawnPosition, Quaternion.identity);

        Crate crate = crateObject.GetComponent<Crate>();
        if (crate != null)
        {
            crate.crateValue = Random.Range(1, 101); 
            crate.UpdateCrateText(); 
        }
    }
}
