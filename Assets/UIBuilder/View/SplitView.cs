using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

/// <summary>
/// ������ͼ
/// </summary>
public class SplitView : TwoPaneSplitView
{
    public new class UxmlFactory : UxmlFactory<SplitView, GraphView.UxmlTraits> { }//���幤�����ã�BehaviourTreeView��¶Ϊ�Զ������
    public SplitView()
    {

    }
}
