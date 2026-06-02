using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RoomMapper : MonoBehaviour
{
    [Header("AR Setup")]
    public ARRaycastManager raycastManager;
    public GameObject pointMarkerPrefab;
    public LineRenderer lineRenderer;
    
    [Header("Data Management")]
    public RoomAreaManager areaManager; // Calculates the m2

    private List<Vector3> roomVertices = new List<Vector3>();
    private bool isMeasurementFixed = false;

    void Start()
    {
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
            lineRenderer.loop = true; // For a thesis, the room must be a closed polygon
        }
    }

    void Update()
    {
        if (isMeasurementFixed) return;

        // Detects tap on the Infinix screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            
            // Using PlaneWithinBounds for more stable detection in varied environments
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinBounds))
            {
                Vector3 hitPoint = hits[0].pose.position;
                AddVertex(hitPoint);
            }
        }
    }

    void AddVertex(Vector3 point)
    {
        roomVertices.Add(point);
        Instantiate(pointMarkerPrefab, point, Quaternion.identity);
        
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = roomVertices.Count;
            lineRenderer.SetPositions(roomVertices.ToArray());
        }

        if (areaManager != null)
        {
            areaManager.AddCorner(point); // Updates the UI live
        }
    }

    // Thesis Requirement: A way to "Lock" the data before sending to Laravel/NeonDB
    public void FinalizeMeasurement()
    {
        isMeasurementFixed = true;
        Debug.Log("Measurement finalized. Ready to send to NeonDB.");
    }
}