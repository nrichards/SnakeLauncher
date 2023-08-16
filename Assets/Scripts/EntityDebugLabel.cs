using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class EntityDebugLabel : MonoBehaviour
{
    public TMPro.TMP_Text label;
    
    protected Dictionary<string, string> items = new Dictionary<string, string>();
    
    public void AddDebugValue(string name, string value)
    {
        items[name] = value;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        label.text = items.ConcatenateKeyValuePairs<string, string>();
    }
}

public static class DictionaryDebugExtensions
{
    public static string ConcatenateKeyValuePairs<TKey, TValue>(this Dictionary<TKey, TValue> dict)
    {
        return string.Join(", ", dict.Select(kvp => $"{kvp.Key}:{kvp.Value}"));
    }
}
