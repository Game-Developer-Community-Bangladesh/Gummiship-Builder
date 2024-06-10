using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public static SpawnManager instance;

    public List<GameObject> prefabObjects = new List<GameObject>();
    private List<GameObject> TempObjects = new List<GameObject>();
    public Transform spawnPosition;

    public void Awake()
    {   
        if (instance == null) instance = this;
        else Destroy(instance);
    }
    void Start()
    {   
        SpawnObject();

    }

    [ContextMenu("SpawnObject")]
    public void SpawnObject()
    {
        if (prefabObjects.Count <= 0 && TempObjects.Count > 0)
        {
            prefabObjects = new List<GameObject>(TempObjects);
            TempObjects.Clear();
        }
        int randomIndex = Random.Range(0, prefabObjects.Count);
        Instantiate(prefabObjects[randomIndex], spawnPosition.position, prefabObjects[randomIndex].transform.rotation);
        TempObjects.Add(prefabObjects[randomIndex]);
        prefabObjects.RemoveAt(randomIndex);
    }
}
