using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    [TextArea]
    [Tooltip("Description of what this object stores and where it might be used.")]
    public string Description = "";

    [Tooltip("A variable of float type")]
    public float Value;
}
