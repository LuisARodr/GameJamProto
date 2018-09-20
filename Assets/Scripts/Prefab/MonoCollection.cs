using System.Collections.Generic;
using UnityEngine;

public class MonoCollection<T> : MonoBehaviour where T : MonoCollection<T>
{
    public static List<T> all = new List<T>();

    protected virtual void OnEnableEx()
    {
    }

    protected virtual void OnDisableEx()
    {
    }

    protected void OnEnable()
    {
        all.Add(this as T);
        OnEnableEx();
    }

    protected void OnDisable()
    {
        all.Remove(this as T);
        OnDisableEx();
    }
}