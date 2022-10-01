using UnityEngine;

public class Level1Handler : MonoBehaviour
{
    [HideInInspector] public static Level1Handler instance;

    [HideInInspector] public Canvas canvas;

    [HideInInspector] public ClarityHandler panel1;
    [HideInInspector] public ClarityHandler panel2;
    [HideInInspector] public PuzzleController puzzleController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogError("Multiple Level1Handler Instances Found!");
        }

        canvas = transform.GetChild(0).GetComponent<Canvas>();

        panel1 = canvas.transform.GetChild(0).GetComponent<ClarityHandler>();
        panel2 = canvas.transform.GetChild(1).GetComponent<ClarityHandler>();
        puzzleController = canvas.transform.GetChild(2).GetChild(0).GetComponent<PuzzleController>();

        panel1.Init();
        panel2.Init();
        puzzleController.Init();
        //GameManager.instance.levelsUIManager.LoadLevel1();
    }

    
}
