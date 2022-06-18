using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Military: MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private List<string> _enemyTags;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _attackColor;
    [SerializeField] private LayerMask _layerMask;

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
    public int MinDamage => _minDamage; 
    public int MaxDamage => _maxDamage;
    public GameObject Enemy => _enemy;

    public State currentState;

    public bool isMoving = false;

    private void OnValidate()
    {
        if (_speed <= 0)
            _speed = 1;

        if (_health <= 0)
            _health = 10;

        if (_minDamage <= 0)
            _minDamage = 1;

        if (_maxDamage <= 1)
            _maxDamage = 2;

        if (_radiusVisibility <= 1)
            _radiusVisibility = 3;
    }

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

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, _radiusVisibility, transform.position, 0, _layerMask);
        Debug.DrawRay(transform.position, Vector3.up * _radiusVisibility, _defaultColor);
        if (hit)
        {
            if (_enemyTags.Contains(hit.collider.tag))
            {
                if (!isMoving)
                {
                    _stateMachine.ChangeState(new AttackState(this, hit.collider.gameObject));
                }
            }
        }
    }

    public void ResetState()
    {
        _stateMachine.ChangeState(new MoveState(this));
    }

    private void Initialize()
    {
        GetComponent<SpriteRenderer>().color = _defaultColor;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Destroy(gameObject);
    }

    public void AttackColor()
    {
        GetComponent<SpriteRenderer>().color = _attackColor;
    }

    public void WalkColor()
    {
        GetComponent<SpriteRenderer>().color = _defaultColor;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}