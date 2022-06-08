using UnityEngine;

public abstract class Card : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;

    [SerializeField] private Color _color;

    public Sprite Icon => _icon;
    public string Description => _description;
    public Color Color => _color;

    public abstract void ShowInfo();
    public abstract void Use(Characteristics characteristics);
}
