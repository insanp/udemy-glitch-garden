using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int numOfAttackers = 0;
    [SerializeField] bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numOfAttackers++;
    }

    public void AttackerKilled()
    {
        numOfAttackers--;

        if (numOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End level now");
        }
    }

    public void LevelTimerFinished()
    {
        StopSpawners();
        levelTimerFinished = true;
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}