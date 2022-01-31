using UnityEngine;

public class LockableDoor : Door
{
    [SerializeField] private Lock _lock;
    [SerializeField] private Canvas _canvas;
    private bool _isLocked = true;

    public override void SelectDoorState(bool isOpen)
    {
        if (_isLocked == true && isOpen == true)
        {
            _doorController.gameObject.SetActive(false);
            _lock.enabled = true;
            Camera.main.depth = 0;
            _canvas.enabled = false;
            _lock.SetDoor(this);
        }
        else
        {
            _isOpen = isOpen;
        }

    }

    public void OpenLock()
    {
        _lock.enabled = false;
        _isLocked = false;
        _canvas.enabled = true;
        _doorController.gameObject.SetActive(true);
    }
}
