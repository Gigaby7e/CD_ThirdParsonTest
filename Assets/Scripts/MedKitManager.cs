using UnityEngine;

public class MedKitManager : MonoBehaviour
{
    public MedKit[] MedKits;

    private float _spawnTime = 60f;
    private float _currentTime = 0f;

    private void Update()
    {
        TimersUpdate();
    }

    private void ShowAllKits()
    {
        foreach (MedKit mk in MedKits)
        {
            mk.Show(true);
        }
    }

    private void TimersUpdate()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _spawnTime)
        {
            _currentTime = 0;
            ShowAllKits();
        }

        foreach (MedKit mk in MedKits)
        {
            mk.TimerUpdate();
        }
    }
}
