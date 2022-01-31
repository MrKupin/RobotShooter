using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] protected DoorController _doorController;
    private Quaternion _closeDoorRotation;
    private Quaternion _openDoorRotation;
    protected bool _isOpen;
    private bool _maxDistance;
    public bool IsOpen => _isOpen;

    private void Start()
    {
        _closeDoorRotation = transform.rotation;
        _openDoorRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.eulerAngles.y + 90, transform.rotation.z);
    }

    private void Update()
    {
        ActivateDoorController();

        if (_isOpen == false)
            CloseDoor();
        else
            OpenDoor();
    }

    private void ActivateDoorController()
    {
        float distance = (transform.position - _player.position).magnitude;
        if (distance < 2.5f)
        {
            _doorController.SetDoor(this);
            _doorController.gameObject.SetActive(true);
            _maxDistance = true;

        }
        else if(_maxDistance == true)
        {
            _doorController.gameObject.SetActive(false);
            _maxDistance = false;
        }
    }

    public virtual void SelectDoorState(bool isOpen)
    {
        _isOpen = isOpen;
    }

    private void OpenDoor()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _openDoorRotation, 0.5f);
    }

    private void CloseDoor()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _closeDoorRotation, 0.5f);
    }
}
