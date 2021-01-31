using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityTools.Events;

public class SelectionManager : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private Image crosshair;

    [SerializeField]
    private Vector3 selectedScale;
    [SerializeField]
    private GameObject txtInteract;

    [SerializeField]
    private float rayDistance;

    private GameObject interactable;

    public UnityEvent Interaction;
    #endregion

    #region UNITY_METHODS

    void Start()
    {
        interactable = null;
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;
        int layerMask = 1 << 7; //Change to "Interactable" layer accordingly

        if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
        {
            crosshair.rectTransform.localScale = selectedScale;
            txtInteract.SetActive(true);
            interactable = hit.transform.gameObject;
            interactable.GetComponent<GameEventMultipleListener>().enabled = true;
        }
        else
        {
            crosshair.rectTransform.localScale = new Vector3(1f, 1f, 1f);
            txtInteract.SetActive(false);
            if (interactable != null)
            {
                interactable.GetComponent<GameEventMultipleListener>().enabled = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, rayDistance, layerMask))
            {
                Interaction.Invoke();
            }
        }
    }
    #endregion
}
