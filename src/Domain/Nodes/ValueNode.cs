namespace Domain.Nodes;

public class ValueNode : Node
{
    private readonly double _value;
    public ValueNode(string value) : base(value) => _value = double.Parse(value);

    public override double Evaluate() => _value;
}