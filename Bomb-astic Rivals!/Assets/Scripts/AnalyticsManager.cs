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

    public float timeInTileArea = 0f;
    private bool inTileArea = false;

    public float minTileX, maxTileX, minTileZ, maxTileZ;

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
        Vector3 P1Loc = PlayerMovement1.instance.transform.position;
        Vector3 P2Loc = PlayerMovement2.instance.transform.position;

        if ((P1Loc.x >= minTileX && P1Loc.x <= maxTileX && P1Loc.z >= minTileZ && P1Loc.z <= maxTileZ) ||
                (P2Loc.x >= minTileX && P2Loc.x <= maxTileX && P2Loc.z >= minTileZ && P2Loc.z <= maxTileZ))
        {
            inTileArea = true;
        }
        else
        {
            inTileArea = false;
        }

        if (inTileArea)
        {
            timeInTileArea += Time.deltaTime;
        }
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        inTileArea = true;
    //        numPlayersInTileArea++;
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        numPlayersInTileArea--;

    //        if(numPlayersInTileArea == 0)
    //        {
    //            inTileArea = false;
    //        }
    //    }
    //}

    //private string ConvertMetricsToStringRepresentation()
    //{
    //    string metrics = "Total Time in Tile Area (seconds): " + timeInTileArea.ToString() + "\n";
    //    return metrics;
    //}

    // Uses the current date/time on this computer to create a uniquely named file,
    // preventing files from colliding and overwriting data.
    //private string CreateUniqueFileName()
    //{
    //    string dateTime = System.DateTime.Now.ToString();
    //    dateTime = dateTime.Replace("/", "_");
    //    dateTime = dateTime.Replace(":", "_");
    //    dateTime = dateTime.Replace(" ", "___");
    //    return "BombasticRivals_Analytics_" + dateTime + ".txt";
    //}

    // Generate the report that will be saved out to a file.
    //public void WriteMetricsToFile()
    //{
    //    string totalReport = "Report generated on " + System.DateTime.Now + "\n\n";
    //    totalReport += "Total Report:\n";
    //    totalReport += ConvertMetricsToStringRepresentation();
    //    totalReport = totalReport.Replace("\n", System.Environment.NewLine);
    //    string reportFile = CreateUniqueFileName();
    //
    //    File.WriteAllText(reportFile, totalReport);
    //}

    // The OnApplicationQuit function is a Unity-Specific function that gets
    // called right before your application actually exits. You can use this
    // to save information for the next time the game starts, or in our case
    // write the metrics out to a file.
    //private void OnApplicationQuit()
    //{
    //    WriteMetricsToFile();
    //}
}
