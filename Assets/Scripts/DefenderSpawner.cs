using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        Debug.Log("Mouse was clicked");
        Vector2 worldPos = GetSquareClicked();
        SpawnDefender(worldPos);
    }

    private void Update()
    {
        //PlayerTouch();
    }

    private void PlayerTouch()
    {
        if (Input.touchCount == 1)
        {
            // latest touch
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touch");
        }
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        GameObject newDefender = Instantiate(defender, worldPos, Quaternion.identity) as GameObject;
        Debug.Log(worldPos);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        return worldPos;
    }
}
