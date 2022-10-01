using UnityEngine;
using UnityEngine.UI;

public class Level1ImageController : MonoBehaviour
{
    private GameObject hubbleImage;
    private Image blurryImage;

    private Slider clarityIndicator;

    private Color imageColor;
    private int total;

    public void Init()
    {
        hubbleImage = transform.GetChild(0).gameObject;
        blurryImage = hubbleImage.transform.GetChild(1).GetComponent<Image>();

        clarityIndicator = transform.GetChild(1).GetComponent<Slider>();

        imageColor = new Color(1, 1, 1, 0);
        total = 0;
    }

    public void UpdateAlpha(int section)
    {
        if (total + section > 90) 
            return;
        total += section;
        float alpha = total/90.0f;
        imageColor.a = 1.0f - alpha;
        blurryImage.color = imageColor;
        clarityIndicator.value = alpha;
        if (alpha == 1.0f)
            Level1Handler.instance.Finished();
    }
}
