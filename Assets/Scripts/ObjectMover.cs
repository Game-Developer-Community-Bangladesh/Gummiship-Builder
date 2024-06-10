using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour
{
    private Camera mainCamera;
    private bool isMoving;
    private float zOffset;
    private Quaternion initialRotation;

    void Start()
    {
        mainCamera = Camera.main;
        zOffset = mainCamera.WorldToScreenPoint(transform.position).z;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the GameObject
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isMoving = true;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            ControlGravity(true);
        }

        if (isMoving)
        {
            Debug.Log("Mouse is being used");
            ControlGravity(false);
            MoveWithMouse();

        }
        else
        {
            Debug.Log("Mouse is not being used");
        }
    }

    void MoveWithMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zOffset; // Keep the object's Z offset

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
    }

    public void ResetObjectTransform()
    {
        ControlGravity(false);
        transform.position = SpawnManager.instance.spawnPosition.position;
        transform.rotation = initialRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
    void ControlGravity(bool value)
    {
        GetComponent<Rigidbody>().useGravity = value;
    }



    
}