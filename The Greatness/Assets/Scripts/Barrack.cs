using UnityEngine;

public class Barrack : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;

    public void HireMilitary(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(_prefab, _container);
        }
    }
}

