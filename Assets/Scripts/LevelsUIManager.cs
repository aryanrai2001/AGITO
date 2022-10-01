using UnityEngine;
using UnityEngine.UI;

public class LevelsUIManager : MonoBehaviour
{
    private GameObject level1;
    private GameObject introPanelLevel1;
    private Button continueIntroButtonLevel1;

    public void Init()
    {
        level1 = transform.GetChild(0).gameObject;
        introPanelLevel1 = level1.transform.GetChild(0).gameObject;
        continueIntroButtonLevel1 = introPanelLevel1.transform.GetChild(1).GetChild(1).GetComponent<Button>();

        continueIntroButtonLevel1.onClick.AddListener(ContinueAfterIntroLevel1);
    }

    public void LoadLevel1()
    {
        introPanelLevel1.SetActive(true);
    }

    public void ContinueAfterIntroLevel1()
    {
        GameManager.instance.audioManager.Play("Click");
        GameManager.instance.backgroundManager.UpdateBackground();
        introPanelLevel1.SetActive(false);
    }
}
