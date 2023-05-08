using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu()]
public class BehaviourTree : ScriptableObject
{
    public Node rootNode;
    public Node.State treeState = Node.State.Running;//整得行为树的状态

    public List<Node> nodes = new List<Node>();

    public Node.State Update()
    {
        if (rootNode.state == Node.State.Running)
        {
            treeState = rootNode.Update();
        }
        return treeState;
    }

    /// <summary>
    /// 生成节点资源
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public Node CreateNode(System.Type type)
    {
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name = type.Name;
        node.guid = GUID.Generate().ToString();
        nodes.Add(node);


        AssetDatabase.AddObjectToAsset(node, this);//生成资源对象
        AssetDatabase.SaveAssets();

        return node;
    }


    /// <summary>
    /// 删除节点资源
    /// </summary>
    /// <param name="node"></param>
    public void DeleteNode(Node node)
    {
        nodes.Remove(node);
        AssetDatabase.RemoveObjectFromAsset(node);//从其资源中删除对象
        AssetDatabase.SaveAssets();
    }

    /// <summary>
    /// 添加子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    public void AddChild(Node parent,Node child)
    {
        DecoratorNode decorator = parent as DecoratorNode;

        if(decorator)
        {
            decorator.child = child;
        }


        RootNode rootNode = parent as RootNode;

        if (rootNode)
        {
            rootNode.child=child;
        }



        CompositeNode composite = parent as CompositeNode;

        if(composite)
        {
            composite.children.Add(child);
        }



    }

    /// <summary>
    /// 移除子节点
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    public void RemoveChild(Node parent,Node child)
    {
        DecoratorNode decorator = parent as DecoratorNode;

        if (decorator)
        {
            decorator.child = null;
        }


        RootNode rootNode = parent as RootNode;

        if (rootNode)
        {
            rootNode.child = null;
        }




        CompositeNode composite = parent as CompositeNode;

        if (composite)
        {
            composite.children.Remove(child);
        }

    }

    /// <summary>
    /// 获得子结节
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public List<Node> GetChildren(Node parent)
    {
        List<Node> children = new List<Node>();

        DecoratorNode decorator = parent as DecoratorNode;

        if (decorator&&decorator.child!=null)
        {
            children.Add(decorator.child);
        }


        RootNode rootNode = parent as RootNode;

        if (rootNode&&rootNode.child!=null)
        {
            children.Add(rootNode.child);
        }


        CompositeNode composite = parent as CompositeNode;

        if (composite)
        {
            return composite.children;
        }

        return children;
    }


    public BehaviourTree Clone()
    {
        BehaviourTree tree = Instantiate(this);
        tree.rootNode = tree.rootNode.Clone();
        return tree;
    }

}

