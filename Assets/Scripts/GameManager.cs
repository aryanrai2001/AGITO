using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [HideInInspector] public static GameAssets assets;

    [HideInInspector] public Canvas canvas;

    [HideInInspector] public BackgroundManager backgroundManager;
    [HideInInspector] public AudioManager audioManager;
    [HideInInspector] public MenuManager menuManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            assets = GetComponent<GameAssets>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Multiple GameManager Instances Found!");
        }

        canvas = FindObjectOfType<Canvas>();

        backgroundManager = GetComponent<BackgroundManager>();
        audioManager = GetComponent<AudioManager>();
        menuManager = canvas.transform.GetChild(1).GetComponent<MenuManager>();

        backgroundManager.Init();
        audioManager.Init();
        menuManager.Init();
    }
}
