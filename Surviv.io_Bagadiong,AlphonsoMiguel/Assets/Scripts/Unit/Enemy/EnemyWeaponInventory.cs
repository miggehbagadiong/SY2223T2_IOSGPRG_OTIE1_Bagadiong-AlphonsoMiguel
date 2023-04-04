using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponInventory : MonoBehaviour
{
    // Parameters
    [Header("Enemy Weapon Parameters")]
    [SerializeField] GameObject eWeaponHeld;
    [SerializeField] Transform eWeaponMuzzle;
    [SerializeField] SpriteRenderer eWGFX;
    [HideInInspector] public Weapon eCurrWeapon;
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

    public void AddEnemyWeapon(Weapon settedEnemyWeap)
    {
        this.eCurrWeapon = settedEnemyWeap;

        ShowEnemyGun(settedEnemyWeap);
    }

    public void ShowEnemyGun(Weapon weap)
    {
        eWGFX.sprite = weap.weaponSprite;
        eWeaponHeld.GetComponent<SpriteRenderer>().sprite = weap.weaponSprite;
    }

    Transform GetMuzzle()
    {
        return eWeaponMuzzle;
    }

#endregion

#region Enemy Functions

public void EnemyShoot()
{

    if (eCurrTimer >= eCurrWeapon.wFireRate)
    {
        eCurrWeapon.GunShooting(eWeaponMuzzle);
        eCurrTimer = 0;

         // automatically reload infinitely
        if (eCurrWeapon.wCurrAmmo <= 0)
        {
            Debug.Log(this.gameObject.ToString() + " reloading!");
            StartCoroutine(EnemyWeaponReload(5f, eCurrWeapon));
        }

    }

   
}

// infinite reloading time
private IEnumerator EnemyWeaponReload(float reloadTime, Weapon EnemyWeapon)
{
    
    yield return new WaitForSeconds(reloadTime);
    
    // should work where this will infinitely reload and referencee the currAmmo only to the magCap
    EnemyWeapon.wCurrAmmo = EnemyWeapon.wMagCap;
    Debug.Log("Current ammo: " + EnemyWeapon.wCurrAmmo);
}


#endregion


}
