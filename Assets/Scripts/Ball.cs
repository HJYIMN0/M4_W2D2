using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy = 5f;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
