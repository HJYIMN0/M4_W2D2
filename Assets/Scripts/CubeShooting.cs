using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShooting : MonoBehaviour
{
    private RaycastHit _ray;
    private Vector3 _startingLocation;

    [SerializeField] private float _force = 10f;
    [SerializeField] private float _radius = 1.5f;
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private GameObject _plane;
    [SerializeField] private float _offset = 0.1f;

    private void CubeShoot()
    {
        if (Physics.SphereCast(
            Camera.main.ScreenPointToRay(Input.mousePosition),
            _radius,
            out _ray,
            Mathf.Infinity,
            _layerMask))
        {
            Collider _col = _ray.collider;
            if (_col == null) Debug.LogError ("Manca il Collider!");
            Rigidbody _rb = _col.GetComponent<Rigidbody>();
            if (_rb == null) Debug.LogError("Manca il RigidBody!");
            _rb.AddForceAtPosition(
                (_rb.transform.position - _ray.point).normalized * _force,
                _ray.point,
                ForceMode.Impulse);
            Vector3 _spawn = _ray.point + (_ray.normal * _offset);
            Quaternion _rot = Quaternion.FromToRotation(Vector3.up, _ray.normal);
            Instantiate(_plane, _spawn, _rot, _col.gameObject.transform);
            //_plane.transform.localPosition = _plane.transform.position - transform.position;
            //if (_plane.transform.localPosition.x < -0.5f || _plane.transform.localPosition.x > 0.5f)
            //{
            //    _plane.GetComponent<Rigidbody>().MovePosition();    
            //}
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CubeShoot();
        }
    }
}
