using UnityEngine;

public class MedKit : MonoBehaviour, ICollectableObject
{
    [SerializeField] private int _power = 20;
    [SerializeField] private float _lifeTime = 30;
    [SerializeField] private float _currentLifeTime = 30;
    [SerializeField] private GameObject _visual;
    [SerializeField] private Collider _collider;

    private bool _isVisible = false;

    public float LifeTime 
    { 
        get => _currentLifeTime; 
        set 
        {
            _currentLifeTime = value;
            CheckLifeTime();
        } 
    }

    private void CheckLifeTime()
    {
        if (_currentLifeTime <= 0)
        {
            Show(false);
        }
    }

    public void TimerUpdate()
    {
        if (_isVisible)
        {
            LifeTime -= Time.deltaTime;
        }
    }

    public void Show(bool isVisible)
    {
        _currentLifeTime = _lifeTime;
        _collider.enabled = isVisible;
        _visual.SetActive(isVisible);
        _isVisible = isVisible;
    }

    public int Collect()
    {
        return _power;
    }

    public void OnCollected()
    {
        Show(false);
    }
}