using UnityEngine.UI;
using UnityEngine;

public class TimeIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _timeIndicator;
    [SerializeField] private GameObject _header;
    
    [SerializeField] private Vector3 offset;

    public void UpdatePosition()
    {
        _timeIndicator.transform.localPosition = _header.transform.localPosition + offset;
    }
}
