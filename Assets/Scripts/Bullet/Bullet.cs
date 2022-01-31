using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionPrefab;
    private ParticleSystem _explosion = new ParticleSystem();
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    public float Damage => _damage;

    private void Awake()
    {
        _explosion = Instantiate(_explosionPrefab);
    }

    private void OnEnable()
    {
        StartCoroutine(TurnOff());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed);
    }

    private IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _explosion.transform.position = transform.position;
        _explosion.transform.rotation = transform.rotation;
        _explosion.Play();
        gameObject.SetActive(false);
    }
}
