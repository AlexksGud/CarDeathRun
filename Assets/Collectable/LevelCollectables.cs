using UnityEngine;

public class LevelCollectables : MonoBehaviour,IOnLevel
{
    [SerializeField] private Collectable[] collectables;

    public void Finish()
    {
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].DestroyCollectable();
        }
    }

    public void Restart()
    {
        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].gameObject.SetActive(true);
        }
       
    }

    public void StartLevel()
    {
       
    }
}
