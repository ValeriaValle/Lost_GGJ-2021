using UnityEngine;
using UnityEngine.UI;
using UnityTools.ScriptableVariables;

public class BlurScreen : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private float increaseBlurFactor = 0.5f;
    private Image blur;

    [Header("Global Variables")]
    [SerializeField]
    private GenericBool blurScreen;
    [SerializeField]
    private GenericFloat guardianDistance;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        blur = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (blurScreen.var)
        {
            var tempColor = blur.color;
            tempColor.a = increaseBlurFactor / guardianDistance.var;
            blur.color = tempColor;
        }

        if (!blurScreen.var)
        {
            var tempColor = blur.color;
            tempColor.a = 0f;
            blur.color = tempColor;
        }
    }
    #endregion

    #region OTHER_METHODS

    #endregion
}
