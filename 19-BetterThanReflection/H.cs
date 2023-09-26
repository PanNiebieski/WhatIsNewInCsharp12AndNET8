using System.Runtime.CompilerServices;

public class H
{
    // Constructors
    private H() { }
    private H(int value) { _value = value; }

    private readonly int _value;

    public int GetValue()
    {
        return _value;
    }
}

public class BridgeH
{

    [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
    extern static H CallPrivateConstructorClass();

    [UnsafeAccessor(UnsafeAccessorKind.Constructor)]
    extern static H CallPrivateConstructorClassWithArg(int value);
}

