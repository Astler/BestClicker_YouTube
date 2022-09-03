using AnimatedLight.Data;
using Extensions.Enumerable;
using UnityEditor;

namespace AnimatedLight.Editor
{
    [CustomEditor(typeof(CoreLightAnimator), true)]
    public class LightAnimatorEditor : UnityEditor.Editor
    {
        public LightType selectedType;

        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("  a - 0% light\n  m - 100% light\n  z - 200% light", MessageType.Info);
            serializedObject.Update();

            EditorGUILayout.Space();
            
            selectedType = (LightType)serializedObject.FindProperty("selectedPattern").intValue;
            selectedType = (LightType)EditorGUILayout.EnumPopup("Light Type", selectedType);
            serializedObject.FindProperty("selectedPattern").intValue = (int)selectedType;
            
            SerializedProperty patternProperty = serializedObject.FindProperty("pattern");

            if (selectedType == LightType.Custom)
            {
                EditorGUILayout.PropertyField(patternProperty);
            }
            else
            {
                LightPatternData pattern = LightPatterns.GetPatternDataByType(selectedType);
                serializedObject.FindProperty("pattern").stringValue = pattern.Pattern;
                EditorGUILayout.HelpBox($"Selected pattern: {pattern.Pattern}", MessageType.Info);
            }
            
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("maxLightIntensity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("animationDelay"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("tickTime"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("smoothTransition"));

            if (patternProperty.stringValue.IsNullOrEmpty())
            {
                patternProperty.stringValue = "";
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}