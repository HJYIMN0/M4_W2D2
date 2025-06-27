using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    private RaycastHit _ray;
    private Vector3 _startingLocation;
    
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _startingPoint;
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _radius = 0.5f;


    private void Start()
    {
        _startingLocation = _startingPoint.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.SphereCast(Camera.main.ScreenPointToRay(Input.mousePosition), _radius, out _ray))
            {
                if (_ray.collider.gameObject.CompareTag("Target"))
                {
                    Shoot();
                }
                else if (_ray.collider.gameObject.CompareTag("Obstacle"))
                {
                    Debug.Log("Colpito l'ostacolo: " + _ray.collider.gameObject.name);
                }
            }
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_ball, _startingLocation, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Manca il RigidBody!");
            return;
        }
        else
        {
            Vector3 direction = (_ray.point - _startingLocation).normalized;
            rb.AddForce(direction * _force, ForceMode.Impulse);
        }
    }
}
