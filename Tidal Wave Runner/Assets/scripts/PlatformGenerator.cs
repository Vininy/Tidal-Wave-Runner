using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public ObjectPooler[] obstaclePools; // Pools para os obstáculos
    public float randomObstacleThreshold; // Probabilidade de gerar obstáculos

    [Header("Obstacle Offset Settings")]
    public float obstacleYOffset = 0.5f; // Ajustável no editor para posicionar os obstáculos em relação à plataforma

    private bool lastPlatformHadObstacle = false; // Flag para rastrear se o último obstáculo foi gerado

    void Start()
    {
        platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

void Update()
{
    if (transform.position.x < generationPoint.position.x)
    {
        distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

        // Seleciona qualquer plataforma disponível
        platformSelector = Random.Range(0, theObjectPools.Length);

        heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

        if (heightChange > maxHeight)
        {
            heightChange = maxHeight;
        }
        else if (heightChange < minHeight)
        {
            heightChange = minHeight;
        }

        transform.position = new Vector3(
            transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween,
            heightChange,
            transform.position.z
        );

        GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

        newPlatform.transform.position = transform.position;
        newPlatform.transform.rotation = transform.rotation;
        newPlatform.SetActive(true);

        // Geração de moedas
        if (Random.Range(0f, 100f) < randomCoinThreshold)
        {
            theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
        }
        // Geração de obstáculos apenas em plataformas 7x1 e 9x1
        else if (Random.Range(0f, 100f) < randomObstacleThreshold && IsValidPlatform(platformSelector) && !lastPlatformHadObstacle)
        {
            SpawnObstacle(newPlatform.transform.position);
            lastPlatformHadObstacle = true; // Marca que houve obstáculo nesta plataforma
        }
        else
        {
            lastPlatformHadObstacle = false; // Reseta flag se não houver obstáculo
        }

        transform.position = new Vector3(
            transform.position.x + (platformWidths[platformSelector] / 2),
            transform.position.y,
            transform.position.z
        );
    }
}


    private bool IsValidPlatform(int selector)
    {
        // Supondo que os índices 0 e 1 correspondam às plataformas 7x1 e 9x1
        return selector == 0 || selector == 1;
    }

    private int SelectValidPlatform()
    {
        // Seleciona uma plataforma válida aleatoriamente (7x1 ou 9x1)
        int[] validPlatforms = { 0, 1 }; // Índices das plataformas válidas
        return validPlatforms[Random.Range(0, validPlatforms.Length)];
    }

    private void SpawnObstacle(Vector3 platformPosition)
    {
        // Escolhe aleatoriamente um dos pools de obstáculos
        int obstacleIndex = Random.Range(0, obstaclePools.Length);
        GameObject obstacle = obstaclePools[obstacleIndex].GetPooledObject();

        if (obstacle != null)
        {
            // Obtém o Collider do obstáculo
            BoxCollider2D obstacleCollider = obstacle.GetComponent<BoxCollider2D>();
            float obstacleHeight = obstacleCollider != null ? obstacleCollider.bounds.extents.y : 0f;

            // Obtém o Collider da plataforma
            BoxCollider2D platformCollider = theObjectPools[platformSelector].pooledObject.GetComponent<BoxCollider2D>();
            float platformHeight = platformCollider != null ? platformCollider.bounds.extents.y : 0f;

            // Ajusta a posição final com offset configurável
            float yPosition = platformPosition.y + platformHeight + obstacleHeight + obstacleYOffset;

            // Define a posição e ativa o obstáculo
            obstacle.transform.position = new Vector3(platformPosition.x, yPosition, platformPosition.z);
            obstacle.transform.rotation = Quaternion.identity;
            obstacle.SetActive(true);
        }
    }
}
