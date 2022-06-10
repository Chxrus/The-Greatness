using System.Collections.Generic;
using UnityEngine;

public class Military: MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private List<string> _enemyTags;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _attackColor;

    [Header("Characteristics")]
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    [SerializeField] private float _radiusVisibility;
    [SerializeField] private int _minDamage;
    [SerializeField] private int _maxDamage;

    private StateMachine _stateMachine;

    private GameObject _enemy;
    public List<string> EnemyTags => _enemyTags;
    public float Speed => _speed;
    public int Health => _health; 
    public float RadiusVisibility => _radiusVisibility;
    public int MinDamage => _minDamage; 
    public int MaxDamage => _maxDamage;
    public GameObject Enemy => _enemy;

    public State currentState;

    private void Start()
    {
        Initialize();

        _stateMachine = new StateMachine();
        _stateMachine.InitializeState(new MoveState(this));
        currentState = new MoveState(this);
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    private void Initialize()
    {
        Vector3 randomAngle = new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(-90, 90));
        transform.eulerAngles = randomAngle;
        GetComponent<SpriteRenderer>().color = _defaultColor;
        Debug.DrawRay(transform.position, randomAngle * _radiusVisibility, _defaultColor);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemyTags.Contains(collision.tag))
        {
            _enemy = collision.gameObject;
            _stateMachine.CurrentState = new AttackState(this);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_enemyTags.Contains(collision.tag))
            _stateMachine.CurrentState = new MoveState(this);
    }

    public void AttackColor()
    {
        GetComponent<SpriteRenderer>().color = _attackColor;
    }

    public void WalkColor()
    {
        GetComponent<SpriteRenderer>().color = _defaultColor;
    }


}