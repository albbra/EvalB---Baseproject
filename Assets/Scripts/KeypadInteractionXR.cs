using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace NavKeypad
{
    public class KeypadInteractionXR : MonoBehaviour
    {
        private void Update()
        {
            if (UnityEngine.XR.InputDevices.GetDeviceAtXRNode(UnityEngine.XR.XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out bool buttonPressed) && buttonPressed)
            {
                TryPressButton();
            }
        }

        private void TryPressButton()
        {
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
                Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                    {
                        keypadButton.PressButton();
                    }
                }
            }
            else
            {
                Debug.LogWarning("Main camera not found in the scene.");
            }
        }
    }
}