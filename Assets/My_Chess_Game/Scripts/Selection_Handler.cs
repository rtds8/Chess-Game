using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Handler : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    private Transform m_current, m_previous;

    private void OnValidate()
    {
        if (m_camera == null)
            m_camera = Camera.main;
    }

    void FixedUpdate()
    {
        Vector2 mouse_position = Input.mousePosition;
        Ray ray = m_camera.ScreenPointToRay(mouse_position);

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            m_current = raycastHit.transform;
            if (m_previous == null)
            {
                m_previous = m_current;
                m_current.position += new Vector3(0, 0.1f, 0);
            }
            
            if (m_current != m_previous)
            {
                m_previous.position -= new Vector3(0, 0.1f, 0);
                m_current.position += new Vector3(0, 0.1f, 0);
                m_previous = m_current;
            }
        }
        else
        {
            m_previous.position -= new Vector3(0, 0.1f, 0);
            m_previous = null;
        }
    }
}