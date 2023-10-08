using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameManager gameManager; 

   // The GameObject to instantiate.
    public GameObject[] entitiesToSpawn;

    // An instance of the ScriptableObject defined above.
    public BadGuyManager[] spawnManagerValues;
    public BadGuyManager currSpawnManagerValues;

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    public static Spawner spawner;
    
    void Start(){
        gameManager = GetComponent<GameManager>();
        currSpawnManagerValues = spawnManagerValues[0];
        spawner = this;

        // StartCoroutine(SpawnEntities());
    }

    public static void SetSpawnManagerVals(int switchArg){
        spawner.currSpawnManagerValues = spawner.spawnManagerValues[switchArg];
    }

    //this is what we call a wrapper. it lets us call our method from anywhere without a direct reference to this gameobject
    public static void Spawn()
    {
        spawner.StartCoroutine(spawner.SpawnEntities());
    }

    private IEnumerator SpawnEntities()
    {
        yield return new WaitForSeconds(5.0f);
        foreach(string prefab in currSpawnManagerValues.prefabNames)
        {
            int currentSpawnPointIndexX = 0;

            foreach(int numFabs in currSpawnManagerValues.prefabsToSpawn)
            {
                int currentSpawnPointIndexY = 0;

                for (int i = 0; i < numFabs; i++)
                {
                    // Creates an instance of the prefab at the current spawn point.
                    GameObject currentEntity = Instantiate(entitiesToSpawn[currentSpawnPointIndexX], currSpawnManagerValues.spawnPoints[currentSpawnPointIndexX].spawnPoints[currentSpawnPointIndexY], Quaternion.identity);

                    // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
                    currentEntity.name = prefab + instanceNumber;

                    // Moves to the next spawn point index. If it goes out of range, it wraps back to the start.
                    currentSpawnPointIndexY = (currentSpawnPointIndexY + 1) % currSpawnManagerValues.spawnPoints.Length;

                    instanceNumber++;
                }
                
                currentSpawnPointIndexX++;
            }
        }
    }
}