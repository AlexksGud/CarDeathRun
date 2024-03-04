using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _positionForPlayer;
    public Vector3 PositionForPlayer => _positionForPlayer.position;
    public event Action OnCheckPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnCheckPoint?.Invoke();
        }
    }
}
