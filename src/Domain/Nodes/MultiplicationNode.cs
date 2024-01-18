namespace Domain.Nodes;

public class MultiplicationNode : OperationNode
{
    public MultiplicationNode(string _operator, Node left, Node right) : base(_operator, left, right)
    { }

    public override double Evaluate() => Left.Evaluate() * Right.Evaluate();
}