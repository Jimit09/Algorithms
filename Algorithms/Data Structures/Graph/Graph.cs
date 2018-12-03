using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Data_Structures.Graph
{
    internal class Graph
    {
        private Dictionary<int, GraphNode> nodeLookup = new Dictionary<int, GraphNode>();

        internal void AddEdge(int source, int destination)
        {
            GraphNode s = GetNode(source);
            GraphNode d = GetNode(destination);
            s.Adjacent.Add(d);
        }

        private GraphNode GetNode(int data)
        {
            GraphNode graphNode = new GraphNode(data);
            return graphNode;
        }

        internal bool HasPathDFS(int source, int destination)
        {
            GraphNode s = GetNode(source);
            GraphNode d = GetNode(destination);
            HashSet<int> visited = new HashSet<int>();
            return HasPathDFS(s, d, visited);
        }

        private bool HasPathDFS(GraphNode source, GraphNode destination, HashSet<int> visited)
        {
            if (visited.Contains(source.Id))
            {
                return false;
            }
            visited.Add(source.Id);
            if (source.Id == destination.Id)
            {
                return true;
            }
            foreach (var adjacent in source.Adjacent)
            {
                if (HasPathDFS(adjacent, destination, visited))
                {
                    return true;
                }
            }
            return false;
        }

        internal bool HasPathBFS(int source, int destination)
        {
            return HasPathBFS(GetNode(source), GetNode(destination));
        }

        private bool HasPathBFS(GraphNode source, GraphNode destination)
        {
            HashSet<int> visited = new HashSet<int>();
            LinkedList<GraphNode> nextToVisit = new LinkedList<GraphNode>();
            nextToVisit.AddFirst(source);
            while (nextToVisit.Any())
            {
                GraphNode node = nextToVisit.ElementAt(0);
                nextToVisit.Remove(node);
                if (node == destination)
                {
                    return true;
                }

                if (visited.Contains(node.Id))
                {
                    continue;
                }
                visited.Add(node.Id);
                foreach (GraphNode child in node.Adjacent)
                {
                    nextToVisit.AddLast(child);
                }
            }
            return false;
        }
    }
}
