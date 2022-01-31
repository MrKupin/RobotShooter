using UnityEngine;
using UnityEngine.EventSystems;

public class Lock : MonoBehaviour, IDragHandler
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private LockableDoor _lockableDoor;
    private RaycastHit2D _hit = new RaycastHit2D();

    private void Start()
    {
        _background.size = new Vector2(Screen.width, Screen.height);
        _background.gameObject.GetComponent<BoxCollider2D>().size = _background.size;
        _lineRenderer.SetPosition(0, transform.position);
    }

    private void Update()
    {
        _lineRenderer.SetPosition(1, transform.position);

        if (Input.GetMouseButtonUp(0))
            transform.localPosition = new Vector3(88, -6);

        if (Vector2.Distance(transform.position, _endPoint.position) < 0.5f)
        {
            transform.localPosition = new Vector3(88, -6);
            _lockableDoor.OpenLock();
            Camera.main.depth = 1;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

        if (_hit.collider != null)
        {
            transform.position = _hit.point;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        }
    }

    public void SetDoor(LockableDoor lockableDoor)
    {
        _lockableDoor = lockableDoor;
    }
}
