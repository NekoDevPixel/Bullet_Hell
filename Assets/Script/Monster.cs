using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Monster Imformation")]
    public int maxHealth = 10;
    public float moveSpeed = 2f;             // 몬스터 이동 속도
    private int currentHealth;
    private Transform player;                // 플레이어 위치

    private SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red; // 피격시 색상
    private Color originalColor;
    public float hitFlashDuration = 0.1f;

    void Awake()
    {
        currentHealth = maxHealth;
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashColor());
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // 효과음, 파티클 등 추가 가능
        Destroy(gameObject);
    }

    private System.Collections.IEnumerator FlashColor()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.color = originalColor;
    }
}
