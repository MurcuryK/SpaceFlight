using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    // Obstacle
    public static int weather;


    // Large Asteroid
    [SerializeField] private Transform largeAsteroid;
    private Vector3 nextLargeAsteroidSpawn;

    // Small Asteroid
    [SerializeField] private Transform smallAsteroid;
    private Vector3 nextSmallAsteroidSpawn;

    // Laser
    [SerializeField] private Transform laser;
    private Vector3 nextlaserSpawn;

    private float spawnZ;

    private int randObstacle;
    private float randX;
    private float randY;

    // Start is called before the first frame update
    void Start()
    {
        spawnZ = 15;
        StartCoroutine(SpawnObstacles());
    }

    void WeatherCondition()
    {

        if (RealWorldWeather.weatherNum <= 700)
        {
            weather = 1;
        }
        else
        {
            weather = 2;
        }

    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(0.5f);

        WeatherCondition();
        SpawnType();

        StartCoroutine(SpawnObstacles());   // Creates an endless loop
    }

    void SpawnType()
    {
        randObstacle = Random.Range(1, 4);
        Debug.Log(randObstacle);

        // Clear/Clouds weather e.g. more lasers
        if (weather == 1)
        {
            randX = Random.Range(-5, 7);

            nextlaserSpawn = new Vector3(randX, 5.17f, spawnZ);    // laser position setting

            Instantiate(laser, nextlaserSpawn, laser.rotation); // Spawns in a laser
            spawnZ += 5;  // Adds the length of each spawn

            // Tile Set Two
            randX = Random.Range(-5, 7);

            nextlaserSpawn = new Vector3(randX, 5.17f, spawnZ);    // laser position setting

            Instantiate(laser, nextlaserSpawn, laser.rotation); // Spawns in a laser
            spawnZ += 5;  // Adds the length of each spawn


            // Tile Set Three
            randX = Random.Range(-5, 7);
            randY = Random.Range(2, 9);

            // Final spawn
            if (randObstacle == 1)
            {
                nextlaserSpawn = new Vector3(randX, 5.17f, spawnZ);    // laser position setting

                Instantiate(laser, nextlaserSpawn, laser.rotation); // Spawns in a laser
                spawnZ += 5;  // Adds the length of each spawn
            }
            else
            {
                nextSmallAsteroidSpawn = new Vector3(randX, 5.17f, spawnZ);    // Small Asteroid position setting

                Instantiate(smallAsteroid, nextSmallAsteroidSpawn, smallAsteroid.rotation); // Spawns in a Small Asteroid
                spawnZ += 5;  // Adds the length of each spawn
            }
        }

        // Rain/Snow weather e.g. more asteroids
        if (weather == 2)
        {
            randX = Random.Range(-5, 7);
            randY = Random.Range(2, 9);

            nextLargeAsteroidSpawn = new Vector3(randX, randY, spawnZ);    // Large Asteroid position setting

            Instantiate(largeAsteroid, nextLargeAsteroidSpawn, largeAsteroid.rotation); // Spawns in a Large Asteroid
            spawnZ += 5;  // Adds the length of each spawn

            // Tile Set Two
            randX = Random.Range(-5, 7);
            randY = Random.Range(2, 9);

            nextSmallAsteroidSpawn = new Vector3(randX, 5.17f, spawnZ);    // Small Asteroid position setting

            Instantiate(smallAsteroid, nextSmallAsteroidSpawn, smallAsteroid.rotation); // Spawns in a Small Asteroid
            spawnZ += 5;  // Adds the length of each spawn

            // Tile Set Three
            randX = Random.Range(-5, 7);
            randY = Random.Range(2, 9);


            // Final spawn
            if (randObstacle == 1)
            {
                nextSmallAsteroidSpawn = new Vector3(randX, 5.17f, spawnZ);    // Small Asteroid position setting

                Instantiate(smallAsteroid, nextSmallAsteroidSpawn, smallAsteroid.rotation); // Spawns in a Small Asteroid
                spawnZ += 5;  // Adds the length of each spawn
            }
            else if (randObstacle == 2)
            {
                nextLargeAsteroidSpawn = new Vector3(randX, randY, spawnZ);    // Large Asteroid position setting

                Instantiate(largeAsteroid, nextLargeAsteroidSpawn, largeAsteroid.rotation); // Spawns in a Large Asteroid
                spawnZ += 5;  // Adds the length of each spawn
            }
            else
            {
                nextlaserSpawn = new Vector3(randX, 5.17f, spawnZ);    // laser position setting

                Instantiate(laser, nextlaserSpawn, laser.rotation); // Spawns in a laser
                spawnZ += 5;  // Adds the length of each spawn
            }



            StartCoroutine(SpawnObstacles());   // Creates an endless loop
        }
    }
}
