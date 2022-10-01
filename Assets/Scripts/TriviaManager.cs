using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class QuestionPreset
{
    [TextArea]
    public string question;
    public string option1, option2, option3, option4;
    [Range(1, 4)]
    public int correctOption;
}

public class TriviaManager : MonoBehaviour
{
    public GameObject questionPanelPrefab;
    public QuestionPreset[] questionPresets;
    private GameObject[] questionPanels;
    private int questionIndex;
    
    public bool Init()
    {
        if (questionPresets.Length == 0)
            return false;
        questionPanels = new GameObject[questionPresets.Length];
        questionIndex = 0;
        for (int i = 0; i < questionPanels.Length; i++)
        {
            QuestionPreset preset = questionPresets[i];
            questionPanels[i] = Instantiate(questionPanelPrefab, transform);
            questionPanels[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = $"<b><u>Q{i + 1}</u> -</b> {preset.question}";
            questionPanels[i].SetActive(true);
            Transform optionButtons = questionPanels[i].transform.GetChild(1);
            optionButtons.gameObject.SetActive(true);
            for (int j = 0; j < 4; j++)
            {
                Button option = optionButtons.GetChild(j).GetComponent<Button>();
                bool isCorrect = j == preset.correctOption - 1;
                int iCopy = i;
                option.onClick.AddListener(delegate { OptionChosen(isCorrect, iCopy); });
                string optionString = "";
                switch(j)
                {
                    case 0:
                        optionString = preset.option1;
                        break;
                    case 1:
                        optionString = preset.option2;
                        break;
                    case 2:
                        optionString = preset.option3;
                        break;
                    case 3:
                        optionString = preset.option4;
                        break;
                }
                option.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = optionString;
            }

            Transform confitmationButtons = questionPanels[i].transform.GetChild(2);
            confitmationButtons.gameObject.SetActive(true);
            confitmationButtons.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { Confirm(true); });
            confitmationButtons.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { Confirm(false); });
            confitmationButtons.gameObject.SetActive(false);
            questionPanels[i].SetActive(false);
        }
        questionPanels[0].SetActive(true);
        return true;
    }

    public void Refresh()
    {
        if (questionPresets.Length == 0)
            return;
        for (int i = 0; i < questionPanels.Length; i++)
        {
            questionPanels[i].SetActive(true);
            questionPanels[i].transform.GetChild(1).gameObject.SetActive(true);
            questionPanels[i].transform.GetChild(2).gameObject.SetActive(false);
            questionPanels[i].SetActive(false);
        }
        questionPanels[0].SetActive(true);
        questionIndex = 0;
    }

    private void OptionChosen(bool isCorrect, int i)
    {
        GameManager.instance.audioManager.Play("Click");
        GameObject questionPanel = questionPanels[i];
        questionPanel.transform.GetChild(1).gameObject.SetActive(false);
        questionPanel.transform.GetChild(2).gameObject.SetActive(true);
        questionPanel.transform.GetChild(2).GetChild(0).gameObject.SetActive(isCorrect);
        questionPanel.transform.GetChild(2).GetChild(1).gameObject.SetActive(!isCorrect);
    }

    private void Confirm(bool isCorrect)
    {
        GameManager.instance.audioManager.Play("Click");
        if (isCorrect)
        {
            questionPanels[questionIndex++].SetActive(false);
            if (questionIndex < questionPanels.Length)
            {
                questionPanels[questionIndex].SetActive(true);
            }
            else
            {
                GameManager.instance.menuManager.Transition(LevelHandler.instance.levelsUIManager.ContinueAfterTrivia);
            }
        }
        else
        {
            GameManager.instance.menuManager.Transition(LevelHandler.instance.levelsUIManager.UnloadLevelUI);
        }
    }

}
