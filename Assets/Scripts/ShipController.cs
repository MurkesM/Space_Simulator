using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] Transform _thisShip;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _turnSpeed = 60f;
    [SerializeField] float _boostSpeed = 45f;

    void FixedUpdate()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = _turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        float roll = _turnSpeed * Time.deltaTime * Input.GetAxis("Rotate");
        _thisShip.Rotate(pitch, yaw, roll);
    }

    void Thrust()
    {
        Debug.Log("Test");
    }
}
