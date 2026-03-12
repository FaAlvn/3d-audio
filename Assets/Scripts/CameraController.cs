using UnityEngine;
using UnityEngine.InputSystem; 

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float lookSpeed = 0.5f; 

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed) moveZ += 10f;
            if (Keyboard.current.sKey.isPressed) moveZ -= 10f;
            if (Keyboard.current.aKey.isPressed) moveX -= 10f;
            if (Keyboard.current.dKey.isPressed) moveX += 10f;
        }

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            rotationY += mouseDelta.x * lookSpeed;
            rotationX -= mouseDelta.y * lookSpeed;
            
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);
            
            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);
        }
    }
}