using UnityEngine;
using UnityEngine.UI;


public class FakeFog : MonoBehaviour
{
    #region VARIABLES

    private Transform player;

    [SerializeField]
    private float increaseFogFactor = 0.1f;
    [SerializeField]
    private float detectDistance = 5f;
    private float distance;

    [SerializeField]
    private Image fogImage;
    #endregion

    #region UNITY_METHODS

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, player.position);

        if (distance >= detectDistance)
        {
            var tempColor = fogImage.color;
            tempColor.a = increaseFogFactor * distance;
            fogImage.color = tempColor;
            Debug.DrawLine(transform.position, player.position, Color.green);
        }
        if (distance <= detectDistance)
        {
            var tempColor = fogImage.color;
            tempColor.a = 0f;
            fogImage.color = tempColor;
        }
    }
    #endregion
}
