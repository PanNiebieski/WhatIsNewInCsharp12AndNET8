




var mWithDefault =
    (int a = 0, int b = 0) => a + b;

mWithDefault(); // 0
mWithDefault(5); // 5
mWithDefault(10, 10); // 20

//var fWithDefault =
//    (Func<int, int, int> f = M) => f(1,2);

//int M(int a, int b)
//{
//    return a + b;
//}
