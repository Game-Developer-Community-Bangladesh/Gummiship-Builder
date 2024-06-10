using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {   
        SpawnManager.instance.SpawnObject();
        Destroy(other.gameObject);

    }
}
