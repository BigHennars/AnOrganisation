using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestTrigger : MonoBehaviour
{
    public AudioClip pickupSound;         // Drag in the key sound

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void GameOver(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play sound
            if (pickupSound != null)
                audioSource.PlayOneShot(pickupSound);

            // disable collider so it can't be collected again
            GetComponent<Collider2D>().enabled = false;

            // disable sprite after animation ends
            Invoke(nameof(HideChest), 0.5f);

            // loads the next scene
            SceneManager.LoadSceneAsync(2);
        }
    }

    void HideChest()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
