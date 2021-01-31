using UnityEngine;
using UnityEngine.Events;

public class LevelComplete : MonoBehaviour
{
    #region VARIABLES

    public UnityEvent onLevelFinished;
    #endregion

    #region UNITY_METHODS

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onLevelFinished.Invoke();
        }
    }
    #endregion
}
