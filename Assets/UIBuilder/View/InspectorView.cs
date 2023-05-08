using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor;

/// <summary>
/// 检视视图
/// </summary>
public class InspectorView : VisualElement
{
    public new class UxmlFactory : UxmlFactory<InspectorView, VisualElement.UxmlTraits> { }//定义工厂类让，BehaviourTreeView暴露为自定义组件


    Editor editor;

    public InspectorView()
    {

    }

    internal void UpdateSelection(NodeView nodeView)
    {
        Clear();//移除上次选择的信息


        UnityEngine.Object.DestroyImmediate(editor);
        editor = Editor.CreateEditor(nodeView.node);

        IMGUIContainer container = new IMGUIContainer(()=>
        {
            editor.OnInspectorGUI();
        });

        Add(container);
    }
}
