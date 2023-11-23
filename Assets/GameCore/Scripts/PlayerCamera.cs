using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float movementSpeed = 10f;   // �������� ����������� ������
    public float rotationSpeed = 100f;  // �������� �������� ������
    public float zoomSpeed = 10f;       // �������� ����������� / ��������� ������

    public float minZoomDistance = 5f;  // ����������� ��������� ����������� ������
    public float maxZoomDistance = 20f; // ������������ ��������� ����������� ������
    public float zoomSensitivity = 1f;  // ���������������� �������� ����

    public float tiltSpeed = 10f;       // �������� ������� ������
    public float minTiltAngle = -30f;   // ����������� ���� ������� ������
    public float maxTiltAngle = 60f;    // ������������ ���� ������� ������

    private void Update()
    {
        // �������� ����������� ������� � ����� ������
        if (Input.mousePosition.x < 5)
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.x > Screen.width - 5)
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.y < 5)
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.mousePosition.y > Screen.height - 5)
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);
        }

        // �������� ����������� / ��������� �������� ����
        float zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * zoomSensitivity;
        transform.Translate(Vector3.forward * zoom);

        // ����������� ��������� ����������� ������
        Vector3 cameraPos = transform.localPosition;
        cameraPos.z = Mathf.Clamp(cameraPos.z, -maxZoomDistance, -minZoomDistance);
        transform.localPosition = cameraPos;

        // �������� �������� ������
        if (Input.GetMouseButton(1))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -rotationX, Space.World);
            transform.Rotate(Vector3.right, rotationY, Space.Self);
        }

        // �������� ������� ������
        float tilt = Input.GetAxis("Vertical") * tiltSpeed * Time.deltaTime;
        float currentTiltAngle = transform.localEulerAngles.x;

        // ����������� ���� ������� ������
        if (tilt > 0 && currentTiltAngle > 180f)
        {
            currentTiltAngle -= 360f;
        }

        float newTiltAngle = Mathf.Clamp(currentTiltAngle + tilt, minTiltAngle, maxTiltAngle);
        transform.localEulerAngles = new Vector3(newTiltAngle, transform.localEulerAngles.y, transform.localEulerAngles.z);

        // �������� ����������� � ������� ������ WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime, Space.World);

        // �������� ������� ������ � ������� ������ RF
        tilt = Input.GetAxis("Tilt") * tiltSpeed * Time.deltaTime;
        Vector3 rotation = transform.localEulerAngles;
        rotation.x = Mathf.Clamp(rotation.x - tilt, minTiltAngle, maxTiltAngle);
        transform.localRotation = Quaternion.Euler(rotation);

        // �������� �������� ������ � ������� ������ QE ��� ������� ������� ������� ����
        float rotationInput = Input.GetKey(KeyCode.Q) ? 1f : Input.GetKey(KeyCode.E) ? -1f : 0f;
        float rotationDelta = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotationDelta); 
    }
}