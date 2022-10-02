using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class LevelHandler : MonoBehaviour
{
    [HideInInspector] public static LevelHandler instance;
    [HideInInspector] public abstract int LevelIndex { get; set; }

    [HideInInspector] public LevelUIManager levelsUIManager;
    [HideInInspector] public GameObject levelHolder;
    [HideInInspector] public Camera levelCamera;
    [HideInInspector] public Canvas canvas;

    public abstract void InitLevel();
    public abstract void FinishLevel();

    public void Init()
    {
        LevelIndex = 0;
        DontDestroyOnLoad(gameObject);

        levelsUIManager = GameManager.instance.canvas.transform.GetChild(2).GetComponent<LevelUIManager>();
        levelHolder = GameObject.FindGameObjectWithTag("LevelHolder");
        levelCamera = levelHolder.transform.GetChild(0).GetComponent<Camera>();
        canvas = levelHolder.transform.GetChild(1).GetComponent<Canvas>();

        GameManager.instance.mainCamera.GetUniversalAdditionalCameraData().cameraStack.Add(levelCamera);

        levelCamera.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);

        InitLevel();
        levelsUIManager.Init();

        canvas.gameObject.SetActive(false);
        levelsUIManager.LoadLevelUI();
    }

    public void Close()
    {
        GameManager.instance.mainCamera.GetUniversalAdditionalCameraData().cameraStack.Remove(levelCamera);
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
        GameManager.instance.menuManager.levelManager.UnlockLevel();
        GameManager.instance.menuManager.Play();
    }

    private void Update()
    {
        //CheatCodes
        if (Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            FinishLevel();
        }
    }
}

public class LevelUIManager : MonoBehaviour
{
    private GameObject level;
    private GameObject introPanel;
    private GameObject infoPanel;
    private GameObject triviaPanel;
    private GameObject rewardPanel;
    private Button continueIntroButton;
    private Button continueInfoButton;
    private Button continueRewardButton;
    private TriviaManager triviaManager;

    private bool hasTrivia;

    public void Init()
    {
        level = transform.GetChild(LevelHandler.instance.LevelIndex - 1).gameObject;
        introPanel = level.transform.GetChild(0).gameObject;
        infoPanel = level.transform.GetChild(1).gameObject;
        triviaPanel = level.transform.GetChild(2).gameObject;
        rewardPanel = level.transform.GetChild(3).gameObject;
        triviaManager = triviaPanel.GetComponent<TriviaManager>();
        continueIntroButton = introPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        continueInfoButton = infoPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        continueRewardButton = rewardPanel.transform.GetChild(1).GetComponent<Button>();

        continueIntroButton.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(ContinueAfterIntro); });
        continueInfoButton.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(ContinueAfterInfo); });
        continueRewardButton.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(ContinueAfterReward); });
        hasTrivia = triviaManager.Init();
    }

    public void LoadLevelUI()
    {
        introPanel.SetActive(true);
    }

    public void ContinueAfterIntro()
    {
        introPanel.SetActive(false);
        LevelHandler.instance.canvas.gameObject.SetActive(true);
        LevelHandler.instance.levelCamera.gameObject.SetActive(true);
    }

    public void ContinueAfterGame()
    {
        UnloadLevelUI();
        LevelHandler.instance.canvas.gameObject.SetActive(false);
        LevelHandler.instance.levelCamera.gameObject.SetActive(false);
    }

    public void UnloadLevelUI()
    {
        triviaPanel.SetActive(false);
        infoPanel.SetActive(true);
    }

    public void ContinueAfterInfo()
    {
        infoPanel.SetActive(false);
        if (hasTrivia)
        {
            triviaPanel.SetActive(true);
            triviaManager.Refresh();
        }
        else
        {
            ContinueAfterTrivia();
        }
    }

    public void ContinueAfterTrivia()
    {
        PlayerPrefs.SetInt("LevelReached", LevelHandler.instance.LevelIndex);
        triviaPanel.SetActive(false);
        rewardPanel.SetActive(true);
    }

    public void ContinueAfterReward()
    {
        rewardPanel.SetActive(false);
        LevelHandler.instance.Close();
    }
}
