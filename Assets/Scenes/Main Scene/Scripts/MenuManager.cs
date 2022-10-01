using UnityEngine;
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

    public void Init()
    {
        startingPanel = transform.GetChild(0).gameObject;
        playButton = startingPanel.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        optionButton = startingPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        quitButton = startingPanel.transform.GetChild(1).GetChild(2).GetComponent<Button>();
        playButton.onClick.AddListener(Play);
        optionButton.onClick.AddListener(Options);
        quitButton.onClick.AddListener(Quit);

        optionsPanel = transform.GetChild(1).gameObject;
        aboutButton = optionsPanel.transform.GetChild(1).GetComponent<Button>();
        aboutPanel = optionsPanel.transform.GetChild(2).gameObject;
        creditsButton = optionsPanel.transform.GetChild(3).GetComponent<Button>();
        creditsPanel = optionsPanel.transform.GetChild(4).gameObject;
        backButtonInOptions = optionsPanel.transform.GetChild(5).GetComponent<Button>();
        aboutButton.onClick.AddListener(About);
        creditsButton.onClick.AddListener(Credits);
        backButtonInOptions.onClick.AddListener(BackFromOptions);
    }

    public void Play()
    {

    }

    public void Options()
    {
        GameManager.instance.backgroundManager.UpdateBackground();
        startingPanel.SetActive(false);
        optionsPanel.SetActive(true);
        About();
    }

    public void About()
    {
        aboutButton.interactable = false;
        creditsButton.interactable = true;
        creditsPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void Credits()
    {
        creditsButton.interactable = false;
        aboutButton.interactable = true;
        aboutPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void BackFromOptions()
    {
        GameManager.instance.backgroundManager.UpdateBackground();
        optionsPanel.SetActive(false);
        startingPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
