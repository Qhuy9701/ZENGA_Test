using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 1f;
    private Plane plane;
    private Vector3 lastPos;
    private Vector3 startPos;

    private void Start()
    {
        plane = new Plane(transform.forward, transform.position);
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && plane.Raycast(ray, out float hitDist))
        {
            lastPos = Input.mousePosition;
            startPos = ray.GetPoint(hitDist);
        }
        else if (Input.GetMouseButton(0) && plane.Raycast(ray, out hitDist))
        {
            Vector3 hitPoint = ray.GetPoint(hitDist);
            float deltaAngle = Vector3.SignedAngle(startPos - transform.position, hitPoint - transform.position, transform.forward);
            transform.Rotate(transform.forward, deltaAngle * speed * Time.deltaTime, Space.World);
            lastPos = Input.mousePosition;
        }
    }
}
