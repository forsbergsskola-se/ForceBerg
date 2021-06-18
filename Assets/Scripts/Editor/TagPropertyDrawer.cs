using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(TagWrapperAttribute))]
public class TagPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        property.stringValue = EditorGUI.TagField(position, property.stringValue);
    }
}