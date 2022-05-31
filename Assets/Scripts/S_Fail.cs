using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_Fail : MonoBehaviour
{
    [SerializeField] Text FailText;

    void OnTriggerEnter(Collider Other)
    {
        if(Other.CompareTag("Player"))
        {
            S_Logs.SaveLogs("Фейл");
            FailText.text = "Проиграл";
            Invoke(nameof(Reload), 3f);
        }
    }

    void Reload()
    {
        S_Logs.SaveLogsAsText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
