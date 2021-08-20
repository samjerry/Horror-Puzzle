using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] float _yOffset;

    Quaternion _oldRot;
    Vector3 _oldPos;

    [SerializeField] RotationAxes _axes = RotationAxes.MouseXAndY;


    [SerializeField] float _sensitivityX = 15F;
    [SerializeField] float _sensitivityY = 15F;

    [SerializeField] float _minimumX = -360F;
    [SerializeField] float _maximumX = 360F;

    [SerializeField] float _minimumY = -60F;
    [SerializeField] float _maximumY = 60F;

    [SerializeField] float _rotationX = 0F;
    [SerializeField] float _rotationY = 0F;

    private List<float> _rotArrayX = new List<float>();
    float _rotAverageX = 0F;

    private List<float> _rotArrayY = new List<float>();
    float _rotAverageY = 0F;

    public float _frameCounter = 20;

    Quaternion _originalRotation;

    void Start()
    {
        Rigidbody rb = _target.GetComponent<Rigidbody>();
        if (rb) { rb.freezeRotation = true; }

        _originalRotation = transform.localRotation;
        SetTransform();
    }

    private void Update()
    {
        if (transform.position != _oldPos) { SetTransform(); }
        if (transform.rotation != _oldRot) { SetTransform(); }

        /// <summary>
        ///  Mouse Input
        /// <summary>

        if (_axes == RotationAxes.MouseXAndY)
        {
            _rotAverageY = 0f;
            _rotAverageX = 0f;

            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;
            _rotationX += Input.GetAxis("Mouse X") * _sensitivityX;

            _rotArrayY.Add(_rotationY);
            _rotArrayX.Add(_rotationX);

            if (_rotArrayY.Count >= _frameCounter)
            {
                _rotArrayY.RemoveAt(0);
            }
            if (_rotArrayX.Count >= _frameCounter)
            {
                _rotArrayX.RemoveAt(0);
            }

            for (int j = 0; j < _rotArrayY.Count; j++)
            {
                _rotAverageY += _rotArrayY[j];
            }
            for (int i = 0; i < _rotArrayX.Count; i++)
            {
                _rotAverageX += _rotArrayX[i];
            }

            _rotAverageY /= _rotArrayY.Count;
            _rotAverageX /= _rotArrayX.Count;

            _rotAverageY = ClampAngle(_rotAverageY, _minimumY, _maximumY);
            _rotAverageX = ClampAngle(_rotAverageX, _minimumX, _maximumX);

            Quaternion yQuaternion = Quaternion.AngleAxis(_rotAverageY, Vector3.left);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotAverageX, Vector3.up);

            transform.localRotation = _originalRotation * xQuaternion * yQuaternion;
        }
        else if (_axes == RotationAxes.MouseX)
        {
            _rotAverageX = 0f;

            _rotationX += Input.GetAxis("Mouse X") * _sensitivityX;

            _rotArrayX.Add(_rotationX);

            if (_rotArrayX.Count >= _frameCounter)
            {
                _rotArrayX.RemoveAt(0);
            }
            for (int i = 0; i < _rotArrayX.Count; i++)
            {
                _rotAverageX += _rotArrayX[i];
            }
            _rotAverageX /= _rotArrayX.Count;

            _rotAverageX = ClampAngle(_rotAverageX, _minimumX, _maximumX);

            Quaternion xQuaternion = Quaternion.AngleAxis(_rotAverageX, Vector3.up);
            transform.localRotation = _originalRotation * xQuaternion;
        }
        else
        {
            _rotAverageY = 0f;

            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;

            _rotArrayY.Add(_rotationY);

            if (_rotArrayY.Count >= _frameCounter)
            {
                _rotArrayY.RemoveAt(0);
            }
            for (int j = 0; j < _rotArrayY.Count; j++)
            {
                _rotAverageY += _rotArrayY[j];
            }
            _rotAverageY /= _rotArrayY.Count;

            _rotAverageY = ClampAngle(_rotAverageY, _minimumY, _maximumY);

            Quaternion yQuaternion = Quaternion.AngleAxis(_rotAverageY, Vector3.left);
            transform.localRotation = _originalRotation * yQuaternion;
        }

    }

    void SetTransform()
    {
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y + _yOffset, _target.transform.position.z);
        transform.rotation = _target.transform.rotation;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        angle = angle % 360;
        if ((angle >= -360F) && (angle <= 360F))
        {
            if (angle < -360F)
            {
                angle += 360F;
            }
            if (angle > 360F)
            {
                angle -= 360F;
            }
        }
        return Mathf.Clamp(angle, min, max);
    }

}
