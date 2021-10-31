using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewController : MonoBehaviour
{
    [SerializeField]
    private float mouseSpeed = 150f;
    [SerializeField]
    private Transform playerBody;

    private float _xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerViewControl();
    }

    void PlayerViewControl()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        _xRotation = _xRotation - MouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * MouseX);
    }


}
