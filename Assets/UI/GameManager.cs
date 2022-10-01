using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector] GameManager Instance;

    public Image background;
    public Sprite[] backgroundImages;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        DontDestroyOnLoad(gameObject);
        background.overrideSprite = backgroundImages[Random.Range(0, 9)];
    }
}
