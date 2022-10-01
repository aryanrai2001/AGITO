using UnityEngine;

public class Level1Handler : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.level1Manager.Load();
    }
}
