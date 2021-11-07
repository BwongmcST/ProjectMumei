using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private Transform _equipmentPos;
    [SerializeField] private GameObject _equipmentPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        if (_equipmentPrefabs != null)
        {
            Instantiate(_equipmentPrefabs, _equipmentPos);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
