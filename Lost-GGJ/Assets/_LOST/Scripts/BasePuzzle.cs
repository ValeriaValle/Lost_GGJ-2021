using UnityEngine;
using UnityTools.ScriptableVariables;

public class BasePuzzle : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private GenericInt currentPiece;

    [SerializeField]
    private int[] puzzleSolution;
    private int currentIdx = 0;
    #endregion

    #region OTHER_METHODS

    public void VerifyPuzzleOrder()
    {
        if (currentPiece.var == puzzleSolution[currentIdx])
        {
            Debug.Log("Correct Piece");
            currentIdx++;
        }
        else
        {
            ResetPuzzle();
        }

        if (currentIdx > 3)
        {
            Debug.Log("Puzzle Solved");
            gameObject.GetComponent<BasePuzzle>().enabled = false;
        }

    }

    public void ResetPuzzle()
    {
        Debug.Log("Wrong");
        currentIdx = 0;
    }
    #endregion
}
