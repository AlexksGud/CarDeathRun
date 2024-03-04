using DavidJalbert.TinyCarControllerAdvance;
using UnityEngine;

public class WheelDetectTrigger : TCCAWheel 
{
    [SerializeField] private CheckPointService _checkPointService;
    [SerializeField] private TCCAPlayer player;
    public override void onTriggerEnter(Collider other)
    {
        base.onTriggerEnter(other);
        if (other.tag == "RestartZone")
            player.setPosition(_checkPointService.CheckPointPos);
    }
}
