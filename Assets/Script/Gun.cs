using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [Header("Bullet Position")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Camera mainCamera;
    public int magazine = 6;
    private int load_magazine;

    void Awake()
    {
        mainCamera = Camera.main;
        load_magazine = magazine;
    }

    private void Shoot()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0f;
        Vector2 direction = (mousePos - transform.position).normalized;
        

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 총알 회전: 총알이 오른쪽(→)을 바라보는 프리팹일 경우, angle 그대로 적용
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
    }

    void OnFire(InputValue value)
    {
        Fire();
    }
    void OnReload(InputValue value){
        Reload();
    }

    public void Reload()
    {
        if (magazine == 0)
        {
            
            magazine = load_magazine;
            Debug.Log("Loaded complete");
        }
    }
    public void Fire(){
        if (magazine != 0){
            Shoot(); // Gun 스크립트에게 발사 요청
            magazine--;
        }
        if (magazine == 0){
            Debug.Log("Press the R key to load it");
        }
    }

}
