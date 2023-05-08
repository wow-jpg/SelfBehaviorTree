using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;


public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public Action<NodeView> OnNodeSelected;
    public Node node;
    public Port input;
    public Port output;

    public NodeView(Node node):base("Assets/Data/UIBuilder/NodeView.uxml")
    {
        this.node = node;
        this.title = node.name;
        this.viewDataKey = node.guid;

        style.left = node.viewPosition.x;
        style.top = node.viewPosition.y;

        CreateInputPorts();
        CreateOutputPorts();
    }


    /// <summary>
    /// 创建连图连出连接端口
    /// </summary>
    private void CreateOutputPorts()
    {

        if (node is ActionNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));//生成连接线
        }
        else if (node is CompositeNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));//生成连接线


        }
        else if (node is DecoratorNode)
        {
            input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));//生成连接线

        }else if(node is RootNode)
        {
           // input=InstantiatePort(Orientation.Horizontal)
        }

        if (input != null)
        {
            input.portName = "";
            inputContainer.Add(input);
        }

    }

    /// <summary>
    /// 创建连图连入连接端口
    /// </summary>
    private void CreateInputPorts()
    {
        if (node is ActionNode)
        {

        }
        else if (node is CompositeNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Multi, typeof(bool));//生成连接线

        }
        else if (node is DecoratorNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));//生成连接线

        }else if(node is RootNode)
        {
            output = InstantiatePort(Orientation.Vertical, Direction.Output, Port.Capacity.Single, typeof(bool));//生成连接线

        }

        if (output != null)
        {
            output.portName = "";
          outputContainer.Add(output);
        }
    }

    /// <summary>
    /// 设置节点视图块的位置
    /// </summary>
    /// <param name="newPos"></param>
    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);

        node.viewPosition.x = newPos.xMin;
        node.viewPosition.y = newPos.yMin;
    }



    public override void OnSelected()
    {

        base.OnSelected();
        if(OnNodeSelected!=null)
        {
            OnNodeSelected.Invoke(this);
        }
    }
}

