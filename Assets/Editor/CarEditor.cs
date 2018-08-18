using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CarGenerator))]

public class CarEditor : Editor {
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		CarGenerator map = target as CarGenerator;
		map.GenerateMap();
	}
}
