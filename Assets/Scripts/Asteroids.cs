using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    //if player collides with asteroid then the player dies.
    //asteroids should rotate, Some slower, some faster
    //asteroids should move, Some slower, some faster, in random directions

    float _randomRotateSpeed = 5;
    float _randomX;
    float _randomY;
    float _zAxis;
    Vector3 _randomVector3;

    void Start()
    {
        CalculateRandomValues();
    }

    void Update()
    {
        HandleRandomRotations();
    }

    void CalculateRandomValues()
    {
        _randomX = Random.Range(-1, 2);
        _randomY = Random.Range(-1, 2);
        _zAxis = 1;

        _randomRotateSpeed = Random.Range(10, 31);

        _randomVector3 = new Vector3(_randomX, _randomY, _zAxis);
    }

    void HandleRandomRotations()
    {
        transform.Rotate(_randomVector3 * _randomRotateSpeed * Time.deltaTime);
    }
}
