using System;
using System.Collections;
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

    private float transitionDuration;

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

        backgroundManager.Init();
        audioManager.Init();
        menuManager.Init();

        RuntimeAnimatorController ac = levelTransition.runtimeAnimatorController;
        transitionDuration = ac.animationClips[0].length;
    }

    public IEnumerator TransitionCoroutine(Action action)
    {
        levelTransition.SetTrigger("Out");

        yield return new WaitForSeconds(transitionDuration);

        backgroundManager.UpdateBackground();

        action.Invoke();

        levelTransition.SetTrigger("In");
    }
}
