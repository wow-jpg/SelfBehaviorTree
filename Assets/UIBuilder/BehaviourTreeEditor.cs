using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Callbacks;

public class BehaviourTreeEditor : EditorWindow
{
    BehaviourTreeView treeView;
    InspectorView inspectorView;

    [MenuItem("BehaviourTreeEditor/OpenEditor...")]
    public static void OpenWindow()
    {
        BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
        wnd.titleContent = new GUIContent("BehaviourTreeEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId,int line)
    {
        if(Selection.activeObject is BehaviourTree)
        {
            OpenWindow();
            return true;
        }

        return false;
    }



    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //  VisualElement label = new Label("Hello World! From C#");
        //  root.Add(label);

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/UIBuilder/BehaviourTreeEditor.uxml");
        // VisualElement labelFromUXML = visualTree.Instantiate();
        //  root.Add(labelFromUXML);
        visualTree.CloneTree(root);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/UIBuilder/BehaviourTreeEditor.uss");
        // VisualElement labelWithStyle = new Label("Hello World! With Style");
        //   labelWithStyle.styleSheets.Add(styleSheet);
        // root.Add(labelWithStyle);
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<BehaviourTreeView>();//从根元素进行查询
        inspectorView = root.Q<InspectorView>();//从根元素进行查询

        treeView.OnNodeSelected = OnNodeSelectionChanged;

        OnSelectionChange();
    }

    /// <summary>
    /// 当窗口选择发生变化时
    /// </summary>
    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;

        if (tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
        {
            treeView.PopulateView(tree);
        }
    }



    void OnNodeSelectionChanged(NodeView node)
    {
        inspectorView.UpdateSelection(node);
    }
}