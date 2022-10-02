using UnityEngine;
using UnityEngine.UI;

public class Level3Handler : LevelHandler
{
    [HideInInspector] public Button continueButtonLevel;

    public override int LevelIndex { get; set; }

    private void Awake()
    {
        instance = this;
        Init();
    }

    public override void InitLevel()
    {
        LevelIndex = 3;
        continueButtonLevel = canvas.transform.GetChild(0).GetComponent<Button>();

        continueButtonLevel.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(levelsUIManager.ContinueAfterGame); });
    }

    public override void FinishLevel()
    {
        continueButtonLevel.interactable = true;
    }
}
