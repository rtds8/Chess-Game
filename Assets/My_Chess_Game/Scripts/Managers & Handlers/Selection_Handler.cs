using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Handler : MonoBehaviour
{
    public static Selection_Handler _instance;
    [SerializeField] private LayerMask Chess_Men;
    [SerializeField] private Camera m_camera;
    [HideInInspector] public GameObject m_current, m_previous;

    private void OnValidate()
    {
        if (m_camera == null)
            m_camera = Camera.main;

        if (_instance == null)
            _instance = this;
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouse_position = Input.mousePosition;
            Ray ray = m_camera.ScreenPointToRay(mouse_position);

            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, Chess_Men))
            {
                m_current = raycastHit.transform.gameObject;
                if (m_previous == null)
                {
                    m_current.transform.position += new Vector3(0, 0.1f, 0);
                    m_previous = m_current;
                }

                if (m_current != m_previous)
                {
                    m_previous.transform.position -= new Vector3(0, 0.1f, 0);
                    m_current.transform.position += new Vector3(0, 0.1f, 0);
                    m_previous = m_current;
                }
            }

            else
            {
                m_previous.transform.position -= new Vector3(0, 0.1f, 0);
                m_previous = null;
                m_current = null;
            }
        }
    }
}