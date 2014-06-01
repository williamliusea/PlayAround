using System.Collections.Generic;

namespace TreesAndGraphs
{
    public class GraphNode
    {
        public int d;
        public List<GraphNode> edges;
        public GraphNode(int d)
        {
            this.d = d;
        }
    }
}
