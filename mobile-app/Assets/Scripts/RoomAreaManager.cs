using UnityEngine;
using TMPro; // Required for Unity 6 UI
using System.Collections.Generic;

public class RoomAreaManager : MonoBehaviour
{
    [Tooltip("Drag your AreaText UI element here")]
    [SerializeField] private TextMeshProUGUI areaTextDisplay;
    
    // Stores the positions of the corners you tap
    private List<Vector3> roomCorners = new List<Vector3>();

    // Call this method whenever you spawn a new blue sphere
    public void AddCorner(Vector3 newCornerPosition)
    {
        roomCorners.Add(newCornerPosition);
        UpdateAreaDisplay();
    }

    private void UpdateAreaDisplay()
    {
        // Need at least a triangle (3 points) to calculate an area
        if (roomCorners.Count < 3)
        {
            areaTextDisplay.text = $"Mapping... ({roomCorners.Count} points)";
            return;
        }

        float area = 0f;
        int n = roomCorners.Count;

        // The Shoelace Formula: Calculates flat floor area using X and Z coordinates
        for (int i = 0; i < n; i++)
        {
            Vector3 p1 = roomCorners[i];
            Vector3 p2 = roomCorners[(i + 1) % n]; // Wraps back to the first point

            area += (p1.x * p2.z) - (p2.x * p1.z);
        }

        // Convert to absolute positive number and halve it
        float finalArea = Mathf.Abs(area) / 2f;

        // F2 formats the number to 2 decimal places (e.g., 12.45 m²)
        areaTextDisplay.text = $"Total Area: {finalArea:F2} m²";
    }
}