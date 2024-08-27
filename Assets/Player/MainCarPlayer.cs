using DavidJalbert.TinyCarControllerAdvance;
using System;
using UnityEngine;

public class MainCarPlayer : MonoBehaviour
{
    #region FuelFields
    [Header("Fuel")]
    [SerializeField] private float _maxFuelTank;
    [SerializeField] private float _currentFuelTank;
    [SerializeField] private float _fuelPerSpeed;
    public float MaxFuelTank => _maxFuelTank;
    public float CurrentFuelTank => _currentFuelTank;
    public float LerpedFuelTank => Mathf.InverseLerp(0, _maxFuelTank, _currentFuelTank);
    #endregion

    #region TurboFields
    [Header("Turbo"), Space(5)]
    [SerializeField] private float _maxTurboTank;
    [SerializeField] private float _currentTurboTank;
    [SerializeField] private float _turboPerInput;
    public float MaxTurboTank => _maxTurboTank;
    public float CurrentTurboTank => _currentTurboTank;
    public float LerpedTurboTank => Mathf.InverseLerp(0, _maxTurboTank, _currentTurboTank);
    #endregion

    [SerializeField] private TCCAPlayer _car;

    private float maxSpeed;
    private float distanceTraveled;
    private float timeElapsed;

    public void SetCar(TCCAPlayer car)
    {
        _car = car;
        maxSpeed = car.getWheelsMaxSpeed();
    }
    private void Awake()
    {
        InitFuelTurbo();


    }
    private void Start()
    {
        if (_car != null)
            maxSpeed = _car.getWheelsMaxSpeed();
    }
    public void InitFuelTurbo()
    {
        StaticEvents.OnPlayerCollect += OnCollect;
        _currentFuelTank = _maxFuelTank;
        _currentTurboTank = _maxTurboTank;
    }

    private void OnCollect(CollectableValues values)
    {
        switch (values.Type)
        {
            case CollectableType.FUEL:
                _currentFuelTank += Mathf.Clamp( values.Value,0,_maxFuelTank);
                break;

            case CollectableType.TURBO:
                _currentTurboTank += Mathf.Clamp(values.Value, 0, _maxTurboTank);
                break;

            case CollectableType.COIN:
                break;
        }
    }

    void FixedUpdate()
    {
        if (_car != null)
        {
            FuelWaste();
            TurboWaste();
        }
    }
    private void FuelWaste()
    {
        if (_car.motorDelta != 0)
        {
            if (ChangingDirection())
                return;

            var speed = Math.Abs(_car.CarBody.getForwardVelocity());
            var clampedspeed = Math.Clamp(speed, 0, maxSpeed);
            var totalWaste = clampedspeed * Time.fixedDeltaTime * _fuelPerSpeed;

            FuelConsamptionCalculation(speed);

            _currentFuelTank -= totalWaste;

        }

        bool ChangingDirection()
        {
            // Если при движение в одну сторону нажимае на кнопку ведущую машину в другую сторону
            // происходит торможение и мы не тратим бензин на это
            if (Math.Sign(_car.motorDelta) != Math.Sign(_car.CarBody.getForwardVelocity()))
            {
                return true;
            }

            return false;
        }

        void FuelConsamptionCalculation(float speed)
        {
            distanceTraveled += speed * Time.fixedDeltaTime;
            timeElapsed += Time.fixedDeltaTime;

            float averageFuelConsumption = distanceTraveled / (timeElapsed / 60f);
           // Debug.Log($"AvarageFuelConsm: {averageFuelConsumption}");
        }
    }
    private void TurboWaste() 
    {
        if (_car.boostDelta != 0)
        {

            var speed = Math.Abs(_car.CarBody.getForwardVelocity());
            var clampedspeed = Math.Clamp(speed, 0, maxSpeed);
            var totalWaste = clampedspeed * Time.fixedDeltaTime * _turboPerInput;

            _currentTurboTank -= totalWaste;

        }
    }
}
