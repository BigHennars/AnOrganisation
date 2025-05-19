using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public AudioClip pickupSound;         // Drag in the key sound
    public GameObject doorToOpen;         // Drag the door here

    private AudioSource audioSource;
    private Animator keyAnimator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        keyAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play animation
            if (keyAnimator != null)
                keyAnimator.SetTrigger("Collect");

            // Play sound
            if (pickupSound != null)
                audioSource.PlayOneShot(pickupSound);

            // Open the door
            Animator doorAnim = doorToOpen.GetComponent<Animator>();
            if (doorAnim != null)
                doorAnim.SetTrigger("Open");  

            // disable collider so it can't be collected again
            GetComponent<Collider2D>().enabled = false;

            // disable sprite after animation ends
            Invoke(nameof(HideKey), 0.5f);
        }
    }

    void HideKey()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}