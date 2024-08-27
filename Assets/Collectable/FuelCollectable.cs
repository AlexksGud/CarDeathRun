public class FuelCollectable : Collectable
{

    public override void Collect()
    {
        StaticEvents.OnPlayerCollect.Invoke(new(CollectableType, CollectableValue));
        Disactivate();
    }

    public override void DestroyCollectable()
    {

    }

    public override void Disactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        
    }
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if(other.tag=="Player")
        Collect();
    }


}
