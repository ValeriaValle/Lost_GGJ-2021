using UnityEngine;

public class MagicTree : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private GameObject fade, treeCamera, player;

    [Header("Tree Magic Stuff")]
    [SerializeField]
    private GameObject[] solutionSymbols;
    [SerializeField]

    private bool treeMagicOn = false;

    #endregion

    #region UNITY_METHODS

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && treeMagicOn)
        {
            Debug.Log("Back");
            fade.SetActive(true);
        }
    }
    #endregion

    #region OTHER_METHODS

    public void TogglePuzzleSolution()
    {
        treeMagicOn = !treeMagicOn;
        treeCamera.SetActive(treeMagicOn);
        player.SetActive(!treeMagicOn);

        for (int i = 0; i < solutionSymbols.Length; i++)
        {
            solutionSymbols[i].SetActive(treeMagicOn);
        }
    }
    #endregion
}
