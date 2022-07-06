using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseSource _source;

    public void Shake()
    {
        _source.GenerateImpulse();
    }
}
