using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform cameraTransform; // Referência à câmera
    private Vector3 initialPosition;  // Posição inicial do fundo em relação à câmera

    void Start()
    {
        // Salva a posição inicial do fundo
        initialPosition = transform.position - cameraTransform.position;
    }

    void Update()
    {
        // Atualiza a posição do fundo para seguir a câmera
        transform.position = cameraTransform.position + initialPosition;
    }

    // Reseta o fundo ao reiniciar o jogo
    public void ResetPosition()
    {
        transform.position = initialPosition + cameraTransform.position;
    }
}
