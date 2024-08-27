using System;
using UnityEngine;

public abstract class Collectable:MonoBehaviour
{

    [SerializeField] private CollectableValues _collectableTypeValue;

    public CollectableType CollectableType => _collectableTypeValue.Type;
    public float CollectableValue => _collectableTypeValue.Value;

    public abstract void Collect();
    public abstract void Disactivate();
    public abstract void DestroyCollectable();
    //  public event Action<CollectableValues> OnCollect;

}

[Serializable] 
public class CollectableValues 
{
    public CollectableType Type;
    public float Value;

    public CollectableValues(CollectableType type, float value)
    {
        Type = type;
        Value = value;
    }
}
public enum CollectableType
{
    FUEL,
    TURBO,
    COIN
}
