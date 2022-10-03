using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public List<GameObject> customerPool;
    public int spawnCount;
    public int waveNumber;

    private void Start()
    {
        waveNumber = 1;
        StartCoroutine(SpawnCustomers(10f));
    }

    void Update()
    {
        
    }

    

    IEnumerator SpawnCustomers(float seconds)
    {
        WaitForSeconds seconds1 = new WaitForSeconds(seconds);
        WaitForSeconds wait = new WaitForSeconds(10f);

        for (int i = 0; i < spawnCount; i++)
        {
            int indexToSpawn = Random.Range(0, customerPool.Count);
            Instantiate(customerPool[indexToSpawn], this.transform.position, Quaternion.identity, this.transform);
            yield return wait;
        }

        yield return seconds1;
        spawnCount += waveNumber*2;
        waveNumber++;
        StartCoroutine(SpawnCustomers(10f));
    }
    

}
