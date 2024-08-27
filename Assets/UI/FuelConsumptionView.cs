using UnityEngine;
using UnityEngine.UI;

public class FuelConsumptionView : MonoBehaviour
{
    [SerializeField] private MainCarPlayer _currentCar;
    [SerializeField] private Image _fuelFill;
    [SerializeField] private Image _turboFill;

    private void Update()
    {
        if (_currentCar != null)
        {
            _fuelFill.fillAmount = _currentCar.LerpedFuelTank;
            _turboFill.fillAmount = _currentCar.LerpedTurboTank;
        }
    }
}
