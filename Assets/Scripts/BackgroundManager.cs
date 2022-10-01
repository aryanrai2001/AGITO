using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    private GameObject backgroundObject;
    private Image background;

    public void Init()
    {
        backgroundObject = GameManager.instance.canvas.transform.GetChild(0).gameObject;
        background = backgroundObject.GetComponent<Image>();
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        background.overrideSprite = GameManager.assets.backgroundImages[Random.Range(0, GameManager.assets.backgroundImages.Length)];
    }
}
