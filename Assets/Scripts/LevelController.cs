using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int numOfAttackers = 0;
    [SerializeField] bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;

    [SerializeField] float waitForLoad = 5f;

    public void AttackerSpawned()
    {
        numOfAttackers++;
    }

    public void AttackerKilled()
    {
        numOfAttackers--;

        if (numOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitForLoad);
        FindObjectOfType<LevelLoader>().LoadNextScene();
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
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
