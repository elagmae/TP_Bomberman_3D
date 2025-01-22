using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(AIStateMachine))]
public class AIStateMachineEditor : UnityEditor.Editor
{
    private AIStateMachine stateMachine;
    
    private void OnEnable()
    {
        stateMachine = (AIStateMachine)target;
    }
    
    public override void OnInspectorGUI()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            var _currentState = stateMachine.GetType()
                .GetField("_currentState", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(stateMachine);
            
            GUI.enabled = false;
            EditorGUILayout.TextField("Current State: ", _currentState.GetType().Name);
            GUI.enabled = true;
            
            foreach (States state in Enum.GetValues(typeof(States)).Cast<States>())
            {
                GUILayout.Label("Debug state changer:");
                if (GUILayout.Button("Change state to " + state))
                {
                    stateMachine.TransitionToState(state);
                }
                
                GUILayout.Space(10);
            }
            
            GUILayout.Label("Variables: ");

        }
        base.OnInspectorGUI();
    }
}
