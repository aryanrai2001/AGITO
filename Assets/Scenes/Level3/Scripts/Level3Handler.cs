using UnityEngine;
using UnityEngine.UI;

public class Level3Handler : LevelHandler
{
    [HideInInspector] public Button continueButtonLevel3;

    public override int LevelIndex { get; set; }

    private void Awake()
    {
        instance = this;
        Init();
    }

    public override void InitLevel()
    {
        LevelIndex = 3;
        continueButtonLevel3 = canvas.transform.GetChild(0).GetComponent<Button>();

        continueButtonLevel3.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(levelsUIManager.ContinueAfterGame); });
    }

    public override void FinishLevel()
    {
        continueButtonLevel3.interactable = true;
    }
}
