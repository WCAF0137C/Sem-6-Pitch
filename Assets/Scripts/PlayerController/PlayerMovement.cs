using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.04f;
    public float strafeSpeed = 0.04f;

    public float horizontal;
    public float vertical;

    public Vector3 move;

    CharacterController playerController;

    [Header("PlayerRotationReset")]

    public float rotationSpeed;
    public Quaternion newResetAngle;
    public Camera cam;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        // Player rotation to cam

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            newResetAngle = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, newResetAngle, rotationSpeed * Time.deltaTime).normalized;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        move = new Vector3(horizontal, 0, vertical);
        playerController.Move(move * Time.deltaTime * moveSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            playerController.Move(transform.TransformDirection(Vector3.forward) * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerController.Move(transform.TransformDirection(Vector3.back) * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerController.Move(transform.TransformDirection(Vector3.left) * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerController.Move(transform.TransformDirection(Vector3.right) * strafeSpeed);
        }
    }
}
