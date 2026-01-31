using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjetivoSO", menuName = "Scriptable Objects/ObjetivoSO")]
public class ObjetivoSO : ScriptableObject
{
    public string Name;
    public List<Collectable.Type> RequiredObjects;
    public Sprite portrait;
}
