using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    public TextMeshProUGUI AmmoLeft;
    public TextMeshProUGUI MaxAmmo;
    private int MaxBullet = 0;
    private int currentAmmo = 0;

    void Awake()
    {
        MaxBullet = GameObject.Find("Player").GetComponent<Gun>().magazine;
        AmmoLeft.text = MaxBullet.ToString();
        MaxAmmo.text = MaxBullet.ToString();
    }

    void Update()
    {
        useGun();
    }

    void useGun(){
        currentAmmo = GameObject.Find("Player").GetComponent<Gun>().magazine;
        AmmoLeft.text = currentAmmo.ToString();
    }

}
