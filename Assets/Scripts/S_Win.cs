using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_Win : MonoBehaviour
{
    [SerializeField] Text WinText;

    void OnTriggerEnter(Collider Other)
    {
        if(Other.CompareTag("Player"))
        {
            S_Logs.SaveLogs("Победа");
            WinText.text = "Выиграл";
            Invoke(nameof(Reload), 2f);
        }
    }
    void Reload()
    {
        S_Logs.SaveLogsAsText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
