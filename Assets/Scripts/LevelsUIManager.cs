using UnityEngine;
using UnityEngine.UI;

public class LevelsUIManager : MonoBehaviour
{
    private GameObject level1;
    private GameObject introPanelLevel1;
    private GameObject infoPanelLevel1;
    private Button continueIntroButtonLevel1;
    private Button continueInfoButtonLevel1;

    public void Init()
    {
        level1 = transform.GetChild(0).gameObject;
        introPanelLevel1 = level1.transform.GetChild(0).gameObject;
        infoPanelLevel1 = level1.transform.GetChild(1).gameObject;
        continueIntroButtonLevel1 = introPanelLevel1.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        continueInfoButtonLevel1 = infoPanelLevel1.transform.GetChild(1).GetChild(1).GetComponent<Button>();

        continueIntroButtonLevel1.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(ContinueAfterIntroLevel1); });
        continueInfoButtonLevel1.onClick.AddListener(delegate { GameManager.instance.menuManager.TransitionOnButton(ContinueAfterInfoLevel1); });
    }

    public void LoadLevel1()
    {
        introPanelLevel1.SetActive(true);
    }

    public void ContinueAfterIntroLevel1()
    {
        introPanelLevel1.SetActive(false);
        Level1Handler.instance.canvas.gameObject.SetActive(true);
        Level1Handler.instance.levelCamera.gameObject.SetActive(true);
    }

    public void ContinueAfterGameLevel1()
    {
        GameManager.instance.levelsUIManager.FinishLevel1();
        Level1Handler.instance.canvas.gameObject.SetActive(false);
        Level1Handler.instance.levelCamera.gameObject.SetActive(false);
    }

    public void FinishLevel1()
    {
        infoPanelLevel1.SetActive(true);
    }

    public void ContinueAfterInfoLevel1()
    {
        infoPanelLevel1.SetActive(false);
        Level1Handler.instance.EndLevel();
    }
}
