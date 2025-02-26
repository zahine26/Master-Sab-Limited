using UnityEngine;

public class LineRendererWaterFlow : MonoBehaviour
{
    public Transform startTransform; // Reference for the start position
    public Transform endTransform;   // Reference for the end position
    public float scrollSpeed = 1f;   // Speed of texture scrolling

    private LineRenderer lineRenderer;
    private Vector2 textureOffset;

    void Start()
    {
        // Get or add a LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Set basic LineRenderer properties
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;

        // Apply initial positions
        UpdateLinePositions();

        // Set texture tiling based on line length
        float lineLength = Vector3.Distance(startTransform.position, endTransform.position);
        lineRenderer.material.mainTextureScale = new Vector2(1, lineLength);
    }

    void Update()
    {
        // Update the line dynamically
        UpdateLinePositions();

        // Scroll the texture to simulate water flow
        textureOffset.y -= scrollSpeed * Time.deltaTime; // Moves downward
        lineRenderer.material.mainTextureOffset = textureOffset;
    }

    void UpdateLinePositions()
    {
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position);
            lineRenderer.SetPosition(1, endTransform.position);
        }
    }
}
