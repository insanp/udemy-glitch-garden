using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) defenderParent = new GameObject(DEFENDER_PARENT_NAME);
    }

    private void OnMouseDown()
    {
        //Debug.Log("Mouse was clicked");
        Vector2 worldPos = GetSquareClicked();
        AttemptToPlaceDefenderAt(worldPos);
        Debug.Log(worldPos);
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    public void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if (!defender) return;

        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        // if we have enough stars spawn the defender and stars
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
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
            //Debug.Log("Touch");
        }
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
        //Debug.Log(worldPos);
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }
    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);
        return new Vector2(newX, newY);
    }
}
