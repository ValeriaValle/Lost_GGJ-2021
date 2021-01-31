using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES

    public CharacterController controller;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private AudioSource playerAudio;
    private bool isWalking;

    #endregion

    #region UNITY_METHODS

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Audio
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (!isWalking)
            {
                playerAudio.Play();
                isWalking = true;
            }
        }
        else
        {
            playerAudio.Stop();
            isWalking = false;
        }
    }
    #endregion
}
