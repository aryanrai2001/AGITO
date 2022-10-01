using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [HideInInspector] public PageManager pageManager;
    [HideInInspector] public BackgroundManager backgroundManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);

        pageManager = GetComponent<PageManager>();
        backgroundManager = GetComponent<BackgroundManager>();

        pageManager.Init();
        backgroundManager.Init();
    }
}
