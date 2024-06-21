using DG.Tweening;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Camera mainCamera;
    private bool isMoving;
    private float zOffset;
    private Vector3 initialMousePosition;
    private Quaternion initialRotation;
    private bool isRotating;
    private Vector3 initialRotationVector;
    public float rotationSpeed = 1.0f;
    public float rotationMultiplier = 10.0f;
    public float animationDuration = 0.5f;
    public string shapeName; 
    public Vector3 initialScale;
   
    void Start()
    {
        mainCamera = Camera.main;
        zOffset = mainCamera.WorldToScreenPoint(transform.position).z;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            var difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
            if (IsMouseOverObject())
            {
                transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
                isMoving = true;
                initialMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            isMoving = false;
            ControlGravity(true);
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button pressed
        {
            if (IsMouseOverObject())
            {
                isRotating = true;
                initialRotationVector = transform.eulerAngles;
                initialMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButtonUp(1)) // Right mouse button released
        {
            isRotating = false;
        }

        if (isMoving)
        {
            ControlGravity(false);
            MoveWithMouse();
        }

        if (isRotating)
        {
            RotateWithMouse();
        }
    }

    bool IsMouseOverObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.transform == transform;
    }

    void MoveWithMouse()
    {   
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zOffset; // Keep the object's Z offset
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
    }

    void RotateWithMouse()
    {
        
        float deltaX = (Input.mousePosition.x - initialMousePosition.x) * rotationSpeed;
        float deltaY = (Input.mousePosition.y - initialMousePosition.y) * rotationSpeed;

        float rotationX = deltaY * rotationMultiplier;
        float rotationZ = -deltaX * rotationMultiplier;

        transform.eulerAngles = initialRotationVector + new Vector3(rotationX, 0, rotationZ);
    }

    public void GetInitialScale()
    {
        initialScale = transform.localScale;
    }

    public void ScaleUp()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(initialScale, animationDuration);
    }
    public void ResetObjectTransform()
    {
        
        ControlGravity(false);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = SpawnManager.instance.spawnPosition.position;
        transform.rotation = initialRotation;
        ScaleUp();
    }

    void ControlGravity(bool value)
    {
        GetComponent<Rigidbody>().useGravity = value;
    }

    
}
