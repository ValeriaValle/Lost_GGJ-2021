using UnityEngine;
using MilkShake;
using UnityTools.ScriptableVariables;

public class CamShake : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private Shaker camShaker;
    [SerializeField]
    private ShakePreset shakeFear;
    private ShakeInstance camShakeInst;

    private bool isShaking = false;
    private bool startedShake = false;

    [SerializeField]
    private float increaseShakeFactor = 0.5f;

    [Header("Global Variables")]
    [SerializeField]
    private GenericFloat guardianDistance;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        camShakeInst = camShaker.Shake(shakeFear);
        camShakeInst.Stop(0f, false);
    }

    void Update()
    {
        if (isShaking)
        {
            camShakeInst.Start(1f);
            camShakeInst.RoughnessScale = increaseShakeFactor / guardianDistance.var;
            Debug.Log("Shake");
        }

        if (startedShake && !isShaking)
        {
            camShakeInst.Stop(1f, false);
            startedShake = false;
            Debug.Log("StopShake");
        }
    }
    #endregion

    #region OTHER_METHODS

    public void StartCamShake()
    {
        startedShake = true;
        isShaking = true;
    }

    public void StopCamShake()
    {
        isShaking = false;
    }
    #endregion
}
