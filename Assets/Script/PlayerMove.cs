using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("IFM")]
    public int maxHealth = 100;
    private int currentHealth = 0;
    private float damageCooldown = 1f;
    private float lastDamageTime = 0f;
    [Header("Player Moving")]
    public float speed = 5f;
    private Vector2 moveInput;
    public Camera mainCamera;
    
    void Awake()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed;
        LookAtMouse();
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
    }

    
    //마우스가 있는 방향으로 플레이어으 시선
    private void LookAtMouse()
    {
        Vector3 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0f; // 2D이기 때문에 z 고정

        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 회전 (z축 기준)
        rb.rotation = angle -90f;;
    }
    

    //플레이어 피격시 데미지 피해해
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
    {
        if (Time.time - lastDamageTime > damageCooldown)
        {
            Monster monsterScript = collision.gameObject.GetComponent<Monster>();
            if (monsterScript != null)
            {
                TakeDamage(monsterScript.Mdamage);
                lastDamageTime = Time.time;
            }
        }
    }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("플레이어가 데미지를 입었습니다! 현재 체력: " + currentHealth);

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver(){
        Time.timeScale = 0f;
    }
}
