using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Tools.Trees.Dialogue;
using UnityEditor.Callbacks;
using System;

public class DialogueTreeEditor : EditorWindow
{
    DialogueTreeView treeView;
    DialogueInspectorView inspectorView;

    //SerializedObject treeObject;
    //SerializedProperty blacboardProperty;

    //This function is for opening the window from the menu

    [MenuItem("Tools/Dialogue/Editor ...")]
    public static void OpenWindow()
    {
        Debug.Log("should work");
        DialogueTreeEditor wnd = GetWindow<DialogueTreeEditor>();
        wnd.titleContent = new GUIContent("DialogueTreeEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId, int line)
    {
        if(Selection.activeObject is DialogueTree)
        {
            return true;
        }
        return false;
    }
    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;


        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Dialogue Tool/Editor/DialogueTreeEditor.uxml");
        visualTree.CloneTree(root);


        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Dialogue Tool/Editor/DialogueTreeEditor.uss");
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<DialogueTreeView>();
        inspectorView = root.Q<DialogueInspectorView>();
        treeView.OnNodeSelected = OnNodeSelectionChanged;
        OnSelectionChange();

        
    }
    private void OnEnable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }


    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
    }

    private void OnPlayModeStateChanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredEditMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingEditMode:
                //OnSelectionChange();
                break;
            case PlayModeStateChange.EnteredPlayMode:
                OnSelectionChange();
                break;
            case PlayModeStateChange.ExitingPlayMode:
                //OnSelectionChange();
                break;
        }
    }

    private void OnSelectionChange()
    {
        DialogueTree tree = Selection.activeObject as DialogueTree;
        if(!tree)
        {
            if(Selection.activeGameObject)
            {
                DialogueTreeRunner runner = Selection.activeGameObject.GetComponent<DialogueTreeRunner>();

                if(runner)
                {
                    tree = runner.tree;
                }
            }
        }

        if(Application.isPlaying)
        {
            if(tree)
            {
                treeView.PopulateView(tree);
            }
        }

        else
        {
            if(tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
            {
                treeView.PopulateView(tree);
            }
        }
    }

    void OnNodeSelectionChanged(DialogueNodeView node)
    {
        inspectorView.UpdateSelection(node);
    }

    private void OnInspectorUpdate()
    {
        treeView?.UpdateNodeState();
    }
}