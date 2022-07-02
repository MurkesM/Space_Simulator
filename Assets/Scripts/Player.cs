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
    //[SerializeField] Transform _shipModal;

    [SerializeField] private float _rotSpeed = 5;
    [SerializeField] private float _currentSpeed = 5;
    [SerializeField] bool _canMove;
    private float _vertical;
    private float _horizontal;
    
    void Update()
    {
        if (_canMove == true)
            HandleMovement();

        SwitchCams();
        HandleIdleState();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bounds")
        {
            Debug.Log("Out of bounds!");
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
        }
        else
        {
            _currentSpeed = 5;
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

    //void HandlePlayableArea()
    //{
    //    //X bounds
    //    if (_shipModal.position.x >= -2647.0f)
    //        _shipModal.position = new Vector3(-2647.0f, transform.position.y, transform.position.z);

    //    if (_shipModal.position.x <= -4500.8f)
    //        _shipModal.position = new Vector3(-4500.8f, transform.position.y, transform.position.z);

    //    //Y bounds
    //    if (_shipModal.position.y > 34.5f)
    //        _shipModal.position = new Vector3(transform.position.x, 34.5f, transform.position.z);

    //    if (_shipModal.position.y < -53.1f)
    //        _shipModal.position = new Vector3(transform.position.x, -53.1f, transform.position.z);

    //    //Z bounds
    //    if (_shipModal.position.z >= -2526.4f)
    //        _shipModal.position = new Vector3(transform.position.x, transform.position.y, -2526.4f);

    //    if (_shipModal.position.z <= -2791.2f)
    //        _shipModal.position = new Vector3(transform.position.x, transform.position.y, -2791.2f);
    //}
}