using UnityEngine;

public class NIRCamController : MonoBehaviour
{
    private RectTransform rectTransfrom;

    public void Start()
    {
        rectTransfrom = GetComponent<RectTransform>();
    }

    public void FixedUpdate()
    {
        rectTransfrom.position = LevelHandler.instance.levelCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
