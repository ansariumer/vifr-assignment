using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 1000f; // mouse sensitivity
    float xRotation = 0f; //Keeps the track of how far up or down the camera is currently looking
    float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // this restricts the rotation

        yRotation -= mouseX;
        //yRotation = M
        
        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
    }


}
