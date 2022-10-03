using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public List<GameObject> customerPool;
    public int spawnCount;

    private void Start()
    {

        StartCoroutine(SpawnCustomers());
    }

    void Update()
    {
        
    }


    IEnumerator SpawnCustomers()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        for (int i = 0; i < spawnCount; i++)
        {
            int indexToSpawn = Random.Range(0, customerPool.Count);
            Instantiate(customerPool[indexToSpawn], this.transform.position, Quaternion.identity, this.transform);
            yield return wait;
        }
    }


}
