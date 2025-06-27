using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator3D : MonoBehaviour
{
    [SerializeField] private float _spacing;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;

    [SerializeField] private float _verticalScale;
    [SerializeField] private float _horizontalScale;
    [SerializeField] private float _depthScale;

    [SerializeField] private GameObject _box;

    private void Start()
    {
        ScaleBoxes();
        InstantiateBoxes();
    }

    public void InstantiateBoxes()
    {
        if (_columns > 0 && _rows > 0)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    Instantiate
                    (
                        _box,
                        transform.position + new Vector3(j * _spacing, 0, i * _spacing),
                        Quaternion.identity,
                        transform
                    );
                }
            }
        }
        else if (_columns > 0 && _rows < 1)
        {
            for (int i = 0; i < _columns; i++)
            {
                Instantiate
                (
                    _box,
                    transform.position + new Vector3(i * _spacing, 0, 0),
                    Quaternion.identity,
                    transform
                );
            }
        }
        else if (_columns < 1 && _rows > 0)
        {
            for (int i = 0; i < _rows; i++)
            {
                Instantiate
                (
                    _box,
                    transform.position + new Vector3(0, 0, i * _spacing),
                    Quaternion.identity,
                    transform
                );
            }
        }


    }

    public void ScaleBoxes()
    {
        _box.transform.localScale = new Vector3(1, 1, 1);
        Vector3 scale = _box.transform.localScale;
        scale.x = Mathf.Max(0.1f, scale.x *= _horizontalScale);
        scale.y = Mathf.Max(0.1f, scale.y *= _verticalScale);
        scale.z = Mathf.Max(0.1f, scale.z *= _depthScale);
        _box.transform.localScale = scale;
    }
}
