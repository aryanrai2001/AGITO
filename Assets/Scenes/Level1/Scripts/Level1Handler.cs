using UnityEngine;

public class Level1Handler : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.levelsUIManager.LoadLevel1();
    }
}
