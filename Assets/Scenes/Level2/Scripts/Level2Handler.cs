using UnityEngine;
using UnityEngine.UI;

public class LevelNHandler : LevelHandler
{
    [HideInInspector] public Button continueButtonLevel2;

    public override int LevelIndex { get; set; }

    private void Awake()
    {
        instance = this;
        Init();
    }

    protected override void InitLevel()
    {
        LevelIndex = 0;
        continueButtonLevel2 = canvas.transform.GetChild(0).GetComponent<Button>();

        continueButtonLevel2.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(levelsUIManager.ContinueAfterGame); });
    }

    protected override void FinishLevel()
    {
        continueButtonLevel2.interactable = true;
    }
}
