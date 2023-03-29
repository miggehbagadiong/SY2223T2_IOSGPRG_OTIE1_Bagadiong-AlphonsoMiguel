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
    [SerializeField] Weapon eCurrWeapon;
    [SerializeField] Animator eAnimator;


    // Start is called before the first frame update
    void Start()
    {
        eAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    
}


#endregion


}
