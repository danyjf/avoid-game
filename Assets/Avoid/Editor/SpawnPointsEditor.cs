using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SpawnPoints))]
public class SpawnPointsEditor : Editor
{
    SpawnPoints _target;

    private void OnEnable()
    {
        _target = (SpawnPoints)target;
	}

    private void OnSceneGUI()
    {
		DrawDefaultInspector();

        var count = _target.SpawnPositions.Count;

        if (count <= 0)
            return;

        var rot = Quaternion.identity;

        for (var i = 0; i < count; i++)
        {
			EditorGUI.BeginChangeCheck();

			var pos = Handles.PositionHandle(_target.SpawnPositions[i],rot);
            Handles.Label(pos, "Spawn Point " + i);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_target, "Changed Spawn Point " + i + " position");
                _target.SpawnPositions[i] = pos;              
            }
        }
    }
}
