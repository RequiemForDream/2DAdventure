using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.New_Folder
{
    [CustomPropertyDrawer(typeof(GameObjectOfTypeAttribute))]
    public class GameObjectOfTypeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            bool isFieldGameObject = IsFieldGameObject();

            if (!isFieldGameObject)
            {
                DrawError(position);
                return;
            }

            var gameObjectOfTypeAttribute = attribute as GameObjectOfTypeAttribute;
            var requiredType = gameObjectOfTypeAttribute.type;

            CheckDragAndDrops(position, requiredType);
            CheckValues(property, requiredType);
            DrawObjectField(property, position, label, gameObjectOfTypeAttribute.allowSceneObjects); 
        }

        private bool IsFieldGameObject()
        {
            return fieldInfo.FieldType == typeof(GameObject) ||
                typeof(IEnumerable<GameObject>).IsAssignableFrom(fieldInfo.FieldType);
        }

        private void DrawError(Rect position)
        {
            EditorGUI.HelpBox(position, "GameObjectOfTypeAttribute works only with GameObject references",
                MessageType.Error);
        }

        private void CheckDragAndDrops(Rect position, Type requiredType)
        {
            if (position.Contains(Event.current.mousePosition))
            {
                var draggedObjectCount = DragAndDrop.objectReferences.Length;

                for (int i = 0; i < draggedObjectCount; i++)
                {
                    if (!IsValidObject(DragAndDrop.objectReferences[i], requiredType))
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                        break;
                    }
                }
            }
        }

        private void CheckValues(SerializedProperty property, Type requiredType)
        {
            if (property.objectReferenceValue != null)
            {
                if (!IsValidObject(property.objectReferenceValue, requiredType))
                {
                    property.objectReferenceValue = null;
                }
            }
        }

        private bool IsValidObject(System.Object obj, Type requiredType)
        {
            bool result = false;

            var gameObj = obj as GameObject;

            if (gameObj != null)
            {
                result = gameObj.GetComponent(requiredType) != null;
            }

            return result;
        }

        private void DrawObjectField(SerializedProperty property, Rect position, GUIContent label, bool allowSceneObjects)
        {
            property.objectReferenceValue = EditorGUI.ObjectField(position, label,
                property.objectReferenceValue, typeof(GameObject), allowSceneObjects);
        }
    }
}