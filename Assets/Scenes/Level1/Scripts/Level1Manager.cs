using UnityEngine;
using UnityEngine.UI;

public class Level1Manager : MonoBehaviour
{
    private GameObject introPanel;
    private Button continueIntroButton;

    public void Init()
    {
        introPanel = transform.GetChild(0).gameObject;
        continueIntroButton = introPanel.transform.GetChild(1).GetChild(1).GetComponent<Button>();

        continueIntroButton.onClick.AddListener(ContinueAfterIntro);
    }

    public void Load()
    {
        introPanel.SetActive(true);
    }

    public void ContinueAfterIntro()
    {
        GameManager.instance.audioManager.Play("Click");
        GameManager.instance.backgroundManager.UpdateBackground();
        introPanel.SetActive(false);
    }
}
