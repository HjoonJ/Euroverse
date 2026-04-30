using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSceneTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Scene2";
    [SerializeField] private bool useFade = true;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggered) return;

        if (other.CompareTag("Player"))
        {
            isTriggered = true;

            SceneManager.LoadScene(nextSceneName);
        }
    }
}
