using UnityEngine;

public class S_Effect : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(Delete), 0.2f);
    }
    
    void Delete()
    {
        Destroy(gameObject);
    }
}
