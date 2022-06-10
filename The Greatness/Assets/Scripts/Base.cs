using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int _health;

    private void Awake()
    {
        gameObject.tag = "Base";
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Debug.LogError("Game Over!");
            Destroy(gameObject);
        }
    }
}

