using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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

    }

    //private void OnApplicationQuit()
    //{
    //    WriteMetricsToFile();
    //}
}
