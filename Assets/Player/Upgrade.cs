using System;
using UnityEngine;

public class Upgrade : MonoBehaviour, ISaveLoad<CarUpgradeData>
{
    [SerializeField] private CarUpgradeField _speedUpgrades;
    [SerializeField] private CarUpgradeField _accelerationUpgrades;
    [SerializeField] private CarUpgradeField _fuelUpgrades;
    [SerializeField] private CarUpgradeField _turboUpgrades;

    public CarUpgradeData GetData()
    {
        var data = new CarUpgradeData();

        data.TurboUpgrades = _turboUpgrades;
        data.FuelUpgrades = _fuelUpgrades;
        data.AccelerationUpgrades = _accelerationUpgrades;
        data.SpeedUpgrades = _speedUpgrades;

        return data;
    }

    public void Initialize(CarUpgradeData data)
    {
        _speedUpgrades = new CarUpgradeField (data.SpeedUpgrades);
        _accelerationUpgrades = new CarUpgradeField(data.AccelerationUpgrades);
        _turboUpgrades = new CarUpgradeField(data.TurboUpgrades);
        _fuelUpgrades = new CarUpgradeField(data.FuelUpgrades);
    }
}
[Serializable]
public class BaseUpgrade
{
    private float currentValue;
    private int currentLevel;
    private int maxLevel;

    public float Value => currentValue;

    public bool MaxLevel => (maxLevel <= currentLevel);

    public void NextLevel(float value)
    {
        if (MaxLevel)
            return;

        currentValue = value;
        currentLevel++;
    }
}
[Serializable]
public class BaseUpgradePrice
{
    private float currentPrice;
    public float Price => currentPrice;

    public void NextLevel(float value)
    {
        currentPrice = value;
    }
}
[Serializable]
public class CarUpgradeField
{
    private BaseUpgradePrice _priceValues;
    private BaseUpgrade _upgradeValues;
    public float CurrentValue => _upgradeValues.Value;
    public float CurrentPrice => _priceValues.Price;

    private CarUpgradeField (BaseUpgradePrice priceValues, BaseUpgrade upgradeValues)
    {
        _priceValues = priceValues;
        _upgradeValues = upgradeValues;
    }

    public CarUpgradeField (CarUpgradeField data)
    {
        new CarUpgradeField(data._priceValues, data._upgradeValues);
    }

    public void Upgrade(float newValue,float newPrice)
    {
        _priceValues.NextLevel(newPrice);
        _upgradeValues.NextLevel(newValue);

        if (_upgradeValues.MaxLevel)
        {

        }
    }

}

[Serializable]
public class CarUpgradeData
{
    public CarUpgradeField SpeedUpgrades;
    public CarUpgradeField AccelerationUpgrades;
    public CarUpgradeField FuelUpgrades;
    public CarUpgradeField TurboUpgrades;
}


