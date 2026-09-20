using UnityEngine;
using UnityEngine.XR;

public class VRMenuToggle : MonoBehaviour
{
    [Header("NovaCore Menu")]
    public GameObject menuPanel;

    [Header("VR Head / Camera")]
    public Transform head;

    [Header("Menu Distance")]
    public float distanceFromFace = 0.127f; // 5 inches

    private InputDevice leftController;
    private bool lastPrimaryButtonState;

    private void Start()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }

        FindLeftController();
    }

    private void Update()
    {
        if (!leftController.isValid)
        {
            FindLeftController();
        }

        if (!leftController.isValid || menuPanel == null || head == null)
        {
            return;
        }

        bool primaryPressed = false;

        leftController.TryGetFeatureValue(
            CommonUsages.primaryButton,
            out primaryPressed
        );

        // Open/close only when the button is newly pressed.
        if (primaryPressed && !lastPrimaryButtonState)
        {
            ToggleMenu();
        }

        lastPrimaryButtonState = primaryPressed;

        // Keep NovaCore 5 inches in front of the player's face.
        if (menuPanel.activeSelf)
        {
            UpdateMenuPosition();
        }
    }

    private void FindLeftController()
    {
        leftController = InputDevices.GetDeviceAtXRNode(
            XRNode.LeftHand
        );
    }

    private void ToggleMenu()
    {
        bool newState = !menuPanel.activeSelf;

        menuPanel.SetActive(newState);

        if (newState)
        {
            UpdateMenuPosition();
        }
    }

    private void UpdateMenuPosition()
    {
        // 5 inches = 0.127 meters.
        Vector3 targetPosition =
            head.position +
            head.forward * distanceFromFace;

        menuPanel.transform.position = targetPosition;

        // Make the front of the menu face the player.
        Vector3 directionToHead =
            head.position -
            menuPanel.transform.position;

        if (directionToHead.sqrMagnitude > 0.0001f)
        {
            menuPanel.transform.rotation =
                Quaternion.LookRotation(
                    -directionToHead.normalized,
                    head.up
                );
        }
    }
}
