using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private Vector2 direction;

    private void Start()
    {
        // transform.right은 현재 회전된 방향의 오른쪽 (즉, 총알이 실제 바라보는 방향)
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * speed;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // 화면 밖으로 나가면 제거
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
            }

            Destroy(gameObject); // 총알은 맞고 사라짐
        }
    }
}
