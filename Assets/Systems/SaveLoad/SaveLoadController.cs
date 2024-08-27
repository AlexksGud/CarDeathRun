using UnityEngine;
using YG;

public class SaveLoadController : MonoBehaviour
{
    private bool _isEnable = true;
    public bool IsEnable { get => _isEnable; set => _isEnable = value; }

    //read _data when open the app
    private void OnEnable()
    {
        YandexGame.GetDataEvent += LoadData;
        StaticEvents.NeedToSaveProgress += _SaveProgress;

    }

    private void _SaveProgress()
    {
        if (!IsEnable)
        {
            YandexGame.savesData.SetMainGameData(new GameData());
            YandexGame.SaveProgress();
        }
        else
        {
          //  YandexGame.savesData.SetMainGameData(game.GetData());
            YandexGame.SaveProgress();
        }



    }

    private void LoadData()
    {

        GameData raceIdleData = new GameData();
        raceIdleData = YandexGame.savesData.GetMainGameData();

      //  game.Initialize(raceIdleData);
    }
    private void OnApplicationQuit()
    {
        _SaveProgress();
    }
}