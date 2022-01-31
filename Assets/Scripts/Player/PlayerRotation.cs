using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotation : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _playerParent;
    [SerializeField] private Transform _cameraRotationAxis;
    [SerializeField] private AimingStates _aiming;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _mouseSensitivity;
    private float _xAxis;
    private float _yAxis;
    private Quaternion _stopRotation;

    private void Start()
    {
        _aiming.OnEnabledAiming += SetDefaultRotation;
        _yAxis = _playerParent.transform.rotation.eulerAngles.y;
    }

    public void OnPointerDown(PointerEventData eventData) => _stopRotation = _player.rotation;

    public void OnDrag(PointerEventData eventData)
    {
        float xAxis = eventData.delta.y;
        float yAxis = eventData.delta.x;
        _xAxis -= xAxis * _mouseSensitivity;
        _xAxis = Mathf.Clamp(_xAxis, -10, 35);
        _yAxis += yAxis * _mouseSensitivity;
        _cameraRotationAxis.localRotation = Quaternion.Euler(_xAxis, 0, 0);
        _playerParent.transform.rotation = Quaternion.Euler(0, _yAxis, 0);
        if (_aiming.IsAiming == false && _playerMovement.GetMoveDirection == Vector3.zero)
        {
            _player.rotation = _stopRotation;
        }
    }

    private void SetDefaultRotation()
    {
        _player.localRotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        _aiming.OnEnabledAiming -= SetDefaultRotation;
    }
}
