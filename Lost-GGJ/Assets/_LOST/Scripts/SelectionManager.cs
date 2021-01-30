using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private Image crosshair;

    [SerializeField]
    private Vector3 selectedScale;

    [SerializeField]
    private float rayDistance;

    #endregion

    #region UNITY_METHODS

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        int layerMask = 1 << 7; //Change to "Interactable" layer accordingly

        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            crosshair.rectTransform.localScale = selectedScale;
        }
        else
        {
            crosshair.rectTransform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
            {
                //TODO: Interaction functionality
                Debug.Log("Interactable");
            }
        }
    }
    #endregion
}
