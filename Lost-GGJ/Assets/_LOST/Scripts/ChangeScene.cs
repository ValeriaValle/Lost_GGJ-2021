using UnityEngine;
using KetosGames.SceneTransition;

public class ChangeScene : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private int nextSceneIdx;
    #endregion

    #region OTHER_METHODS

    public void NextScene()
    {
        SceneLoader.LoadScene(nextSceneIdx);
    }

    #endregion
}
