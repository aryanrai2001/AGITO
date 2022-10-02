using UnityEngine;
using UnityEngine.UI;

public class LevelNHandler : LevelHandler
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
        LevelIndex = 0;
        continueButtonLevel = canvas.transform.GetChild(0).GetComponent<Button>();

        continueButtonLevel.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(levelsUIManager.ContinueAfterGame); });
    }

    public override void FinishLevel()
    {
        continueButtonLevel.interactable = true;
    }
}
