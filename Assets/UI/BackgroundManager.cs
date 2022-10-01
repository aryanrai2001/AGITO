using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public Image background;
    public Sprite[] backgroundImages;

    public void UpdateBackground()
    {
        background.overrideSprite = backgroundImages[Random.Range(0, backgroundImages.Length)];
    }
}
