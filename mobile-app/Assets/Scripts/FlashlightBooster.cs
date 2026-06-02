using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems; // Required for 'Feature' in Unity 6

public class FlashlightBooster : MonoBehaviour
{
    public ARCameraManager cameraManager;
    
    // 0.2 is quite dark, 1.0 is very bright
    [SerializeField] private float darknessThreshold = 0.2f; 
    private bool isTorchOn = false;

    // Fixed for Unity 6: Added safety check for cameraManager
    void OnEnable() 
    {
        if (cameraManager != null)
            cameraManager.frameReceived += OnCameraFrameReceived;
    }

    void OnDisable() 
    {
        if (cameraManager != null)
            cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        // FIX 1: Capitalized 'HasValue' for Unity 6
        if (eventArgs.lightEstimation.averageBrightness.HasValue)
        {
            float brightness = eventArgs.lightEstimation.averageBrightness.Value;

            if (brightness < darknessThreshold && !isTorchOn)
            {
                SetTorch(true);
            }
            else if (brightness > (darknessThreshold + 0.2f) && isTorchOn)
            {
                SetTorch(false);
            }
        }
    }

    private void SetTorch(bool enabled)
    {
        if (cameraManager != null && cameraManager.subsystem != null)
        {
            // Unity 6 uses .On and .Off
            cameraManager.subsystem.requestedCameraTorchMode = enabled ? XRCameraTorchMode.On : XRCameraTorchMode.Off;
            isTorchOn = enabled;
            Debug.Log("Smart Flashlight is now: " + (enabled ? "ON" : "OFF"));
        }
    }
}