using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : ScriptableObject
{
    public enum State
    {
        Running,
        Failure,
        Success
    }

    public State state = State.Running;

   [HideInInspector] public bool started = false;
    [HideInInspector] public string guid;
    /// <summary>
    /// 在行为树视图面板上的位置信息
    /// </summary>
    [HideInInspector]  public Vector2 viewPosition;
    
    public State Update()
    {
        if(!started)
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if(state==State.Success||state==State.Failure)
        {
            OnStop();
            started = false;
        }

        return state;
    }
    
    public virtual Node Clone()
    {
        return Instantiate(this);
    }

    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract State OnUpdate();
}
