using UnityEngine;
using System.Collections;

public class CamLook : MonoBehaviour
{
    #region VARIABLES

    [SerializeField]
    private float mouseSensitivity = 100f;
    [SerializeField]
    private Transform playerBody;

    float xRotation = 0f;
    bool movementUnlocked = false;
    #endregion

    #region UNITY_METHODS

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(UnlockMovement(1.0f));
    }

    void Update()
    {
        if (movementUnlocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
    #endregion

    #region  OTHER_METHODS

    IEnumerator UnlockMovement(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        movementUnlocked = true;
    }
    #endregion
}
