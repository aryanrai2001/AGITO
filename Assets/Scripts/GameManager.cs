using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;

    [HideInInspector] public Canvas canvas;

    [HideInInspector] public BackgroundManager backgroundManager;
    [HideInInspector] public MenuManager menuManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(gameObject);

        canvas = FindObjectOfType<Canvas>();

        backgroundManager = GetComponent<BackgroundManager>();
        menuManager = canvas.transform.GetChild(1).GetComponent<MenuManager>();

        backgroundManager.Init();
        menuManager.Init();
    }
}
