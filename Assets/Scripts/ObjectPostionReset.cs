using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
public class ObjectPostionReset : MonoBehaviour
{
    public TextMeshProUGUI MissedSlotText;
    private async void OnTriggerEnter(Collider other)
    {
        UIManger.Instance.DisplaySlotMissedMessage();
        AudioManager.instance.MissedSlotAudio();
        await HideMessage();
        other.gameObject.GetComponent<ObjectMover>()?.ResetObjectTransform();
    }

    private async Task HideMessage()
    {
        await Task.Delay(2000);
    }
}
