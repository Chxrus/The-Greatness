using UnityEngine;

public class CardConveyor : MonoBehaviour
{
    [SerializeField] private Card[] _cardsList;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _container;

    public void AddCard()
    {
        int randomNumber = Random.Range(0, _cardsList.Length);
        GameObject cardPrefab = Instantiate(_prefab, _container);
        cardPrefab.GetComponent<CardViewer>().InitializeCard(_cardsList[randomNumber]);
    }
}
