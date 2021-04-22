using UnityEngine;
using UnityEngine.Events;

public class WaveTimer : MonoBehaviour
{
    [SerializeField]
    private float _timeTillWave, _currentTime;

    [SerializeField]
    UnityEvent _finishedTimer;

    private bool _timing = true;

    private void Start()
    {
        _currentTime = _timeTillWave;

        if (_finishedTimer == null)
            _finishedTimer = new UnityEvent();
    }

    void Update()
    {
        if (!_timing)
            return;

        _currentTime -= Time.deltaTime;
        if(_currentTime <= 0)
        {
            _timing = false;
            _finishedTimer.Invoke();
        }
    }

    public void RestartTimer()
    {
        _currentTime = _timeTillWave;
    }
}
