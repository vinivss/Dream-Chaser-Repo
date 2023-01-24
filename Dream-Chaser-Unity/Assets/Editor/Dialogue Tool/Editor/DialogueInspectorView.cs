using System.Collections;
using System.Collections.Generic;
using Tools.Trees.Dialogue;
using UnityEngine.UIElements;
using UnityEditor;

public class DialogueInspectorView : VisualElement
{
    public new class UxmlFactory : UxmlFactory<DialogueInspectorView, VisualElement.UxmlTraits> { };
    Editor editor;
    public DialogueInspectorView()
    {

    }

    internal void UpdateSelection(DialogueNodeView node)
    {
        Clear();

        UnityEngine.Object.DestroyImmediate(editor);
        editor = Editor.CreateEditor(node.node);
        IMGUIContainer container = new IMGUIContainer(() =>
        {
            if (editor.target)
            {
                editor.OnInspectorGUI();
            }
        });
        Add(container);
    }
}
