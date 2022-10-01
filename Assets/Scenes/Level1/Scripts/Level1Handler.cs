using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Handler : MonoBehaviour
{
    [HideInInspector] public static Level1Handler instance;

    public GameObject levelHolder;

    [HideInInspector] public Camera levelCamera;
    [HideInInspector] public Canvas canvas;

    [HideInInspector] public ClarityHandler panel1;
    [HideInInspector] public ClarityHandler panel2;
    [HideInInspector] public PuzzleController puzzleController;
    [HideInInspector] public Button continueButtonLevel1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Multiple Level1Handler Instances Found!");
        }

        levelCamera = levelHolder.transform.GetChild(0).GetComponent<Camera>();
        canvas = levelHolder.transform.GetChild(1).GetComponent<Canvas>();

        panel1 = canvas.transform.GetChild(0).GetComponent<ClarityHandler>();
        panel2 = canvas.transform.GetChild(1).GetComponent<ClarityHandler>();
        puzzleController = canvas.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<PuzzleController>();
        continueButtonLevel1 = canvas.transform.GetChild(3).GetComponent<Button>();

        continueButtonLevel1.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(GameManager.instance.levelsUIManager.ContinueAfterGameLevel1); });

        GameManager.instance.mainCamera.GetUniversalAdditionalCameraData().cameraStack.Add(levelCamera);

        levelCamera.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
        panel1.Init();
        panel2.Init();
        puzzleController.Init();
        canvas.gameObject.SetActive(false);
        GameManager.instance.levelsUIManager.LoadLevel1();
    }

    public void Finished()
    {
        PlayerPrefs.SetInt("LevelReached", SceneManager.GetActiveScene().buildIndex);
        continueButtonLevel1.interactable = true;
    }

    public void EndLevel()
    {
        GameManager.instance.mainCamera.GetUniversalAdditionalCameraData().cameraStack.Remove(levelCamera);
    }
}
