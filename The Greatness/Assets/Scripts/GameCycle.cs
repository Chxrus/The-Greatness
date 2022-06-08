using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Characteristics))]
[RequireComponent(typeof(TimeIndicator))]
public class GameCycle : MonoBehaviour
{
    private Characteristics _characteristics;
    private TimeIndicator _timeIndicator;
    private CardConveyor _cardConveyor;

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
    }

    private void Start()
    {
        StartCoroutine(Cycle());
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
            }

            _timeSlider.value = _hours;
            _timeIndicator.UpdatePosition();

            _characteristics.NextHour();
            _cardConveyor.AddCard();
            
        }
    }
}
