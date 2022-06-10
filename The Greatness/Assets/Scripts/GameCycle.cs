using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Characteristics))]
[RequireComponent(typeof(TimeIndicator))]
[RequireComponent(typeof(EnemySpawner))]
public class GameCycle : MonoBehaviour
{
    private Characteristics _characteristics;
    private TimeIndicator _timeIndicator;
    private CardConveyor _cardConveyor;
    private EnemySpawner _enemySpawner;

    [SerializeField] private Slider _timeSlider;

    [SerializeField] private TextMeshProUGUI _waveText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private int _wave;
    [SerializeField] private int _hours;

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
                _timeText.text = $"0{_hours.ToString()}:00";
            }
            else if (_hours >= 10 && _hours <= 24)
            {
                _timeText.text = $"{_hours.ToString()}:00";
            }
            else if (_hours > 24)
            {
                _hours = 0;
                _wave += 1;
                _waveText.text = $"Wave #{_wave.ToString()}";
                NextWave();
            }

            _timeSlider.value = _hours;
            _timeIndicator.UpdatePosition();

            NextHour();
        }
    }
}
