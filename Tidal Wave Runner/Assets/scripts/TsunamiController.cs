using UnityEngine;

public class TsunamiController : MonoBehaviour
{
    public PlayerController player; // Referência ao jogador
    public float speedIncreaseFactor = 0.1f; // Fator de aceleração do tsunami
    private float tsunamiSpeed;
    private Vector3 initialPosition; // Posição inicial do tsunami

    void Start()
    {
        // Garantir referência ao jogador automaticamente, se não estiver configurado
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }

        // Salvar a posição inicial do tsunami
        initialPosition = transform.position;

        // Sincronizar a velocidade inicial do tsunami
        tsunamiSpeed = player.moveSpeed;
    }

    void FixedUpdate() // Use FixedUpdate para sincronizar com a física do jogador
    {
        // Atualizar a posição do tsunami ao longo do eixo X
        transform.position = new Vector3(
            transform.position.x + tsunamiSpeed * Time.fixedDeltaTime,
            initialPosition.y, // Mantém a posição Y inicial
            transform.position.z
        );

        // Aumentar gradualmente a velocidade do tsunami
        tsunamiSpeed = Mathf.Lerp(tsunamiSpeed, player.moveSpeed, speedIncreaseFactor * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detectar colisão com o jogador
        if (other.CompareTag("Player"))
        {
            // Chamar o método de reinício do jogo
            player.theGameManager.RestartGame();
        }
    }

    // Método para resetar a posição do tsunami ao começar um novo jogo ou sair do pause
    public void ResetTsunami()
    {
        transform.position = initialPosition; // Reseta para a posição inicial
        tsunamiSpeed = player.moveSpeed; // Reseta a velocidade inicial
    }
}
