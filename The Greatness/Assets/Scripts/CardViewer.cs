using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CardViewer : MonoBehaviour
{
    [SerializeField] private Card _card;

    [SerializeField] private Image _icon;
    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _description;

    private void Awake()
    {
        if (_card != null)
            InitializeCard(_card);
    }

    public void InitializeCard(Card card)
    {
        _card = card;

        _icon.sprite = card.Icon;
        _description.text = card.Description;
        _background.color = card.Color;

        _icon.SetNativeSize();  
    }

    private void OnMouseDown()
    {
        if (_card != null)
            _card.Use(FindObjectOfType<Characteristics>());

        Destroy(gameObject);
    }

}
