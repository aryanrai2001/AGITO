using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Level
{
    public string levelName;
    [TextArea]
    public string levelInfo;
}

public class LevelManager : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public Color levelSelectedColor;

    [HideInInspector] public int selectedLevel = 0;
    private Button[] levelButtons;
    private ColorBlock originalColors;
    private ColorBlock selectedColors;

    private GameObject levelsHolder;
    private TextMeshProUGUI levelInfoText;

    public void Init(GameObject levelsHolder, TextMeshProUGUI levelInfoText)
    {
        if (GameManager.assets.levels.Length != SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.LogError("Level Presets Don't Match Actual Levels!");
            return;
        }

        //Reset(); // !!!!!!!!!!!!!!!!!!!!!!!!!!! Remove This !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        this.levelsHolder = levelsHolder;
        this.levelInfoText = levelInfoText;

        levelButtons = new Button[GameManager.assets.levels.Length];
        originalColors = levelButtonPrefab.GetComponent<Button>().colors;
        selectedColors = levelButtonPrefab.GetComponent<Button>().colors;
        selectedColors.disabledColor = levelSelectedColor;

        int levelReached = PlayerPrefs.GetInt("LevelReached", 0);
        int holderSize = 250 * GameManager.assets.levels.Length;
        levelsHolder.GetComponent<RectTransform>().sizeDelta = new Vector2(0, holderSize);

        for (int i = 0; i < GameManager.assets.levels.Length; i++)
        {
            Button levelButton = Instantiate(levelButtonPrefab).GetComponent<Button>();
            levelButton.transform.SetParent(levelsHolder.transform, false);
            levelButton.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, -125 - (i * 250), 0);
            levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(GameManager.assets.levels[i].levelName);
            levelButton.onClick.AddListener(() => SelectLevel(levelButton.transform.GetSiblingIndex()));
            if (i > levelReached)
            {
                levelButton.interactable = false;
                levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
            levelButtons[i] = levelButton;
        }
    }

    public void UnlockLevel()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 0);
        if (levelReached >= levelButtons.Length)
            return;
        levelButtons[levelReached].interactable = true;
        levelButtons[levelReached].transform.GetChild(0).GetComponent<TextMeshProUGUI>().fontStyle &= ~FontStyles.Strikethrough;
    }

    public void SelectLevel(int level)
    {
        if (level < 0 || level >= GameManager.assets.levels.Length)
        {
            levelInfoText.SetText("");
            levelButtons[selectedLevel].colors = originalColors;
            levelButtons[selectedLevel].interactable = true;
            selectedLevel = 0;
        }
        else
        {
            GameManager.instance.audioManager.Play("Click");
            levelInfoText.SetText(GameManager.assets.levels[level].levelInfo);
            levelButtons[selectedLevel].colors = originalColors;
            levelButtons[selectedLevel].interactable = true;
            levelButtons[level].colors = selectedColors;
            levelButtons[level].interactable = false;
            selectedLevel = level;
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("LevelReached", 0);
    }
}
