using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Gun : MonoBehaviour
{
    [Header("Bullet Position")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    private Camera mainCamera;
    public int magazine = 6;
    private int load_magazine;
    public float reloadTime = 0.5f; // 장전 시간 (초)
    private bool isReloading = false;
    [Header("Gun sound")]
    public AudioClip gunShotSound;// 🔊 쏠 때 사운드
    public AudioClip gunReloadSound;  
    public AudioClip gunNobulletSound;           
    private AudioSource audioSource;

    void Awake()
    {
        mainCamera = Camera.main;
        load_magazine = magazine;

        audioSource = GetComponent<AudioSource>();
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

        if (gunShotSound != null)
        {
            audioSource.PlayOneShot(gunShotSound);
        }
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
        if (magazine < load_magazine  && !isReloading)
        {
            if (gunReloadSound != null)
            {
                audioSource.PlayOneShot(gunReloadSound);
            }
            StartCoroutine(ReloadCoroutine());
        }
    }
    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime); // 딜레이

        magazine = load_magazine;
        isReloading = false;
        Debug.Log("Reload complete!");
    }
    public void Fire(){
        if (isReloading) return;

        if (magazine != 0){
            Shoot(); // Gun 스크립트에게 발사 요청
            magazine--;
        }
        if (magazine == 0){
            if (gunNobulletSound != null)
            {
                audioSource.PlayOneShot(gunNobulletSound);
            }
            Debug.Log("Press the R key to load it");
        }
    }

}
