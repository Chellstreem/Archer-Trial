using UnityEngine;
using System.Collections;

public interface ICoroutineRunner
{
    public Coroutine StartCor(IEnumerator coroutine);
    public void StopCor(Coroutine coroutine);
}
