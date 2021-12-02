using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
using AudioManagement;
// **This script should not enable in the object by default**
public class Pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private ParticleSystem _gunflash;
    [SerializeField] private float _firerate = 5f;
    [SerializeField] private int _ammoSpentPerShot = 1;
    [SerializeField] private int _useAmmoType;

    private float _nextTimeToFire = 0f;
    private bool _isBulletOut;
    private bool _isReloading = false;


    public Camera fpsCam;
    private void OnEnable()
    {

        fpsCam = gameObject.GetComponentInParent<Camera>(); //Assign MainCamera
        if (_gunAnimator == null)
            _gunAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (ItemInventory.instance.itemIsActive)
        {
            Shoot();
            Reload();

        }

        void Shoot()
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= _nextTimeToFire && ItemInventory.instance.bagIsOpen != true && ItemInventory.instance.activeItem.name == "Pistol" && _isReloading != true)
            {
                if (AmmoManager.instance.ammoClipIsOut != true)
                {
                    AudioManager.instance.PlaySFX("PistolShot");
                    _nextTimeToFire = Time.time + 1f / _firerate;
                    RaycastHit hit;
                    _gunAnimator.Play("Fire");
                    _gunflash.Play();
                    AmmoManager.instance.FireAmmo(_ammoSpentPerShot);

                    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
                    {
                        Debug.Log(hit.transform.name);
                        Target target = hit.transform.GetComponent<Target>();

                        if (target != null)
                        {
                            target.TakeDamage(damage);
                        }
                    }
                }
                else
                {
                    BulletOut();
                }
            }
        }
    }
    void BulletOut()
    {
        AudioManager.instance.PlaySFX("BulletOut");
    }

    void Reload()
    {
        if (ItemInventory.instance.itemIsActive)
        {
            if (Input.GetKeyDown(KeyCode.R) && _isReloading != true)
            {
                AmmoManager.instance.AmmoReload(_useAmmoType);
                _isReloading = true;
                _gunAnimator.Play("Reload");
            }

        }
    }

    void ReadyToShoot()
    {
        _isReloading = false;
    }
}