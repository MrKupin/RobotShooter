using UnityEngine;
using UnityEngine.EventSystems;

public class DoorController : MonoBehaviour
{
    protected Door _door;
    [SerializeField] private EventTrigger _doorOpenEvent;
    [SerializeField] private EventTrigger _doorCloseEvent;

    public virtual void OpenDoor()
    {
        _door.SelectDoorState(true);
        _doorCloseEvent.gameObject.SetActive(true);
        _doorOpenEvent.gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        _door.SelectDoorState(false);
        _doorOpenEvent.gameObject.SetActive(true);
        _doorCloseEvent.gameObject.SetActive(false);
    }

    public void SetDoor(Door door)
    {
        _door = door;
    }

    private void OnEnable()
    {
        if (_door.IsOpen)
        {
            _doorCloseEvent.gameObject.SetActive(true);
            _doorOpenEvent.gameObject.SetActive(false);
        }
        else
        {
            _doorCloseEvent.gameObject.SetActive(false);
            _doorOpenEvent.gameObject.SetActive(true);
        }
    }
}
