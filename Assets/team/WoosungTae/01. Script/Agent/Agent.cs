using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public abstract class Agent : MonoBehaviour
{
    private Dictionary<Type, IComponent> _componentDict = new Dictionary<Type, IComponent>();

    protected virtual void Awake()
    {
        _componentDict = GetComponentsInChildren<IComponent>().ToDictionary(compo => compo.GetType());

        InitializeComponents();
    }

    protected virtual void InitializeComponents()
    {
        foreach (IComponent compo in _componentDict.Values)
        {
            compo.Initialize(this);
        }
    }

    public T GetCompo<T>() where T : IComponent
    {
        Type type = typeof(T);
        return (T)_componentDict.GetValueOrDefault(type);
    }
}