using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSensitivity = 2f;

    private Rigidbody rb;
    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 angles = transform.eulerAngles;
        rotationY = angles.y;
        rotationX = angles.x;
    }

    void Update()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        transform.eulerAngles = new Vector3(rotationX, rotationY, 0f);

        // WASD movement relative to look direction
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float up = 0f;

        if (Input.GetKey(KeyCode.UpArrow)) up = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) up = -1f;

        Vector3 move = (transform.forward * v + transform.right * h + transform.up * up) * moveSpeed;
        rb.linearVelocity = move;

        // Press Escape to release the cursor if needed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}