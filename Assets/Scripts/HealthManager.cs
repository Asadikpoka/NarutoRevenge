using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance = null;
    [SerializeField] private Text _healthText;
    public int _health = 3;
    private int _damage = 1;

    private void Start()
    {
        instance = this;
        _healthText.text = _health.ToString();
    }

    public void DecreaseScore()
    {
        _health -= _damage;
        _healthText.text = _health.ToString();
    }
}
