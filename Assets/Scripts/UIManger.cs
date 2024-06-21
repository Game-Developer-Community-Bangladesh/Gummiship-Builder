using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIManger : MonoBehaviour
{
    public static UIManger Instance;
    public TextMeshProUGUI shapeNameText;
    public GameObject MissedSlotTextPanel;
   
    [SerializeField] private float animationDuration;
    private Vector3 targetScale = new Vector3(1, 1, 1);
    private Vector3 missedTextInitialScale = new();
    public void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void Start()
    {
        missedTextInitialScale = MissedSlotTextPanel.transform.localScale;
    }

    public void DisplayShapeName(string shapeName)
    {

        shapeNameText.gameObject.SetActive(true);
        shapeNameText.text = $"Can you find a slot for this {shapeName}?";
        shapeNameText.transform.localScale = new Vector3(0, 0, 0);
        shapeNameText.transform.DOScale(targetScale, animationDuration); 

    }
    private void EmptyText(TextMeshProUGUI text)
    {
        text.text = "";
    }
    
    public void DisplaySlotMissedMessage()
    {
        shapeNameText.gameObject.SetActive(false);
        MissedSlotTextPanel.transform.DOScale(targetScale, animationDuration)
            .OnComplete(()=> {
                StartCoroutine(ScaleDown());
            });
        shapeNameText.gameObject.SetActive(true);
    }
    IEnumerator ScaleDown()
    {
        yield return new WaitForSeconds(1.5f);
        MissedSlotTextPanel.transform.DOScale(missedTextInitialScale, animationDuration);

    }
}
