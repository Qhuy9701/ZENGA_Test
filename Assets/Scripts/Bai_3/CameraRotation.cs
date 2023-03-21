using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float leftLimit = -60f;
    public float rightLimit = 60f;

    private Vector3 startMousePos;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            float deltaMousePos = Input.mousePosition.x - startMousePos.x;
            float newRotation = transform.rotation.eulerAngles.y - deltaMousePos * rotationSpeed * Time.deltaTime;

            if (newRotation > 180f)
            {
                newRotation -= 360f;
            }
            else if (newRotation < -180f)
            {
                newRotation += 360f;
            }

            newRotation = Mathf.Clamp(newRotation, leftLimit, rightLimit);

            transform.rotation = Quaternion.Euler(0f, newRotation, 0f);
        }
    }
}
