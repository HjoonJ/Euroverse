using UnityEngine;

public class EuromausTalkTrigger : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject pointerObject;
    [SerializeField] private GameObject bubbleCanvas;
    [SerializeField] private Animator animator;
    [SerializeField] private Portal_Controller portalController;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dialogueClip;

    private bool hasTriggered = false;

    private void Start()
    {
        if (bubbleCanvas != null)
            bubbleCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;

            if (pointerObject != null)
                pointerObject.SetActive(false);

            if (bubbleCanvas != null)
                bubbleCanvas.SetActive(true);

            if (audioSource != null && dialogueClip != null)
            {
                audioSource.clip = dialogueClip;
                audioSource.Play();
            }

            if (animator != null)
            {
                animator.SetTrigger("StartTalk");
            }
            if (portalController != null)
            {
                portalController.TogglePortal(true);
            }
        }
    }
}