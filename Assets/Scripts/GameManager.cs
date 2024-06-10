using System.Collections.Generic;
using UnityEngine;

public class DragAndDropObject : MonoBehaviour
{
    
    private GameObject draggedObject;
    private Vector3 initialMousePosition;
    private Vector3 initialObjectPosition;
    

    //private void Start()
    //{
    //    // Instantiate the object and set its initial properties
    //    //int randomIndex = Random.Range(0, prefabObjects.Count);
    //    //draggedObject = Instantiate(prefabObjects[randomIndex], 
    //    //    new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), Quaternion.identity);
    //    draggedObject.GetComponent<Rigidbody>().useGravity = false;
    //    draggedObject.GetComponent<Rigidbody>().isKinematic = true;
    //}

    //private void Update()
    //{
        
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // Store the initial mouse position and object position
    //        initialMousePosition = Input.mousePosition;
    //        initialObjectPosition = draggedObject.transform.position;
    //    }

    //    if (Input.GetMouseButton(0))
    //    {
    //        // Update the object's position based on the change in mouse position
    //        Vector3 delta = (Vector3)Input.mousePosition - initialMousePosition;
    //        draggedObject.transform.position = new Vector3(
    //            initialObjectPosition.x + delta.x * Time.deltaTime,
    //            initialObjectPosition.y,
    //            initialObjectPosition.z + delta.y * Time.deltaTime
    //        );
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        //  fall under gravity
    //        draggedObject.GetComponent<Rigidbody>().isKinematic = false;
    //        draggedObject.GetComponent<Rigidbody>().useGravity = true;
    //    }
    //}

}