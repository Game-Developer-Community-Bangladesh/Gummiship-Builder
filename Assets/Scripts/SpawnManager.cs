using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpawnManager : MonoBehaviour
{   
    public static SpawnManager instance;

    public TextMeshProUGUI shapeNameText;
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
        var instantiatedObject = Instantiate(prefabObjects[randomIndex], spawnPosition.position, prefabObjects[randomIndex].transform.rotation);

        UIManger.Instance.DisplayShapeName(instantiatedObject.GetComponent<ObjectMover>().shapeName);

        instantiatedObject.GetComponent<ObjectMover>()?.GetInitialScale();
        instantiatedObject.GetComponent<ObjectMover>()?.ScaleUp();

        TempObjects.Add(prefabObjects[randomIndex]);
        prefabObjects.RemoveAt(randomIndex);
    }
}
