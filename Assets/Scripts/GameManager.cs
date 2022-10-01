using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static GameManager instance;
    [HideInInspector] public static GameAssets assets;

    [HideInInspector] public Canvas canvas;
    [HideInInspector] public Animator levelTransition;

    [HideInInspector] public BackgroundManager backgroundManager;
    [HideInInspector] public AudioManager audioManager;
    [HideInInspector] public MenuManager menuManager;
    [HideInInspector] public Level1Manager level1Manager;

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
        levelTransition = canvas.transform.GetChild(canvas.transform.childCount-1).GetComponent<Animator>();

        backgroundManager = GetComponent<BackgroundManager>();
        audioManager = GetComponent<AudioManager>();
        menuManager = canvas.transform.GetChild(1).GetComponent<MenuManager>();
        level1Manager = canvas.transform.GetChild(2).GetComponent<Level1Manager>();

        backgroundManager.Init();
        audioManager.Init();
        menuManager.Init();
        level1Manager.Init();
    }
}
