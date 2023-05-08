using System;
using UnityEngine;
public class BehaviourTreeRunner : MonoBehaviour
{
    public BehaviourTree tree;

    private void Start()
    {

        tree = tree.Clone();
        //tree = ScriptableObject.CreateInstance<BehaviourTree>();

        //var log = ScriptableObject.CreateInstance<DebugLogNode>();
        //log.message = "你好呀1";

        //var wait = ScriptableObject.CreateInstance<WaitNode>();
        //wait.duration = 5f;

        //var log2 = ScriptableObject.CreateInstance<DebugLogNode>();
        //log2.message = "你好呀2";
        //var log3 = ScriptableObject.CreateInstance<DebugLogNode>();
        //log3.message = "你好呀3";

        //var loop = ScriptableObject.CreateInstance<RepeatNode>();


        //var seq = ScriptableObject.CreateInstance<SequencerNode>();
        //seq.children.Add(wait);
        //seq.children.Add(log);

        //seq.children.Add(log2);
        //seq.children.Add(log3);

        //loop.child = seq;

        //tree.rootNode = loop;
    }

    private void Update()
    {
        tree.Update();
    }
}

