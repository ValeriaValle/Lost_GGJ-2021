using UnityEngine;
using UnityEngine.Events;
using UnityTools.ScriptableVariables;

public class BasePuzzle : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private GenericInt currentPiece;

    [SerializeField]
    private int[] puzzleSolution;
    private int currentIdx = 0;

    public UnityEvent onCorrectPiece, onWrongPiece, onPuzzleSolved;
    #endregion

    #region OTHER_METHODS

    public void VerifyPuzzleOrder()
    {
        if (currentPiece.var == puzzleSolution[currentIdx])
        {
            onCorrectPiece.Invoke();
            currentIdx++;
        }
        else
        {
            ResetPuzzle();
        }

        if (currentIdx > 3)
        {
            Debug.Log("Puzzle Solved");
            onPuzzleSolved.Invoke();
            gameObject.GetComponent<BasePuzzle>().enabled = false;
        }

    }

    public void ResetPuzzle()
    {
        onWrongPiece.Invoke();
        currentIdx = 0;
    }
    #endregion
}
