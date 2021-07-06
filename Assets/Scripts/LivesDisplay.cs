using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int lives = 5;
    Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void AddLives(int amount)
    {
        lives += amount;
        UpdateDisplay();
    }

    public void TakeLives(int amount = 1)
    {
        if (!HaveEnoughLives(amount)) return;

        lives -= amount;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }

    public bool HaveEnoughLives(int amount)
    {
        return lives >= amount;
    }
}
