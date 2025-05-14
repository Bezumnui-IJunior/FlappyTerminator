using System.Collections;
using UnityEngine;

namespace Misc
{
    public interface ICoroutineExecutor
    {
        public Coroutine StartCoroutine(IEnumerator enumerator);
        public void StopCoroutine(Coroutine coroutine);
    }
}