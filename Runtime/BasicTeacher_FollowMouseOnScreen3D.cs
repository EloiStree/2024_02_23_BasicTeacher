using UnityEngine;

public class BasicTeacher_FollowMouseOnScreen3D : MonoBehaviour
{
    public Transform m_whatToMove;
    public float m_zDistance=10;
    Camera m_mainCamera;

    void Start()
    {
        m_mainCamera = Camera.main;
    }
    private void Reset()
    {
        m_whatToMove = transform;
    }

    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        mousePosition.z = m_zDistance; // Distance from the camera to the object
        Vector3 worldPosition = m_mainCamera.ScreenToWorldPoint(mousePosition);

        m_whatToMove.position = worldPosition;
    }
}