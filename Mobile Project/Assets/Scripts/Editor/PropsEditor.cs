using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Props))]
public class PropsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Props myProps = (Props)target;

        #region Setting Properties at Editor

        serializedObject.Update();

        EditorGUILayout.LabelField("Instantiate props with one click");
        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("propContainer"));
        EditorGUILayout.Space();

        ShowArrayElements("props");
        EditorGUILayout.Space();

        ShowArrayElements("positions");
        EditorGUILayout.Space();

        serializedObject.ApplyModifiedProperties();

        #endregion

        if (myProps.CheckIfCanInstantiate())
        {
            EditorGUILayout.HelpBox("You can proceed with the instantiation on the objects", MessageType.Info);

            if (GUILayout.Button("Instantiate props"))
            {
                myProps.InstantiateProps();                 
            }
        }
        else
        {
            EditorGUILayout.HelpBox("Insert some elements in your fields", MessageType.Error);
        }
            
        if (myProps.ChildPrefabs)
        {
            if (GUILayout.Button("Delete props"))
                myProps.DeleteElements();             
        }
    }

    void ShowArrayElements(string array)
    {
        SerializedProperty obj = serializedObject.FindProperty(array);

        //the false will avoid the propertie do not show all it's fields
        EditorGUILayout.PropertyField(obj, false);

        //This will add a identation level to the Array.size
        EditorGUI.indentLevel += 1;

        EditorGUILayout.PropertyField(obj.FindPropertyRelative("Array.size"));

        //This will add a identation level to the array alements
        EditorGUI.indentLevel += 1;

        //With this code, we can set the list size, and the elements will be shown in the inspetor
        for (int i = 0; i < obj.arraySize; i++)
        {
            EditorGUILayout.PropertyField(obj.GetArrayElementAtIndex(i));
        }

        //This will remove a identation level to the list elements
        EditorGUI.indentLevel -= 2;
    }
}
