using System.Collections.Generic;
using System.Linq;
using Pharaoh.Tools.BehaviourTree.ScriptableObjects;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using Node = Pharaoh.Tools.BehaviourTree.ScriptableObjects.Node;

public class BehaviourTreeView : GraphView
{
    public System.Action<NodeView> OnNodeSelected;
    private BehaviourTree tree;

    public new class UxmlFactory : UxmlFactory<BehaviourTreeView, GraphView.UxmlTraits> {}
    public BehaviourTreeView()
    {
        Insert(0, new GridBackground());

        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Game/Scripts/Editor/BehaviourTree/BehaviourTreeEditor.uss");
        styleSheets.Add(styleSheet);
    }

    private NodeView FindNodeView(Node node)
    {
        return GetNodeByGuid(node.guid) as NodeView;
    }

    public void PopulateView(BehaviourTree bt)
    {
        this.tree = bt;

        graphViewChanged -= OnGraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += OnGraphViewChanged;

        if (tree.root != null)
        {
            tree.root = tree.CreateNode(typeof(RootNode)) as RootNode;
            EditorUtility.SetDirty(tree);
            AssetDatabase.SaveAssets();
        }

        // Create node views
        tree.nodes.ForEach(node => CreateNodeView(node));

        // Create edges
        tree.nodes.ForEach(node =>
        {
            var children = tree.GetChildren(node);
            children.ForEach(child =>
            {
                var parentView = FindNodeView(node);
                var childView = FindNodeView(child);

                var edge = parentView.output.ConnectTo(childView.input);
                AddElement(edge);
            });
        });
    }

    private GraphViewChange OnGraphViewChanged(GraphViewChange graphviewchange)
    {
        if (graphviewchange.elementsToRemove != null)
        {
            graphviewchange.elementsToRemove.ForEach(element =>
            {
                NodeView nodeView = element as NodeView;
                if (nodeView != null)
                {
                    tree.DeleteNode(nodeView.node);
                }

                var edge = element as Edge;
                if (edge != null)
                {
                    var parentView = edge.output.node as NodeView;
                    var childView = edge.input.node as NodeView;
                    tree.RemoveChild(parentView.node, childView.node);
                }
            });
        }

        if (graphviewchange.edgesToCreate != null)
        {
            graphviewchange.edgesToCreate.ForEach(edge =>
            {
                var parentView = edge.output.node as NodeView;
                var childView = edge.input.node as NodeView;
                tree.AddChild(parentView.node, childView.node);
            });
        }

        return graphviewchange;
    }

    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
        return ports.ToList().Where(endPort => 
            endPort.direction != startPort.direction && endPort.node != startPort.node)
            .ToList();
    }

    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        var actionTypes = TypeCache.GetTypesDerivedFrom<ActionNode>();
        foreach (var type in actionTypes)
        {
            evt.menu.AppendAction($"[{type.BaseType.Name}] {type.Name}", (a) => CreateNode(type));
        }

        var compositeTypes = TypeCache.GetTypesDerivedFrom<CompositeNode>();
        foreach (var type in compositeTypes)
        {
            evt.menu.AppendAction($"[{type.BaseType.Name}] {type.Name}", (a) => CreateNode(type));
        }

        var decoratorTypes = TypeCache.GetTypesDerivedFrom<DecoratorNode>();
        foreach (var type in decoratorTypes)
        {
            evt.menu.AppendAction($"[{type.BaseType.Name}] {type.Name}", (a) => CreateNode(type));
        }
    }

    private void CreateNode(System.Type type)
    {
        var node = tree.CreateNode(type);
        CreateNodeView(node);
    }

    private void CreateNodeView(Node node)
    {
        var nodeView = new NodeView(node);
        nodeView.OnNodeSelected = OnNodeSelected;
        AddElement(nodeView);
    }

}
