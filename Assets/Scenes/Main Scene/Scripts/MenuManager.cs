using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private GameObject startingPanel;
    private Button playButton;
    private Button optionButton;
    private Button quitButton;

    private GameObject optionsPanel;
    private Button aboutButton;
    private GameObject aboutPanel;
    private Button creditsButton;
    private GameObject creditsPanel;
    private Button backButtonInOptions;

    private GameObject levelSelectionPanel;
    private GameObject levelsHolder;
    private TextMeshProUGUI levelInfoText;
    private Button playLevelButton;
    private Button backButtonInLevelSelection;

    [HideInInspector] public LevelManager levelManager;

    public void Init()
    {
        startingPanel = transform.GetChild(0).gameObject;
        playButton = startingPanel.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        optionButton = startingPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        quitButton = startingPanel.transform.GetChild(1).GetChild(2).GetComponent<Button>();
        playButton.onClick.AddListener(delegate { TransitionOnButton(Play); });
        optionButton.onClick.AddListener(delegate { TransitionOnButton(Options); });
        quitButton.onClick.AddListener(delegate { TransitionOnButton(Quit); }) ;

        optionsPanel = transform.GetChild(1).gameObject;
        aboutButton = optionsPanel.transform.GetChild(1).GetComponent<Button>();
        aboutPanel = optionsPanel.transform.GetChild(2).gameObject;
        creditsButton = optionsPanel.transform.GetChild(3).GetComponent<Button>();
        creditsPanel = optionsPanel.transform.GetChild(4).gameObject;
        backButtonInOptions = optionsPanel.transform.GetChild(5).GetComponent<Button>();
        aboutButton.onClick.AddListener(About);
        creditsButton.onClick.AddListener(Credits);
        backButtonInOptions.onClick.AddListener(delegate { TransitionOnButton(BackFromOptions); });

        levelSelectionPanel = transform.GetChild(2).gameObject;
        levelsHolder = levelSelectionPanel.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject;
        levelInfoText = levelSelectionPanel.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        playLevelButton = levelSelectionPanel.transform.GetChild(2).GetChild(1).GetComponent<Button>();
        backButtonInLevelSelection = levelSelectionPanel.transform.GetChild(3).GetComponent<Button>();
        playLevelButton.onClick.AddListener(delegate { TransitionOnButton(LoadLevel); });
        backButtonInLevelSelection.onClick.AddListener(delegate { TransitionOnButton(BackFromLevelSelection); });

        levelManager = levelSelectionPanel.GetComponent<LevelManager>();
        levelManager.Init(levelsHolder, levelInfoText);
    }

    public void Transition(Action action)
    {
        StartCoroutine(GameManager.instance.TransitionCoroutine(action));
    }

    public void TransitionOnButton(Action action)
    {
        GameManager.instance.audioManager.Play("Click");
        StartCoroutine(GameManager.instance.TransitionCoroutine(action));
    }

    public void Play()
    {
        startingPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
        levelManager.SelectLevel(-1);
    }

    public void LoadLevel()
    {
        levelSelectionPanel.SetActive(false);
        SceneManager.LoadScene(levelManager.selectedLevel + 1, LoadSceneMode.Additive);
    }

    public void BackFromLevelSelection()
    {
        levelSelectionPanel.SetActive(false);
        startingPanel.SetActive(true);
        levelManager.SelectLevel(-1);
    }

    public void Options()
    {
        aboutButton.interactable = false;
        creditsButton.interactable = true;
        creditsPanel.SetActive(false);
        aboutPanel.SetActive(true);
        startingPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void About()
    {
        GameManager.instance.audioManager.Play("Click");
        aboutButton.interactable = false;
        creditsButton.interactable = true;
        creditsPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void Credits()
    {
        GameManager.instance.audioManager.Play("Click");
        creditsButton.interactable = false;
        aboutButton.interactable = true;
        aboutPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackFromOptions()
    {
        optionsPanel.SetActive(false);
        startingPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
