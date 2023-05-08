using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

/// <summary>
/// 分屏视图
/// </summary>
public class SplitView : TwoPaneSplitView
{
    public new class UxmlFactory : UxmlFactory<SplitView, GraphView.UxmlTraits> { }//定义工厂类让，BehaviourTreeView暴露为自定义组件
    public SplitView()
    {

    }
}
