using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyTank;
    public int numberofTanks;
    private float nextSpawntime;
    private float spawnDelay = 1;
    public int NumberOfPrefabs;





    // Start is called before the first frame update
    void Start()
    {
        //spawnTrue = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn() && NumberOfPrefabs <= 4)
        {
            Spawn();
        }   

        NumberOfPrefabs = GameObject.FindGameObjectsWithTag("Tank").Length;

    }

    private void Spawn()
    {
        
        nextSpawntime = Time.time + spawnDelay;
        Instantiate(enemyTank, transform.position, transform.rotation);
        
    }

    private bool ShouldSpawn()
    {
        return Time.time > nextSpawntime;
    }


}
