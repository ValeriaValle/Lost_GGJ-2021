using UnityEngine;
using UnityEngine.Events;
using UnityTools.ScriptableVariables;

public class TimerPuzzle : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private float timerDuration;
    private float timeLeft;

    [SerializeField]
    private GenericBool timerOn;

    public UnityEvent onTimeEnded;
    #endregion

    #region UNITY_METHODS

    void Start()
    {
        timeLeft = timerDuration;
    }

    void Update()
    {
        if (timerOn.var)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0f)
            {
                timerOn.var = false;
                timeLeft = timerDuration;
                onTimeEnded.Invoke();
            }
        }
    }

    #endregion

    #region OTHER_METHODS

    #endregion
}
