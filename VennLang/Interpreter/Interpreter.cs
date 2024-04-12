using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VennLang
{
    public class Interpreter
    {
        /// <summary>
        /// Pass a root node of a tree. The interpreter will then process the tree and return a number.
        /// </summary>
        public string Visit(Node node)
        {
            var results = RecVisit(node);
            return results.ToString();
        }

        private SetNode RecVisit(Node node)
        {
            if (node.GetType() == typeof(SetNode))
            {
                return VisitSetNode((SetNode)node);
            }
            if (node.GetType() == typeof(UnionNode))
            {
                return VisitUnionNode((UnionNode)node);
            }
            if (node.GetType() == typeof(IntersectNode))
            {
                return VisitIntersectNode((IntersectNode)node);
            }
            if (node.GetType() == typeof(SetDifferenceNode))
            {
                return VisitDifferenceNode((SetDifferenceNode)node);
            }
            if (node.GetType() == typeof(SymmertricSetDifferenceNode))
            {
                return VisitSymmetricDifferenceNode((SymmertricSetDifferenceNode)node);
            }
            else
            {
                return new SetNode(new List<object> { });
            }
        }

        private SetNode VisitSetNode(SetNode node)
        {
            return new SetNode(node.Values.ToList());
        }

        private SetNode VisitUnionNode(UnionNode node)
        {
            //We can't assume these are sets! They may be sets, but they may also be another union, with it's own two nodes. This is where the recusive visit comes in.
            var set1 = RecVisit(node.Node1);
            var set2 = RecVisit(node.Node2);

            return new SetNode(set1.Values.Union(set2.Values).ToList());
        }
        private SetNode VisitIntersectNode(IntersectNode node)
        {
            var set1 = RecVisit(node.Node1);
            var set2 = RecVisit(node.Node2);

            return new SetNode(set1.Values.Intersect(set2.Values).ToList());
        }

        private SetNode VisitDifferenceNode(SetDifferenceNode node)
        {
            var set1 = RecVisit(node.Node1);
            var set2 = RecVisit(node.Node2);

            return new SetNode(set1.Values.Except(set2.Values).ToList());
        }

        private SetNode VisitSymmetricDifferenceNode(SymmertricSetDifferenceNode node)
        {
            var set1 = RecVisit(node.Node1).Values;
            var set2 = RecVisit(node.Node2).Values;

            return new SetNode(set1.Concat(set2).ToList().Except(set1.Intersect(set2)).ToList());
        }
    }
}
