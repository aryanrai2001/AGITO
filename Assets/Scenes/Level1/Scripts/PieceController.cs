using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PieceController : MonoBehaviour
{
    private PuzzleController puzzleController;
    private RectTransform panelRectTransform;
    private Vector3 delta;
    private bool canPick;
    private bool isPicked;

    public void Init()
    {
        puzzleController = GetComponentInParent<PuzzleController>();
        panelRectTransform = puzzleController.transform.parent.GetComponent<RectTransform>();
        canPick = true;

        EventTrigger trigger = transform.AddComponent<EventTrigger>();
        EventTrigger.Entry entry1 = new()
        {
            eventID = EventTriggerType.PointerDown
        };
        entry1.callback.AddListener((eventData) => { Picked(); });
        trigger.triggers.Add(entry1);
        EventTrigger.Entry entry2 = new()
        {
            eventID = EventTriggerType.PointerUp
        };
        entry2.callback.AddListener((eventData) => { Dropped(); });
        trigger.triggers.Add(entry2);

        GetComponent<Image>().color = Color.gray;
    }

    public void Picked()
    {
        if (!canPick) 
            return;
        delta = GetComponent<RectTransform>().localPosition - Input.mousePosition;
        isPicked = true;
    }

    public void Dropped()
    {
        if (!canPick || !isPicked) 
            return;
        isPicked = false;
        canPick = !puzzleController.Placed(GetComponent<RectTransform>().localPosition);
        if (!canPick)
        {
            GetComponent<Image>().color = Color.white;
            GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }

    public void FixedUpdate()
    {
        if (isPicked)
        {
            if (!RectTransformUtility.RectangleContainsScreenPoint(panelRectTransform, Input.mousePosition, Level1Handler.instance.levelCamera))
            {
                Dropped();
                return;
            }
            GetComponent<RectTransform>().localPosition = (Input.mousePosition + delta);
        }
    }
}
