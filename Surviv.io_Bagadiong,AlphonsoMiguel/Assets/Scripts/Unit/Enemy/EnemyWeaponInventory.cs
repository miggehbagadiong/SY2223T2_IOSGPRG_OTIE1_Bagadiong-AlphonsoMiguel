using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponInventory : MonoBehaviour
{
    // Parameters
    [Header("Enemy Weapon Parameters")]
    [SerializeField] GameObject eWeaponHeld;
    [SerializeField] Transform eWeaponMuzzle;
    [SerializeField, HideInInspector] SpriteRenderer eWGFX;
    [HideInInspector] Weapon eCurrWeapon;
    [SerializeField] Animator eAnimator;
    private float eCurrTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        eAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        eCurrTimer += 1 * Time.deltaTime;

        if (eAnimator.GetBool("isAttacking") == true)
        {
            EnemyShoot();
        }
    }

#region Initialize Parameters

    public void InitializeEnemyCurrentWeapon(Weapon settedCurrWeap)
    {
        eCurrWeapon = settedCurrWeap;
        ShowEnemyGun(settedCurrWeap);
    }

    public void ShowEnemyGun(Weapon currWeap)
    {
        eWGFX.sprite = currWeap.weaponSprite;
    }

    Transform GetMuzzle()
    {
        return eWeaponMuzzle;
    }

#endregion

#region Enemy Functions

public void EnemyShoot()
{
    eCurrWeapon.GunShooting(eWeaponMuzzle);

    // automatically reload infinitely
    if (eCurrWeapon.wCurrAmmo <= 0)
    {
        StartCoroutine(EnemyWeaponReload(2f, eCurrWeapon));
    }
}

// infinite reloading time
private IEnumerator EnemyWeaponReload(float reloadTime, Weapon EnemyWeapon)
{
    yield return new WaitForSeconds(reloadTime);
    EnemyWeapon.wCurrAmmo += EnemyWeapon.wMagCap;
}


#endregion


}
