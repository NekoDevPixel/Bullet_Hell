using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;    // 생성할 몬스터 프리팹
    public Transform playerTransform;   // 플레이어 위치
    public float spawnRadius = 10f;     // 플레이어로부터의 거리
    public float spawnInterval = 3f;    // 몇 초마다 스폰할지

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMonsterNearPlayer();
            timer = 0f;
        }
    }

    void SpawnMonsterNearPlayer()
    {
        if (playerTransform == null) return;

        // 랜덤 방향으로 위치 결정
        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPosition = playerTransform.position + (Vector3)(spawnDirection * spawnRadius);
        spawnPosition.z = 0f; // 2D니까 z는 고정

        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
