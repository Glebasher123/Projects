#include <iostream>
#include <cmath>

int f(int a)
{
    int b = ((((a / 10) / 10) / 10) / 10 / 10);
    int c = a % 10;
    return b + c;
}
bool f2 (int a)
{
    return a%10==7;
}
bool f3 (int a)
{
    return a%20==0;
}
double f4  (double x,double y,double z)
{
    double a = (1 / sqrt (x));
    double b = pow (x,y+z);
    return sqrt (a+b);
}
double f5 (double x)
{
    double a = (3-4*cos(2*x)+ cos(4*x)/8);
    double b = (3+4*cos(2*x)+ cos(4*x)/8);
    double a1 = pow (a,2);
    double b1 = pow (b,2);
    return a1+b1;

}
int main(){
	std::cout<<f(157858)<<std::endl;
	std::cout<<f2(5458)<<std::endl;
	std::cout<<f3(80)<<std::endl;
	std::cout<<f4(9,5,3)<<std::endl;
	std::cout<<f5(4)<<std::endl;
}
