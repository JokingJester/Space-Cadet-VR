using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroids : MonoBehaviour
{
    public int radius = 500;
    public GameObject[] asteroid;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            GameObject chosenAsteroid = asteroid[Random.Range(0, asteroid.Length)].gameObject;
            GameObject spawnedAsteroid = Instantiate(chosenAsteroid,transform.position + Random.insideUnitSphere * radius ,Quaternion.identity);
            spawnedAsteroid.transform.parent = this.transform;
        }
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}