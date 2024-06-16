using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[Serializable]
public class SerializableDictionary<Tkey,Tvalue> : Dictionary<Tkey,Tvalue> , ISerializationCallbackReceiver
{
    [SerializeField] private List<Tkey> _keys = new List<Tkey>();
    [SerializeField] private List<Tvalue> _values = new List<Tvalue>();
    
    /// <summary>
    /// save the dictionary to lists
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void OnBeforeSerialize()
    {
        _keys.Clear();
        _values.Clear();

        foreach (KeyValuePair<Tkey,Tvalue> pair in this)
        {
            _keys.Add(pair.Key);
            _values.Add(pair.Value);
        }
    }
    
    /// <summary>
    /// load the dictionary from lists
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void OnAfterDeserialize()
    {
       Clear();
       
       if (_keys.Count != _values.Count)
       {
           throw new JsonException("The amount of keys (" + _keys.Count + ") does not match the number of values (" + _values.Count + ")");
       }

       for (int i = 0; i < _keys.Count; i++)
       {
           Add(_keys[i],_values[i]);
       }
    }
}
