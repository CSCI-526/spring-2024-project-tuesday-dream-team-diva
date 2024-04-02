using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager instance;

    void Awake()
    {
        instance = this;
    }

    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }

    void Update()
    {
        // do-something
    }

    public void OnGameOver()
    {
        // do-something
    }

    public void RedItemUsed()
    {
        Debug.Log("Sent event redItemUsed Custom Event to Analytics");
        CustomEvent redItemUsed = new CustomEvent("redItemUsed")
        {
            { "levelNumber", SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.RecordEvent(redItemUsed);
    }
    
    public void BlueItemUsed()
    {
        Debug.Log("Sent event blutItemUsed Custom Event to Analytics");
        CustomEvent blueItemUsed = new CustomEvent("blueItemUsed")
        {
            { "levelNumber", SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.RecordEvent(blueItemUsed);
    }

    public void BlackItemUsed()
    {
        Debug.Log("Sent event blackItemUsed Custom Event to Analytics");
        CustomEvent blackItemUsed = new CustomEvent("blackItemUsed")
        {
            { "levelNumber", SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.RecordEvent(blackItemUsed);
    }

    public void BombTriggeredByPlayer()
    {
        Debug.Log("Sent event bombTriggeredByPlayer Custom Event to Analytics");
        CustomEvent bombTriggeredByPlayer = new CustomEvent("bombTriggeredByPlayer")
        {
            { "levelNumber", SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.RecordEvent(bombTriggeredByPlayer);
    }

    public void BombTriggeredByItem()
    {
        Debug.Log("Sent event bombTriggeredByItem Custom Event to Analytics");
        CustomEvent bombTriggeredByItem = new CustomEvent("bombTriggeredByItem")
        {
            { "levelNumber", SceneManager.GetActiveScene().name}
        };

        AnalyticsService.Instance.RecordEvent(bombTriggeredByItem);
    }

    public void LocationOfDeath(bool isBombTile, string bombTileIdentifier, float xAxis, float yAxis)
    {
        Debug.Log("Sent event locationOfDeath Custom Event to Analytics");
        CustomEvent locationOfDeath = new CustomEvent("locationOfDeath")
        {
            { "levelNumber", SceneManager.GetActiveScene().name},
            { "IsBombTile",  isBombTile},
            { "BombTileIdentifier", bombTileIdentifier },
            { "xAxis", xAxis},
            { "yAxis", yAxis}
        };

        AnalyticsService.Instance.RecordEvent(locationOfDeath);
    }

}
