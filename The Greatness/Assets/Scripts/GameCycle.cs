using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameCycle : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private GameUI _gameui;
    [SerializeField] private Characteristics _characteristics;
    [SerializeField] private TimeIndicator _timeIndicator;
    [SerializeField] private CardConveyor _cardConveyor;
    [SerializeField] private EnemySpawner _enemySpawner;

    private int _wave;
    private int _hours;
    private bool _isGameRunning = true;

    private void Awake()
    {
        _characteristics = GetComponent<Characteristics>();
        _timeIndicator = GetComponent<TimeIndicator>();
        _cardConveyor = GetComponent<CardConveyor>();
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Start()
    {
        StartCoroutine(Cycle());
    }

    private void NextHour()
    {
        _characteristics.NextHour();
        _cardConveyor.AddCard();
        _cardConveyor.AddCard();

        _enemySpawner.SpawnEnemies(Random.Range(2, _wave + 3));
    }

    private void NextWave()
    {
        _enemySpawner.SpawnEnemies(5 + (int)Mathf.Pow(_wave * 24 + _hours, .5f));
    }

    private IEnumerator Cycle()
    {
        while (_isGameRunning)
        {
            yield return new WaitForSeconds(7f);
            _hours += 1;

            if (_hours < 10)
            {
                _gameui.UpdateTime($"0{_hours.ToString()}:00");
            }
            else if (_hours >= 10 && _hours <= 24)
            {
                _gameui.UpdateTime($"{_hours.ToString()}:00");
            }
            else if (_hours > 24)
            {
                _hours = 0;
                _wave += 1;
                _gameui.UpdateWave($"Wave #{_wave.ToString()}");
                NextWave();
            }

            _gameui.UpdateTimeSlider(_hours);
            _timeIndicator.UpdatePosition();
            NextHour();
        }
    }
}
