using System;

public static class StaticEvents 
{
    public static Action<CollectableValues> OnPlayerCollect;
    internal static Action NeedToSaveProgress;
}
