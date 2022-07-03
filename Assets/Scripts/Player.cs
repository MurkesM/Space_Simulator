using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cam3rdPerson;
    [SerializeField] GameObject _directorIdle;
    [SerializeField] float _timeToIdle = 5;

    [SerializeField] private float _rotSpeed = 5;
    [SerializeField] private float _currentSpeed = 5;
    [SerializeField] bool _canMove;
    private float _vertical;
    private float _horizontal;

    [SerializeField] ParticleSystem _leftFire;
    [SerializeField] ParticleSystem _rightFire;
   //[SerializeField] AudioSource _audioSource;
   //[SerializeField] AudioClip _engineThusters;

    void Update()
    {
        if (_canMove == true)
        {
            HandleMovement();
            SwitchCams();
            HandleIdleState();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bounds")
        {
            _timeToIdle = 0;
            Debug.Log("Player has entered the playable area!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bounds")
        {
            Debug.Log("Player out of bounds!");
        }
    }

    void SwitchCams()
    {
        if (Input.GetKeyDown(KeyCode.R) && _cam3rdPerson.enabled == true)
        {
            _cam3rdPerson.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) && _cam3rdPerson.enabled == false)
        {
            _cam3rdPerson.enabled = true;
        }
    }

    void HandleIdleState()
    {
        if (Input.anyKey)
        {
            _timeToIdle = 0;
        }
        else
        {
            _timeToIdle += Time.deltaTime;

            if (_timeToIdle > 5)
                _timeToIdle = 5;
        }

        if (_timeToIdle >= 5)
        {
            _directorIdle.SetActive(true);
        }
        else if (_timeToIdle < 5)
        {
            _directorIdle.SetActive(false);
        }
    }

    void HandleMovement()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = 30;
            _leftFire.Play();
            _rightFire.Play();
        }
        else
        {
            _currentSpeed = 5;
            _leftFire.Stop();
            _rightFire.Stop();
        }

        Vector3 rotateH = new Vector3(0, _horizontal, 0);
        transform.Rotate(rotateH * _rotSpeed * Time.deltaTime);

        Vector3 rotateV = new Vector3(_vertical, 0, 0);
        transform.Rotate(rotateV * _rotSpeed * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0, -_horizontal * 0.2f), Space.Self);

        transform.position += transform.forward * _currentSpeed * Time.deltaTime;
    }

    public void AllowMovement()
    {
        _canMove = true;
    }

}