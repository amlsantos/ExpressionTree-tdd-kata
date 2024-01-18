namespace Domain.Nodes;

public class ValueNode : Node
{
    private string _value;
    public ValueNode(string value) => _value = value;

    public override double Evaluate() => double.Parse(_value);
}