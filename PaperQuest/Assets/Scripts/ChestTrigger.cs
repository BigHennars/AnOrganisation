using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestTrigger : MonoBehaviour
{
    public string nextSceneName;        // Name of the scene to load
    public AudioClip pickupSound;       // Sound played on pickup

    private bool hasTriggered = false;  // Prevents multiple triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered) return;

        if (collision.CompareTag("Player"))
        {
            hasTriggered = true;

            // Play sound at key position
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            // Hide the key immediately
            gameObject.SetActive(false);

            // Load the specified scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}