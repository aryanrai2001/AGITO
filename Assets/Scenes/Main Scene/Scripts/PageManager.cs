using System;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public Canvas canvas;

    [HideInInspector] public GameObject background;

    private bool isBackgroundgEnabled = true;

    public void Init()
    {
        background = canvas.transform.GetChild(0).gameObject;
        background.SetActive(isBackgroundgEnabled);
        GameManager.instance.backgroundManager.background = background.GetComponent<Image>();
    }

    public void ToggleBackground()
    {
        isBackgroundgEnabled = !isBackgroundgEnabled;
        background.SetActive(isBackgroundgEnabled);
    }
}
