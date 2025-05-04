using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler[] coinPools; // Array com diferentes tipos de moedas
    public float distanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        // Número aleatório de moedas a serem geradas (de 0 a 3)
        int numberOfCoins = Random.Range(0, 4);

        // Gera as moedas com base no número sorteado
        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = GetRandomCoin();
            if (coin != null)
            {
                // Define a posição para cada moeda com espaçamento
                float offset = distanceBetweenCoins * (i - 1); // Posições ajustadas em torno de startPosition.x
                coin.transform.position = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
                coin.SetActive(true);
            }
        }
    }

    // Função para obter uma moeda de um pool aleatório
    private GameObject GetRandomCoin()
    {
        int randomIndex = Random.Range(0, coinPools.Length); // Seleciona aleatoriamente um pool
        return coinPools[randomIndex].GetPooledObject();
    }
}
