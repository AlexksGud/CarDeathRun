namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public GameData GetMainGameData()
        {
            return new();
        }

        public void SetMainGameData(GameData _data)
        {

        }

        public SavesYG()
        {
            SetMainGameData(new GameData());
        }
    }
}
