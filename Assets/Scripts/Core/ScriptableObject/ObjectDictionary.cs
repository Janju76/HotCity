using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Serializable Dictionary by Erik
/// </summary>
/// <typeparam name="TKey">Key Type</typeparam>
/// <typeparam name="TValue">Value Type</typeparam>
public abstract class ObjectDictionary<TKey, TValue> : ScriptableObject
{
    [SerializeField]
    TKey[] keys = new TKey[0];
    [SerializeField]
    TValue[] values = new TValue[0];

    private Dictionary<TKey, TValue> dict;

    private void OnEnable()
    {
        dict = new Dictionary<TKey, TValue>();
        Init();
    }

    private void Init()
    {
        dict.Clear(); // in case we call it from Dirty()
        for (int i = 0; i < keys.Length; i++)
            dict.Add(keys[i], values[i]);
    }

    public void Add(TKey k, TValue v)
    {
        dict.Add(k, v);
        CopyDict();
    }

    public void Remove(TKey k)
    {
        dict.Remove(k);
        CopyDict();
    }

    public void Clear()
    {
        dict.Clear();
        keys = new TKey[0];
        values = new TValue[0];
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return dict.TryGetValue(key, out value);
    }

    public bool ContainsKey(TKey key)
    {
        return dict.ContainsKey(key);
    }

    public bool ContainsValue(TValue value)
    {
        return dict.ContainsValue(value);
    }

    private void CopyDict()
    {
        keys = dict.Keys.ToArray();
        values = dict.Values.ToArray();
    }

    public void Dirty()
    {
        Init();
    }

        
    public void CopyDict(out TKey[] keyArray, out TValue[] valueArray)
    {
        keyArray = dict.Keys.ToArray();
        valueArray = dict.Values.ToArray();
    }        
}
