using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Sprite[] backgroundImages;

    [HideInInspector] public GameObject backgroundObject;
    [HideInInspector] public Image background;

    public void Init()
    {
        backgroundObject = GameManager.instance.canvas.transform.GetChild(0).gameObject;
        background = backgroundObject.GetComponent<Image>();
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        background.overrideSprite = backgroundImages[Random.Range(0, backgroundImages.Length)];
    }
}
