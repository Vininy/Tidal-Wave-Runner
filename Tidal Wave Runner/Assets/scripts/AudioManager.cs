using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource gameMusic;         // Música do jogo
    public AudioSource pauseSound;        // Som de pausa
    public AudioSource deathSound;        // Som de morte
    public AudioSource collisionSound;    // Som de colisão com obstáculos

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garante que o AudioManager persista entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGameMusic()
    {
        if (gameMusic != null && !gameMusic.isPlaying)
        {
            gameMusic.Play();
        }
    }

    public void StopGameMusic()
    {
        if (gameMusic != null && gameMusic.isPlaying)
        {
            gameMusic.Stop();
        }
    }

    public void PlayPauseSound()
    {
        if (pauseSound != null && !pauseSound.isPlaying)
        {
            pauseSound.Play();
        }
    }

    public void StopPauseSound()
    {
        if (pauseSound != null && pauseSound.isPlaying)
        {
            pauseSound.Stop();
        }
    }

    public void PlayDeathSound()
    {
        if (deathSound != null && !deathSound.isPlaying)
        {
            deathSound.Play();
        }
    }

    public void StopDeathSound()
    {
        if (deathSound != null && deathSound.isPlaying)
        {
            deathSound.Stop(); // Para o som sem destruir o AudioSource
        }
    }

    public void PlayCollisionSound()
    {
        if (collisionSound != null && !collisionSound.isPlaying)
        {
            collisionSound.Play();
        }
    }

    public void StopCollisionSound()
    {
        if (collisionSound != null && collisionSound.isPlaying)
        {
            collisionSound.Stop();
        }
    }
}
