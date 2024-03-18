using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchController : MonoBehaviour
{
    public GameObject clawScratchVFX;
    public AudioClip clawScratchSFX;
    public float delay = 0f;



    public IEnumerator PlayClawScratch()
    {
        Debug.Log("Coroutine started"); // Add debug log
        
        // Instantiate the visual effect prefab
        GameObject visualEffectInstance = Instantiate(clawScratchVFX, transform.position, Quaternion.identity);

        // Set the visual effect GameObject to active
        visualEffectInstance.SetActive(true);

        // Wait for a short duration
        yield return new WaitForSeconds(delay);

        
        // Play the sound effect
        AudioSource.PlayClipAtPoint(clawScratchSFX, transform.position);

        Debug.Log("Sound effect played"); // Add debug log

        // Wait for the duration of the sound effect to finish playing
        yield return new WaitForSeconds(clawScratchSFX.length);

        Debug.Log("Coroutine finished"); // Add debug log
        
        // Clean up the visual effect instance
        Destroy(visualEffectInstance);
    }
}