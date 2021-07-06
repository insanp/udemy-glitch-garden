using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Time in seconds")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished) return;

        slider.value = Time.timeSinceLevelLoad / levelTime * slider.maxValue;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            Debug.Log("Level timer expired!");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
