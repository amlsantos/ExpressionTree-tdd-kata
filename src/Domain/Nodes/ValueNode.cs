namespace Domain.Nodes;

public class ValueNode : Node
{
    public ValueNode(string value) : base(value) { }

    public override double Evaluate() => double.Parse(Value);
}