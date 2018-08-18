using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeGenerator))]

public class TreeEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		TreeGenerator tree = target as TreeGenerator;
		tree.GenerateMap();
	}
}
