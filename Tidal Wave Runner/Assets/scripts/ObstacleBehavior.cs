using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float speedReduction; // Redução na velocidade do jogador

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Acessa o PlayerController do jogador
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                // Reduz a velocidade do jogador
                player.moveSpeed -= speedReduction;
                if (player.moveSpeed < 0)
                {
                    player.moveSpeed = 0; // Garante que a velocidade não fique negativa
                }

                // Ativa a animação de colisão
                Animator playerAnimator = player.GetComponent<Animator>();
                if (playerAnimator != null)
                {
                    playerAnimator.SetTrigger("Collided"); // Define o trigger da animação
                }
            }

            // Toca o som de colisão usando o AudioManager
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayCollisionSound();
            }

            // Desativa o obstáculo
            gameObject.SetActive(false);
        }
    }
}
