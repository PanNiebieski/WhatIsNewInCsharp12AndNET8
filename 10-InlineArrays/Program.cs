using System.Runtime.CompilerServices;

var array = new int[10];

for (int i = 0; i < array.Length; i++)
{
    array[i] = i;
}

for (int i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}

var myarray = new MyArray<int>();


for (int i = 0; i < 10; i++)
{
    myarray[i] = i;
}

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(myarray[i]);
}


[InlineArray(10)]
public struct MyArray<T>
{
    private T _element;
}
