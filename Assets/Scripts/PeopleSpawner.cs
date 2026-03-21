using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    //A list of the world spawn locations
    public GameObject[] spawnLocations;
    public GameObject[] personPrefab; //0: male, 1: female

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPerson", 0f, Random.Range(0.1f, 5f)); // Spawn a person every 5 seconds
    }

    void SpawnPerson()
    {
        // Choose a random spawn location from the list
        int randomIndex = Random.Range(0, spawnLocations.Length);
        GameObject spawnLocation = spawnLocations[randomIndex];

        // Instantiate a new person at the chosen spawn location
        int personIndex = Random.Range(0, personPrefab.Length);
        //change the rotation to face the center of the world (the player)
        Quaternion rotation = Quaternion.LookRotation(Vector3.zero - spawnLocation.transform.position);
        //round rotation to nearest 90 degrees
        rotation = Quaternion.Euler(0, Mathf.Round(rotation.eulerAngles.y / 90) * 90, 0);
        Instantiate(personPrefab[personIndex], spawnLocation.transform.position, rotation);
    }
}
