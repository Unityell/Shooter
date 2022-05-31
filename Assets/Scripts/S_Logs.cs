using UnityEngine;
using System.IO;

class S_Logs : MonoBehaviour
{
    public static string Logs;
    public static int Number;
    void Start()
    {
        SaveLogs("Старт");
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Logs/");
    }
    public static void SaveLogs(string Log)
    {
        Number++;
        Logs += " " + Number + "." + Log + "\n";
    }

    public static void SaveLogsAsText()
    {
        string TextLogs = Application.streamingAssetsPath + "/Logs/" + "TxtLogs" + ".txt";
        File.WriteAllText(TextLogs, Logs);
        Logs = null;
        Number = 0;
    }
}
