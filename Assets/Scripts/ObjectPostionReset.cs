using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPostionReset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger is on ");
        other.gameObject.GetComponent<ObjectMover>()?.ResetObjectTransform();
        
    }
}
