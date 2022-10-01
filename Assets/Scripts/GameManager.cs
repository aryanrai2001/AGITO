using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [HideInInspector] public static GameAssets assets;

    [HideInInspector] public Camera mainCamera;
    [HideInInspector] public Canvas canvas;
    [HideInInspector] public Animator levelTransition;

    [HideInInspector] public BackgroundManager backgroundManager;
    [HideInInspector] public AudioManager audioManager;
    [HideInInspector] public MenuManager menuManager;
    [HideInInspector] public LevelsUIManager levelsUIManager;

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

        mainCamera = Camera.main;
        canvas = FindObjectOfType<Canvas>();
        levelTransition = canvas.transform.GetChild(canvas.transform.childCount-1).GetComponent<Animator>();

        backgroundManager = GetComponent<BackgroundManager>();
        audioManager = GetComponent<AudioManager>();
        menuManager = canvas.transform.GetChild(1).GetComponent<MenuManager>();
        levelsUIManager = canvas.transform.GetChild(2).GetComponent<LevelsUIManager>();

        backgroundManager.Init();
        audioManager.Init();
        menuManager.Init();
        levelsUIManager.Init();
    }
}
