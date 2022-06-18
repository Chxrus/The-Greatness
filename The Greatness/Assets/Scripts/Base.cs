using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private int _health;

    private void Awake()
    {
        gameObject.tag = "Base";
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _gameUI.UpdateBaseHealth(_health);
        
        if (_health <= 0)
        {
            _gameUI.ShowGameOver();
            Destroy(gameObject);
        }
    }
}

