using UnityEngine;
using UnityEditor;
using System.Text;

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer: PropertyDrawer {
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label) {
        switch (_property.propertyType) {
            case SerializedPropertyType.Integer:
                StringBuilder.Set(_property.intValue.ToString());
                break;
            case SerializedPropertyType.Boolean:
                StringBuilder.Set(_property.boolValue.ToString());
                break;
            case SerializedPropertyType.Float:
                StringBuilder.Set(_property.floatValue.ToString());
                break;
            case SerializedPropertyType.String:
                StringBuilder.Set( _property.stringValue);
                break;
            case SerializedPropertyType.Vector2:
                StringBuilder.Set(_property.vector2Value.ToString());
                break;
            case SerializedPropertyType.Vector3:
                StringBuilder.Set(_property.vector3IntValue.ToString());
                break;
            default:
                StringBuilder.Set("(not supported)");
                break;
        }
        EditorGUI.LabelField(_position, _label.text, StringBuilder.instance.ToString());
    }
}
