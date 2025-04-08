using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovei : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 moveInput;
    private Camera mainCamera;
    
    void Awake()
    {
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
}
