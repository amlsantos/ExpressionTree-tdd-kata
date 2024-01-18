namespace Domain.Nodes;

public class DivisionNode : OperationNode
{
    public DivisionNode(string _operator, Node left, Node right) : base(_operator, left, right)
    { }

    public override double Evaluate()
    {
        if (Left.Evaluate() == 0)
            throw new InvalidOperationException();
        if (Right.Evaluate() == 0)
            throw new InvalidOperationException();

        return Left.Evaluate() / Right.Evaluate();
    }
}