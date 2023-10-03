using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class BadGuyManager : ScriptableObject
{
   public string[] prefabNames;

   public int[] prefabsToSpawn;

   public Vector2Wrapper[] spawnPoints;
}
