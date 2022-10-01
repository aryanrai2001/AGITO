using UnityEngine;
using UnityEngine.UI;

public class Level1Handler : LevelHandler
{
    [HideInInspector] public Level1ImageController panel1;
    [HideInInspector] public Level1ImageController panel2;
    [HideInInspector] public Level1PuzzleController puzzleController;
    [HideInInspector] public Button continueButtonLevel1;

    public override int LevelIndex { get; set; }

    private void Awake()
    {
        instance = this;
        Init();
    }

    public override void InitLevel()
    {
        LevelIndex = 1;
        panel1 = canvas.transform.GetChild(0).GetComponent<Level1ImageController>();
        panel2 = canvas.transform.GetChild(1).GetComponent<Level1ImageController>();
        puzzleController = canvas.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Level1PuzzleController>();
        continueButtonLevel1 = canvas.transform.GetChild(3).GetComponent<Button>();

        continueButtonLevel1.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(levelsUIManager.ContinueAfterGame); });

        panel1.Init();
        panel2.Init();
        puzzleController.Init();
    }

    public override void FinishLevel()
    {
        continueButtonLevel1.interactable = true;
    }
}
