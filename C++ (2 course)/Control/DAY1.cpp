#include <iostream>

using namespace std;
int if1 (int a)
{
    if (a > 0)
        return a + 1;

    else

        return a;
}
int if6 (int a, int b)
{
    if (a > b)
        return a;

    else
        return b;
}
int if11 (int a, int b)
{
    if (a != b)
        return a +b;
    else
        a = 0;
    b = 0;
    return a , b;
}
int if12 (int a, int b, int c)
{
  return min(min(a,b),c);
}
int if15 (int a, int b, int c)
{
    if (a>b)
    {
        if (b>c)
            return a + b;
        else
            return a + c;
    }
    else
        return b+c;

}
int main()
{

}
