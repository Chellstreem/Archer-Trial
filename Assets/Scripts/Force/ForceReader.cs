using System.Collections;
using UnityEngine;
using Zenject;

public class ForceReader : IForceInformer
{
    private IInput input;
    private ICoroutineRunner runner;
    public float CurrentForce { get; private set; }
    private readonly float minForce = 5f;
    private readonly float maxForce = 30f;    
    
    private Coroutine coroutine;    
    private float _startTime;

    [Inject]
    public void Construct(IInput input, ICoroutineRunner runner)
    {        
        this.input = input; 
        this.runner = runner;

        this.input.OnButtonPressed += HandleButtonPressed;
        this.input.OnButtonReleased += HandleButtonReleased;
    }

    private void HandleButtonPressed()
    {
        _startTime = Time.time;
        coroutine = runner.StartCor(ChargeForce());
    }

    private void HandleButtonReleased()
    {
        if (coroutine != null)
        {
            runner.StopCor(coroutine);
            coroutine = null;
        }       
    }

    private IEnumerator ChargeForce()
    {
        while (true)
        {
            float holdTime = Time.time - _startTime;
            float t = Mathf.Clamp01(holdTime / 2f); // 2 сек для достижения maxForce
            CurrentForce = Mathf.Lerp(minForce, maxForce, t);
            yield return null;
        }
    }
}
