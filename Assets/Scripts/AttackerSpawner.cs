using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 15f;
    [SerializeField] Attacker[] attackerPrefabs;

    int totalSpawn = 0;

    bool spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            // spawn
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int index = Random.Range(0, attackerPrefabs.Length);
        Debug.Log(index);
        Spawn(index);
        totalSpawn += 1;

        switch (totalSpawn)
        {
            case 5:
                maxSpawnDelay = 10f;
                break;
            case 11:
                maxSpawnDelay = 7f;
                break;
            case 20:
                maxSpawnDelay = 2f;
                break;
            case 50:
                minSpawnDelay = 0.1f;
                maxSpawnDelay = 1f;
                break;
        }
    }

    private void Spawn(int index)
    {
        Attacker newAttacker = Instantiate
                    (attackerPrefabs[index], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
