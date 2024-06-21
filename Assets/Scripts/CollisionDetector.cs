using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] GameObject particleEffect;
    
    private void OnTriggerEnter(Collider other)
    {   
        SpawnManager.instance.SpawnObject();
        GameObject particleEffectVFX = Instantiate(particleEffect, other.gameObject.transform.position, Quaternion.identity);
        AudioManager.instance.RightSlotAudio();
        
        // Stop the particle effect
        Destroy(particleEffectVFX, 1f);
        Destroy(other.gameObject);
    }
}
