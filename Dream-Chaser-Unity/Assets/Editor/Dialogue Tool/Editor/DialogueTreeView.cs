using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Tools.Trees.Dialogue;
using UnityEditor.Experimental.GraphView;
using System;
using System.Linq;

public class DialogueTreeView : GraphView
{
    
    public Action<DialogueNodeView> OnNodeSelected;
    public new class UxmlFactory :  UxmlFactory<DialogueTreeView, GraphView.UxmlTraits> { }
    DialogueTree tree;

    public DialogueTreeView()
    {
        Insert(0, new GridBackground());
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());


        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Dialogue Tool/Editor/DialogueTreeEditor.uss");
        styleSheets.Add(styleSheet);

        Undo.undoRedoPerformed += OnUndoRedo;
    }

    private void OnUndoRedo()
    {
        PopulateView(tree);
        AssetDatabase.SaveAssets();
    }

    internal void PopulateView(DialogueTree tree)
    {
        this.tree = tree;

        graphViewChanged -= OnGraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += OnGraphViewChanged;

        if(tree.RootNode == null)
        {
            tree.RootNode = tree.CreateNode(typeof(DialogueRootNode)) as DialogueRootNode;
            EditorUtility.SetDirty(tree);
            AssetDatabase.SaveAssets();
        }

        tree.nodes.ForEach(n => CreateNodeView(n));

        tree.nodes.ForEach(n =>
        {
            
            var children = tree.GetChildren(n);
            var actions = tree.GetActions(n);

            children.ForEach(c =>
            {
                DialogueNodeView parentView = findNodeView(n);
                DialogueNodeView childView = findNodeView(c);
            if (childView.input != null && parentView != null)
                {
                    Edge edge = parentView.output.ConnectTo(childView.input);
                    AddElement(edge);
                }
            });
            actions.ForEach(c =>
            {
                DialogueNodeView parentView = findNodeView(n);
                DialogueNodeView childView = findNodeView(c);
            if (childView.input != null && parentView != null)
                {
                Edge edge = parentView.actionin.ConnectTo(childView.actionout);
                AddElement(edge);
                }
            });


        });
    }

    private DialogueNodeView findNodeView(DialogueNode n)
    {
        return GetNodeByGuid(n.GUID) as DialogueNodeView;
    }

    private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
    {
        if(graphViewChange.elementsToRemove != null)
        {
            graphViewChange.elementsToRemove.ForEach(elem =>
            {
                DialogueNodeView nodeView = elem as DialogueNodeView;
                if (nodeView != null)
                {
                    tree.DeleteNode(nodeView.node);
                }

                Edge edge = elem as Edge;

                if(edge != null)
                {
                    DialogueNodeView parentView = edge.output.node as DialogueNodeView;
                    DialogueNodeView childView = edge.input.node as DialogueNodeView;
                    tree.KillChild(parentView.node, childView.node);
                }
            });
        }

        if(graphViewChange.edgesToCreate != null)
        {
            graphViewChange.edgesToCreate.ForEach(edge =>
            {

                DialogueNodeView parentview = edge.output.node as DialogueNodeView;
                DialogueNodeView childView = edge.input.node as DialogueNodeView;
                tree.AddChild(parentview.node, childView.node);
                tree.AddAction(parentview.node, childView.node);
            });
        }

        if(graphViewChange.movedElements != null)
        {
            nodes.ForEach((n) =>
            {
                DialogueNodeView dialogueNodeView = n as DialogueNodeView;
                dialogueNodeView.SortChildren();
            });
        }
        return graphViewChange;
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        return ports.ToList().Where(endPort =>
        endPort.direction != startPort.direction &&
        endPort.node != startPort.node).ToList();
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        var types = TypeCache.GetTypesDerivedFrom<DialogueNode>();
        foreach(var type in types)
        {
            if (type.Name != "DialogueRootNode" && !type.IsSubclassOf(typeof(DialogueActionNode)) && type.Name != "DialogueActionNode")
            {
                evt.menu.AppendAction($"[Nodes]/ {type.Name}", (a) => CreateNode(type));
            }
        }

        var actiontypes =  TypeCache.GetTypesDerivedFrom<DialogueActionNode>();
        foreach(var type in actiontypes)
        {
            evt.menu.AppendAction($"[Nodes]/ DialogueActionNodes/  {type.Name}", (a) => CreateNode(type));
        }
    }

    private void CreateNode(System.Type type)
    {
        
        if(tree == null)
        {
            Debug.Log(type);
        }
        DialogueNode node = tree.CreateNode(type);

        CreateNodeView(node);
    }

    private void CreateNodeView(DialogueNode node)
    {
        DialogueNodeView nodeView = new DialogueNodeView(node);
        nodeView.OnNodeSelected = OnNodeSelected;
        AddElement(nodeView);
    }

    internal void UpdateNodeState()
    {
        nodes.ForEach((n) =>
        {
            DialogueNodeView view = n as DialogueNodeView;
            view.UpdateState();
        });
    }
}
