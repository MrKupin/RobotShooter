using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : HealthBar
{
    [SerializeField] private Image _healthBarPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Transform _point;
    private float _distance = 9;

    private void Start()
    {
        _healthBar = Instantiate(_healthBarPrefab, _canvas.transform);
    }

    private void Update()
    {
        Positioning();
    }

    private void Positioning()
    {
        float distance = (_camera.transform.position - _healthBar.transform.position).magnitude;
        _healthBar.transform.localScale *= (distance / _distance);
        _distance = distance;
        _healthBar.transform.LookAt(_camera.transform.position);
        _healthBar.gameObject.transform.position = _point.position;

        if (distance > 30)
            _healthBar.gameObject.SetActive(false);
        else
            _healthBar.gameObject.SetActive(true);
    }
}
