using UnityEngine;
using UnityEngine.UI;

public class Level2Handler : LevelHandler
{
    [HideInInspector] public Button continueButtonLevel2;

    public override int LevelIndex { get; set; }

    private void Awake()
    {
        instance = this;
        Init();
    }

    public override void InitLevel()
    {
        LevelIndex = 2;
        continueButtonLevel2 = canvas.transform.GetChild(0).GetComponent<Button>();

        continueButtonLevel2.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(levelsUIManager.ContinueAfterGame); });
    }

    public override void FinishLevel()
    {
        continueButtonLevel2.interactable = true;
    }
}
