using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
public XRNode controllerNode = XRNode.RightHand;

    // Threshold for detecting quick horizontal movement (adjust based on needs)
    public float horizontalSpeedThreshold = 1.5f; // Adjust this value for sensitivity

    private Vector3 controllerVelocity;

    void Update()
    {
        // Get the controller's velocity from the device
        InputDevice device = InputDevices.GetDeviceAtXRNode(controllerNode);
        if (device.TryGetFeatureValue(CommonUsages.deviceVelocity, out controllerVelocity))
        {
            DetectHorizontalMovement(controllerVelocity);
        }
    }

    private void DetectHorizontalMovement(Vector3 velocity)
    {
        // Calculate horizontal speed (XZ components)
        float horizontalSpeed = new Vector2(velocity.x, velocity.z).magnitude;

        // Check if horizontal speed exceeds the threshold
        if (horizontalSpeed > horizontalSpeedThreshold)
        {
            Debug.Log("Quick horizontal movement detected!");
            // Add actions for quick horizontal movement here
        }
    }
}
