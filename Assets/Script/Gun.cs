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

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
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
