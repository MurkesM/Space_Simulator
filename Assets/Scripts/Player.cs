using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
   [SerializeField] CinemachineVirtualCamera _cam3rdPerson;
    
    void Update()
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