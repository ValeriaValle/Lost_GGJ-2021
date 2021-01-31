using UnityEngine;
using UnityEngine.Events;
using UnityTools.ScriptableVariables;

public class PuzzlePiece : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private int pieceIdx;

    [SerializeField]
    private GenericInt currentPiece;

    public UnityEvent pieceSelected;

    #endregion

    #region UNITY_METHODS

    #endregion

    #region OTHER_METHODS

    public void PieceSelected()
    {
        currentPiece.var = pieceIdx;
        pieceSelected.Invoke();
    }
    #endregion
}
