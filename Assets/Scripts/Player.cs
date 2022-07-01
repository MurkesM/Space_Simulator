using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cam3rdPerson;
    //[SerializeField] CinemachineVirtualCamera _camIdle;
    //[SerializeField] PlayableDirector _directorIdle;
    [SerializeField] GameObject _directorIdle;
    [SerializeField] float _timeToIdle = 5;
    [SerializeField] float _idle = -1f;

    void Update()
    {
        SwitchCams();

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    _directorIdle.SetActive(true);
        //}
        //else if (Input.GetKeyDown(KeyCode.Backspace))
        //{
        //    _directorIdle.SetActive(false);
        //}

        if (Time.time >= _timeToIdle && !Input.anyKey)
        {
            _directorIdle.SetActive(true);
            _idle = Time.time + _timeToIdle;
        }
        else if (Time.time < _timeToIdle || Input.anyKey)
        {
            _directorIdle.SetActive(false);
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
}