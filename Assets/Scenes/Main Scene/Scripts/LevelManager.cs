using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Level
{
    public string levelName;
    public string levelInfo;
}

public class LevelManager : MonoBehaviour
{
    public Level[] levels;
    public GameObject levelButtonPrefab;
    public Color levelSelectedColor;

    [HideInInspector] public int selectedLevel = 0;
    private Button[] levelButtons;
    private ColorBlock originalColors;
    private ColorBlock selectedColors;

    private TextMeshProUGUI levelInfoText;

    public void Init(GameObject levelsHolder, TextMeshProUGUI levelInfoText)
    {
        if (levels.Length != SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("Level Presets Don't Match Actual Levels!");
            return;
        }

        this.levelInfoText = levelInfoText;

        levelButtons = new Button[levels.Length];
        originalColors = levelButtonPrefab.GetComponent<Button>().colors;
        selectedColors = levelButtonPrefab.GetComponent<Button>().colors;
        selectedColors.disabledColor = levelSelectedColor;

        int levelReached = PlayerPrefs.GetInt("LevelReached", 0);
        int holderSize = 250 * levels.Length;
        levelsHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(0, holderSize);

        for (int i = 0; i < levels.Length; i++)
        {
            Button levelButton = Instantiate(levelButtonPrefab).GetComponent<Button>();
            levelButton.transform.SetParent(levelsHolder.transform, false);
            levelButton.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -125 - (i * 250), 0);
            levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(levels[i].levelName);
            levelButton.onClick.AddListener(() => SelectLevel(levelButton.transform.GetSiblingIndex()));
            if (i > levelReached)
            {
                levelButton.interactable = false;
                levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            levelButtons[i] = levelButton;
        }
    }

    public void SelectLevel(int level)
    {
        if (level < 0 || level >= levels.Length-1)
        {
            levelInfoText.SetText("");
            levelButtons[selectedLevel].colors = originalColors;
            levelButtons[selectedLevel].interactable = true;
            selectedLevel = 0;
        }
        else
        {
            GameManager.instance.audioManager.Play("Click");
            levelInfoText.SetText(levels[level].levelInfo);
            levelButtons[selectedLevel].colors = originalColors;
            levelButtons[selectedLevel].interactable = true;
            levelButtons[level].colors = selectedColors;
            levelButtons[level].interactable = false;
            selectedLevel = level;
        }
    }
}
