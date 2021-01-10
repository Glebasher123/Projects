#include <iostream>
#include <cmath>
#define PI 3.14

using namespace std;

int begin1 (int a)
{
    cout<<"begin 1 - "<<4*a<<endl;
}
int begin2 (int a)
{
    cout<<"begin 2 - "<<pow (a,2)<<endl;
}
int begin3 (int a, int b)
{
    cout<<"begin 3 - "<<a*b<<" "<<2*(a+b)<<endl;
}
double begin4 (double d)
{
    cout<<"begin 4 - "<<PI*d<<endl;
}
double begin5 (double a)
{
    double v = pow (a,3);
    double s = 6*pow(a,2);
     cout<<"begin 5 - "<<pow (a,3)<<" "<<6*pow(a,2)<<endl;
}
double begin6 (double a, double b, double c)
{
   cout<<"begin 6 - "<<a*b*c<<" "<<2*(a*b+b*c+a*c)<<endl;
}
double begin7 (double r)
{
    double l = 2*PI*r;
    double s = PI*pow (r,2);
    cout<<"begin 7 - "<<2*PI*r<<" "<<PI*pow (r,2)<<endl;
}
int begin8 (int a, int b)
{
    int v = (a+b)/2;
    cout<<"begin 8 - "<<(a+2)/2<<endl;
}
int begin9 (int a, int b)
{
    cout<<"begin 9 - "<<sqrt(a*b)<<endl;
}
double begin10 (double a, double b)
{
    cout<<"begin 10 - "<<pow (a,2) + pow(b,2)<<endl<<pow (a,2) - pow(b,2)<<endl<<pow (a,2) * pow(b,2)<<endl<<pow (a,2) / pow(b,2)<<endl;
}
double begin11 (double a,double b)
{
    cout<<"begin 11 - "<<abs (a) + abs (b)<<endl<<abs (a) - abs (b)<<endl<<abs (a) * abs (b)<<endl<<abs (a) / abs (b)<<endl;
}
double begin12 (double a, double b, double c)
{
    cout<<"begin 12 - "<<sqrt (pow (a,2) + (pow (b,2)))<<endl<<a+b+c<<endl;
}
double begin13 (double r1, double r2)
{
    double s1 = PI * pow(r1,2);
    double s2 = PI * pow (r2,2);
    double s3 = s1 - s2;
    cout<<"begin 13 - "<<s1<<endl<<s2<<endl<<s3<<endl;
}
double begin14 (double r)
{
    double l = 2*PI*r;
    double s = PI*pow(r,2);
    cout<<"begin 14 - "<<l<<endl<<s<<endl;
}
double begin15 (double d)
{
    double l = PI*d;
    double s = PI*pow(d,2)/4;
    cout<<"begin 15 - "<<l<<endl<<s<<endl;
}
int begin16 (int x1, int x2)
{
   int a = abs (x2-x1);
   cout<<"begin 16 - "<<a<<endl;
}
int begin17 (int a, int b, int c)
{
    int ac = a+c;
    int bc = b+c;
    int q = ac + bc;
    cout<<"begin 17 - "<<ac<<endl<<bc<<endl<<q<<endl;
}
int begin18 (int a,  int b, int c)
{
    int ac = c - a;
    int bc = c - b;
    int q = ac  * bc;
    cout<<"begin 18 - "<<q<<endl;
}
int begin19 (int x1, int y1, int x2, int y2)
{
    int a = (x2-x1);
    int b = (y2-y1);
    int p = (2*(a+b));
    int s =  a*b;
    cout<<"begin 19 - "<<p<<endl<<s<<endl;
}
int begin20 (int x1, int y1, int x2, int y2)
{
    int a = pow ((x2-x1), 2);
    int b = pow ((y2 - y1), 2);
    int res = sqrt (a + b);
    cout<<"begin 20 - "<<res<<endl;
}
int begin21 (int x1, int y1, int x2, int y2, int x3, int y3, int a, int b, int c)
{
    int a1  = pow ((x2-x1), 2);
    int a2 = pow ((y2 - y1), 2);
    int res1 = sqrt (a1 + a2);
    int p = (a+b+c)/2;
    int s = sqrt (p*(p-a)*(p-b)*(p-c));
    cout<<"begin 21 - "<<res1<<endl<<s<<endl;
}
int begin22 (int a, int b, int c)
{
    c=a;
    a=b;
    b=c;
    cout<<"begin 22 - "<<a<<endl<<b<<endl;
}
int begin23 (int a, int b, int c)
{
    a=b;
    b=c;
    c=a;
  cout<<"begin 23 - "<<a<<endl<<b<<endl<<c<<endl;
}
int begin24 (int a, int b, int c)
{
    a=c;
    c=b;
    b=a;
    cout<<"begin 24 - "<<a<<endl<<b<<endl<<c<<endl;
}
double begin25 (double x)
{
    double y = 3 * pow(x,6) - 6 * pow (x,2) - 7;
    cout<<"begin 25 - "<<y<<endl;
}
double begin26 (double x)
{
    double y = 4 * (pow((x-3), 6)) - 7 * (pow ((x-3),3)) + 2;
    cout<<"begin 26 - "<<y<<endl;
}
int begin27 (int a)
{
    int temp = pow (a,2);
    int temp1 = temp*temp;
    int temp2 = temp*temp1*temp;
    cout<<"begin 27 - "<<temp<<endl<<temp1<<endl<<temp2<<endl;
}
int begin28 (int a)
{
    int temp = pow (a,2);
    int temp1 = temp*a;
    int temp2 = temp*temp*a;
    int temp3 = temp2*temp2;
    int temp4 = temp3*temp2;
    cout<<"begin 28 - "<<temp<<endl<<temp1<<endl<<temp2<<endl<<temp3<<endl<<temp4<<endl;
}
double begin29 (double a)
{
    double res = (a*PI)/180;
    cout<<"begin 29 - "<<res<<endl;
}
double begin30 (double a)
{
    double res = (a*(180/PI));
    cout<<"begin 30 - "<<res<<endl;
}
double begin31 (double tf)
{
    double tc = (tf-32) * 5/9;
    cout<<"begin 31 - "<<tc<<endl;
}
double begin32 (double tc)
{
    double tf = (tc + 32) * 9/5;
    cout<<"begin 32 - "<<tf<<endl;
}
double begin33 (double a, double x, double y)
{
    double kg1 = a/x;
    double nkg = y * kg1;
    cout<<"Begin 33 - "<<kg1<<endl<<nkg<<endl;
}
double begin34(double shokoves, double shokocena, double irisves, double iriscena)
{
    double shokoves1kg = shokocena/shokoves;
    double iris1kg = iriscena/irisves;
    double res = shokoves1kg/iris1kg;
    cout<<"Begin 34 - "<<shokoves1kg<<endl<<iris1kg<<endl<<res<<endl;
}
double begin35(double v, double u, double t1, double t2)
{
    double s = v*t1;
    double v1 = v-u;
    cout<<"Begin 35 - "<<s+v1*t2<<endl;
}
double begin36(double v1, double v2, double s, double t)
{
    double v3 = v1+v2;
    cout<<"Begin 36 - "<<s+v3*t<<endl;
}
double begin37 (double v1, double v2, double s, double t)
{
    double res = abs (s - (v1+v2)* t);
    cout<<"Begin 37 - "<<res<<endl;
}
double begin38 (double a, double b)
{
    double res = -b/a;
    cout<<"Begin 38 - "<<res<<endl;
}
double begin39 (double a, double b, double c)
{
    double d = pow(b,2)- 4 * a * c;
    double x1 = (-b + sqrt(d)) / (2 * a);
    double x2 = (-b + sqrt(d)) / (2 * a);
    cout<<"Begin 39 - "<<(min(x1,x2))<<" "<<(max(x1,x2))<<endl;
}
double begin40 (double a, double b, double c, double a1, double b1, double c1)
{
    double d = a*b1-a1*b;
    double x = (c*b1 - c1*b)/d;
    double y = (a*c1-a1*c)/d;
    cout<<"Begin 40 - "<<x<<endl<<y<<endl;
}
int main (){
begin1 (2);
begin2 (4);
begin3 (4,5);
begin4 (3);
begin5 (4);
begin6 (4,5,3);
begin7 (5);
begin8 (6,8);
begin9 (3,8);
begin10 (3,4);
begin11 (4,4);
begin12 (3,6,7);
begin13 (2,4);
begin14 (5);
begin15 (9);
begin16 (8,2);
begin17 (4,3,6);
begin18 (5,5,0);
begin19 (9,8,7,6);
begin20 (5,7,8,9);
begin21 (1,4,5,8,8,9,6,5,4);
begin22 (4,5,3);
begin23 (4,2,5);
begin24 (2,9,8);
begin25 (2);
begin26 (5);
begin27 (2);
begin28 (2);
begin29 (5);
begin30 (7);
begin31 (41);
begin32 (5);
begin33 (8,4,5);
begin34 (4,8,3,6);
begin35 (8,7,6,9);
begin36 (5,6,4,7);
begin37 (7,8,9,5);
begin38 (4,6);
begin39 (54,87,45);
begin40(5,4,9,4,7,8);
}
