using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    private PieceController[] pieces;
    private int[] unevenSections;
    private float snapSensitivity;
    private int piecesPlaced;

    public void Init()
    {
        int pieceCount = transform.childCount;
        pieces = new PieceController[pieceCount];

        int total = 90, value;
        unevenSections = new int[pieceCount];
        for (int i = 0; i < pieceCount; i++)
        {
            int num = total / (pieceCount - i);
            value = num + Random.Range((i - pieceCount)/2, (pieceCount - i) / 2);
            total -= value;
            unevenSections[i] = value;
        }

        snapSensitivity = 7;
        piecesPlaced = 0;

        for (int i = 0; i < pieceCount; i++)
        {
            pieces[i] = transform.GetChild(i).GetComponent<PieceController>();
            pieces[i].Init();
        }
    }

    public bool Placed(Vector3 piecePosition)
    {
        if (piecePosition.sqrMagnitude < snapSensitivity * snapSensitivity * snapSensitivity)
        {
            Level1Handler.instance.panel1.UpdateAlpha(unevenSections[piecesPlaced]);
            Level1Handler.instance.panel2.UpdateAlpha(unevenSections[8-piecesPlaced]);
            piecesPlaced++;
            return true;
        }
        return false;
    }
}
