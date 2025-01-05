using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_Scroll___MK1 : MonoBehaviour
{
    /// <summary>
    /// Local Variables And components 
    /// </summary>


    [Header("Background Settings")]
    [SerializeField] float _theScrollSpeed = 1f; // Speed of the texture scroll
    [SerializeField] float _theResetTime = 15f; // Time in seconds after which the texture offset resets
    [SerializeField] Renderer _theBackgroundRenderer; // Reference to the renderer of the background material
    private Vector2 _theStartOffset; // Initial offset of the texture


    /// <summary>
    /// Class Functions
    /// </summary>


    private IEnumerator ResetOffsetCoroutine()
    {
        // Coroutine to reset the texture offset after a specified time
        yield return new WaitForSeconds(_theResetTime);
        ResetTextureOffset();
    }

    private void ScrollTexture()
    {
        // Scroll the texture by modifying its offset
        float newOffsetX = Time.time * _theScrollSpeed; // Calculate new X offset
        Vector2 newOffset = new Vector2(newOffsetX, _theStartOffset.y); // Keep Y offset constant
        _theBackgroundRenderer.material.mainTextureOffset = newOffset; // Apply new offset to the material
    }

    private void ResetTextureOffset()
    {
        // Resets the texture offset to the initial value
        _theBackgroundRenderer.material.mainTextureOffset = _theStartOffset;
    }
    /// <summary>
    /// MonoBehaviour Functions 
    /// </summary>
    /// 



    // Set up background and start the Parallax Function Coroutine for TEXTURE RESET
    void Start()  
    {
        if (_theBackgroundRenderer == null)
        {
            Debug.LogError("Background Renderer is not assigned!");
            return;
        }

        // Store the initial texture offset
        _theStartOffset = _theBackgroundRenderer.material.mainTextureOffset;

        // Start the coroutine to reset the texture offset
        StartCoroutine(ResetOffsetCoroutine());
    }

    void Update()
    {
        ScrollTexture();         // Continuously scroll the texture, With a Coroutine to reset it 
    }
}

