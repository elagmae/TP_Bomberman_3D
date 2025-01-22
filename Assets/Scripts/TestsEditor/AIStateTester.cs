using System.Reflection;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class AIStateTester
{
    [Test]
    public void AIStateTransitionTest()
    {
        GameObject obj = new GameObject();
        var state = obj.AddComponent<AIStateMachine>();

        state.GetType().GetField("_defaultState", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(state, "AIStateChase");
        
        string defaultState = "AIStateChase";
        
        state.GetType().GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(state, null);
        
        state.TransitionToState(States.FLEE);

        var newState = state.GetType().GetField("_currentState", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.GetValue(state) as AIStateBase;
        
        Assert.That(newState.GetType().Name, Is.EqualTo(nameof(AIStateFlee)));
    }
    
}
