#include <iostream>

using namespace std;
void for1 (int n)
{
    for (int k = 0; k < n; ++k)
    cout<<"For 1 - "<<k<<endl;
}
void for2 (int a)
{
    for (int b = 10; a <= b ; ++a)
    cout<<"For 2 - "<<a<<endl;
}
void for3 (int a)
{
    for (int b = 10; a < b; --b)
    cout<<"For 3 - "<<b<<endl;
}
void for4 (int cost)
{
    for (int i = 1; i<=10; ++i)
    {
    cout<<"For 4 - "<<i<<endl<<cost*i<<endl;
    }
}
int main()
{
for1 (10);
for2 (0);
for3 (0);
for4 (4);
}
