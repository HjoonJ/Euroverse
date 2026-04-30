using UnityEngine;
using Meta.XR.MRUtilityKit;
public class QRCodeManager : MonoBehaviour
{

    public GameObject objectToSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MRUK.Instance.SceneSettings.TrackableAdded.AddListener(OnQRCodeTracked);
    }

    public void OnQRCodeTracked(MRUKTrackable qrCode)
    {
        if (qrCode.TrackableType != OVRAnchor.TrackableType.QRCode)
            return;
        
        Vector3 targetPosition = qrCode.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(-qrCode.transform.forward, qrCode.transform.up);

        GameObject spawned = Instantiate(objectToSpawn, targetPosition, targetRotation);
    }
}
