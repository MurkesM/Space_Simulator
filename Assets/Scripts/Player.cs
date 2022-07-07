using System.Collections;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cam3rdPerson;
    [SerializeField] CameraShake _cameraShake;

    [SerializeField] GameObject _directorIdle;
    [SerializeField] float _timeToIdle = 5;

    [SerializeField] float _rotSpeed = 5;
    [SerializeField] float _currentSpeed = 5;
    [SerializeField] bool _canMove;
    float _vertical;
    float _horizontal;

    [SerializeField] ParticleSystem _leftFire;
    [SerializeField] ParticleSystem _rightFire;

    [SerializeField] ParticleSystem _explosion;
    [SerializeField] Vector3 _offset;
    [SerializeField] bool _explode = false;

    [SerializeField] int _lives = 3;

    [SerializeField] Collider _collider;

    [SerializeField] Transform _shipModel;

    [SerializeField] PlayableDirector _shipDirector;
    [SerializeField] PlayableDirector _endDirector;

    [SerializeField] GameManager _gameManager;

    [SerializeField] AudioSource _audioSource;

    bool _canExplode = true;

    void Update()
    {
        _offset = _shipModel.position;

        if (_lives <= 0 && _canExplode == true)
        {
            _canExplode = false;
             KillPlayer();
        }

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
        }

        if (other.tag == "Asteroid")
        {
            _cameraShake.Shake();

            if (_lives > 0)
                _lives--;

            Destroy(other.gameObject);
        }

        if (other.tag == "Director1")
        {
            _shipDirector.enabled = true;
        }
       
        if (other.tag == "Director2")
        {
            _endDirector.enabled = true;
            _canMove = false;
            _leftFire.Play();
            _rightFire.Play();
            _collider.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bounds")
        {
            _cameraShake.Shake();
            KillPlayer();
        }
    }

    void SwitchCams()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton3) && _cam3rdPerson.enabled == true)
        {
            _cam3rdPerson.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton3) && _cam3rdPerson.enabled == false)
        {
            _cam3rdPerson.enabled = true;
        }
    }

    void HandleIdleState()
    {
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 ||
            Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton5))
        {
            _currentSpeed = 30;
            _leftFire.Play();
            _rightFire.Play();
        }
        else
        {
            _currentSpeed = 15;
            _leftFire.Stop();
            _rightFire.Stop();
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton4))
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

    void KillPlayer()
    {
        if (_collider != null)
            _collider.enabled = false;
        
        _explode = true;
        _canMove = false;

        _gameManager.GameOver();
        StartCoroutine(ExplosionRoutine());
        Destroy(gameObject, 3);
    }

    IEnumerator ExplosionRoutine()
    {
        while (_explode == true)
        {
            _audioSource.Play();
            _cameraShake.Shake();
            Instantiate(_explosion, _offset, Quaternion.identity);
            yield return new WaitForSeconds(0.75f);

            _audioSource.Play();
            _cameraShake.Shake();
            Instantiate(_explosion, _offset, Quaternion.identity);
            yield return new WaitForSeconds(0.75f);

            _audioSource.Play();
            _cameraShake.Shake();
            Instantiate(_explosion, _offset, Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
           
            _explode = false;
        }
    }
}