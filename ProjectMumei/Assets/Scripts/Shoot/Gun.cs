using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
// **This script should not enable in the object by default**
public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private ParticleSystem _gunflash;
    [SerializeField] private float _firerate = 5f;
    [SerializeField] private float _nextTimeToFire = 0f;


    public Camera fpsCam;
    private void OnEnable()
    {

        fpsCam = gameObject.GetComponentInParent<Camera>(); //Assign MainCamera
        if (_gunAnimator == null)
            _gunAnimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (ItemInventory.instance.itemIsActive)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= _nextTimeToFire && ItemInventory.instance.bagIsOpen != true && ItemInventory.instance.activeItem.name == "Pistol")
            {
                _nextTimeToFire = Time.time + 1f / _firerate;
                RaycastHit hit;
                _gunAnimator.Play("Fire");
                _gunflash.Play();

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
        }
    }
}
