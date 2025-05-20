using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicController : MonoBehaviour
{
    public string musicSceneName = "MainScene"; // Scene where music should play
    public AudioClip sceneBackgroundMusic;

    private AudioSource sceneMusicSource;
    private static SceneMusicController musicController;

    void Awake()
    {
        if (musicController != null && musicController != this)
        {
            Destroy(gameObject);
            return;
        }

        musicController = this;
        DontDestroyOnLoad(gameObject);

        sceneMusicSource = gameObject.AddComponent<AudioSource>();
        sceneMusicSource.clip = sceneBackgroundMusic;
        sceneMusicSource.loop = true;

        SceneManager.sceneLoaded += HandleSceneChange;
    }

    private void HandleSceneChange(Scene loadedScene, LoadSceneMode mode)
    {
        if (loadedScene.name == musicSceneName)
        {
            if (!sceneMusicSource.isPlaying)
            {
                sceneMusicSource.Play();
            }
        }
        else
        {
            if (sceneMusicSource.isPlaying)
            {
                sceneMusicSource.Stop();
            }
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= HandleSceneChange;
    }
}