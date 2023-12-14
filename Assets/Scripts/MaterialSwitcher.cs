using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material[] materials;
    private Renderer myRenderer;
    private int currentIndex = 0;
    private float timeElapsed = 0f;
    public float switchInterval = 3f;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();

        // Ensure that the object has a Mesh Renderer and at least one material
        if (myRenderer == null || materials.Length == 0)
        {
            Debug.LogError("Missing Renderer or Materials. Please check the setup.");
            enabled = false; // Disable the script to prevent errors
            return;
        }

        // Set the initial material
        myRenderer.material = materials[currentIndex];
    }

    void Update()
    {
        // Increment timeElapsed
        timeElapsed += Time.deltaTime;

        // Switch materials every switchInterval seconds
        if (timeElapsed >= switchInterval)
        {
            // Reset timeElapsed
            timeElapsed = 0f;

            // Increment the index and loop back to the first material if necessary
            currentIndex = (currentIndex + 1) % materials.Length;

            // Apply the new material
            myRenderer.material = materials[currentIndex];
        }
    }
}
