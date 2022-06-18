
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour
{
    public int radius = 500;
    public GameObject[] asteroid;
    void Start()
    {
        for(int i = 0; i < 25; i++)
        {
            GameObject chosenAsteroid = asteroid[Random.Range(0, asteroid.Length)].gameObject;
            GameObject spawnedAsteroid = Instantiate(chosenAsteroid,transform.position + Random.insideUnitSphere * radius ,Quaternion.identity);
            spawnedAsteroid.transform.parent = this.transform;
        }
        this.gameObject.SetActive(false);
    }
}
