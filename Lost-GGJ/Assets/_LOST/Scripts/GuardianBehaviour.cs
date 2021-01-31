using UnityEngine;
using UnityEngine.Events;
using UnityTools.ScriptableVariables;


public class GuardianBehaviour : MonoBehaviour
{
    #region VARIABLES

    private Transform player;

    [SerializeField]
    private float detectDistance = 5f;

    [Header("Global Variables")]
    [SerializeField]
    private GenericFloat distance;
    [SerializeField]
    private GenericBool blurScreen;

    public UnityEvent shakeCam, stopShakeCam;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        blurScreen.var = false;
    }

    void Update()
    {
        distance.var = Vector3.Distance(gameObject.transform.position, player.position);

        if (distance.var <= detectDistance)
        {
            shakeCam.Invoke();
            blurScreen.var = true;
        }
        if (distance.var >= detectDistance)
        {
            stopShakeCam.Invoke();
            blurScreen.var = false;
        }
    }
    #endregion

    #region OTHER_METHODS

    #endregion
}
