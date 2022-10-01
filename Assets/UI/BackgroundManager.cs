using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Sprite[] backgroundImages;

    [HideInInspector] public Image background;

    public void Init()
    {
        UpdateBackground();
    }

    public void UpdateBackground()
    {
        background.overrideSprite = backgroundImages[Random.Range(0, backgroundImages.Length)];
    }
}
