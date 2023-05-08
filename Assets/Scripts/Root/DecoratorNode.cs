using System;
using UnityEngine;

/// <summary>
/// 装饰节点
/// </summary>
public abstract class DecoratorNode:Node
{
    public Node child;//进行装饰的子节点

    public override Node Clone()
    {
        DecoratorNode node = Instantiate(this);
        node.child = child.Clone();
        return node;
    }
}

