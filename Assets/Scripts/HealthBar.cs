using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image _healthBar;

    public void SetHealth(float health)
    {
        _healthBar.fillAmount = health;
    }
}
