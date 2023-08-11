using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;

BenchmarkRunner.Run<Benchmarks>();

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly Random random = new Random(256);

    [Benchmark]
    public int[] Create_Array()
    {
        var array = new int[1000];

        for (int i = 0; i < 1000; i++)
        {
            array[i] = random.Next();
        }

        return array;
    }

    [Benchmark]
    public MyArray<int> Create_MyArray()
    {
        var array = new MyArray<int>();

        for (int i = 0; i < 1000; i++)
        {
            array[i] = random.Next();
        }

        return array;
    }


    private int[] _preArray = new int[1000];
    private MyArray<int> _preInlineArray = new MyArray<int>();

    [GlobalSetup]
    public void Setup()
    {
        Random random = new Random(256);

        for (int i = 0; i < 1000; i++)
        {
            _preArray[i] = random.Next();
        }

        random = new Random(256);
        for (int i = 0; i < 1000; i++)
        {
            _preInlineArray[i] = random.Next();
        }
    }


    [Benchmark]
    public int Get_Array()
    {
        var sum = 0;

        for (int i = 0; i < 1000; i++)
        {
            sum += _preArray[i];
        }

        return sum;
    }

    [Benchmark]
    public int Get_MyArray()
    {
        var sum = 0;

        for (int i = 0; i < 1000; i++)
        {
            sum += _preInlineArray[i];
        }

        return sum;
    }

}



[InlineArray(1000)]
public struct MyArray<T>
{
    private T _element;
}
