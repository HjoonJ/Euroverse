using UnityEngine;
using Meta.XR.MRUtilityKit;

public class QRCodeEventManager : MonoBehaviour
{
    [Header("Event Objects")]
    public GameObject zombieEventObject;
    public GameObject fireworkEventObject;

    private bool zombieStarted = false;
    private bool fireworkStarted = false;

    private void Start()
    {
        if (zombieEventObject != null)
            zombieEventObject.SetActive(false);

        if (fireworkEventObject != null)
            fireworkEventObject.SetActive(false);

        MRUK.Instance.SceneSettings.TrackableAdded.AddListener(OnQRCodeTracked);
    }

    private void OnDestroy()
    {
        if (MRUK.Instance != null && MRUK.Instance.SceneSettings != null)
        {
            MRUK.Instance.SceneSettings.TrackableAdded.RemoveListener(OnQRCodeTracked);
        }
    }

    public void OnQRCodeTracked(MRUKTrackable qrCode)
    {
        if (qrCode.TrackableType != OVRAnchor.TrackableType.QRCode)
            return;

        string payload = qrCode.MarkerPayloadString;

        Debug.Log("QR Detected: " + payload);

        if (payload == "ZOMBIE_EVENT" && !zombieStarted)
        {
            zombieStarted = true;

            if (zombieEventObject != null)
                zombieEventObject.SetActive(true);
        }
        else if (payload == "FIREWORK_EVENT" && !fireworkStarted)
        {
            fireworkStarted = true;

            if (fireworkEventObject != null)
                fireworkEventObject.SetActive(true);
        }
    }
}