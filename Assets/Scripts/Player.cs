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

    void Update()
    {
        SwitchCams();

        HandleIdleState();
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
}