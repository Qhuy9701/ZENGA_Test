using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private Plane quad;
    float hitDistance;
    void Start()
    {
        quad = new Plane(transform.up, transform.position);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (quad.Raycast(ray, out hitDistance))
            {
                Vector3 Point = ray.GetPoint(hitDistance);
                transform.position = Point;
            }
        }
    }
}
