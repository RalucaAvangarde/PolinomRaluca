# PolinomRaluca
The solution of the problem is composed of two scripts, PolinomScript which derive from MonoBehaviour, this class reprezent the UI actions and buttons, and Polinom class for polynomial operations. The polynomial coefficients comes from an input field and I saved them in a list in reverse order.
 The Polinom class contains 2 properties "Coeficienti" of type List<double> that stores all of the coefficients of the polinom using the following representation : (a)indice i <=> a^i; and "Grad" of type int that represents the greatest power of the polinom. 
	The polinom class has 2 constructors, the special method that is call on object creation ex: var p1 = new Polinom(), one is parameterless which means it returns a polinom with "Grad" = 0 and without coefficients and the other constructor receive as parameter a list of doubles that represent the coefficients , save it in polinom.coeficienti and automatically calculate the degree of polinom which is coeficienti.count - 1, "-1" because the constant (coefficient of x to the power of 0) is not included in the grad. 
	I use polymorphism for method "ToString" from base class Object and this allowed me to convert a polinom from a list of coefficients to a pretty string that is more human readable, for ex:
	[4 2 0] => 4*x^2 + 2 * x^1 + 0 * x^0, and also allows me to write:
	print(a) instead of print(a.toString()) where ‘a’ is an instance of Polinom class.
	The methods for polinom class allow us to perform operations like:
GetPolinomValue in a specific point
Addition of 2 polinoms
Difference of 2 polinoms
Multiply 2 polinoms
Derive 2 polinoms
Integrate 2 polinoms
For addition, difference and multiplication of 2 polinoms i decide to use C# operators overloading because is more human-readable and allows me to use the method much easy. For example, instead of doing something like this: a.SumWith(b) where a and b ar polinoms I can use it like : a + b, so, to overload an operator in C# the method needs to contain “static” keyword because it`s a method of “Polinom” class not of an instance of it, that means i can use it like Polinom A + Polinom B and i do not need to create another instance polinom C just for call the function like C.Sum(A,B).
Plot chart:
Signature public void PlotChart(Polinom polinom)
This method receive as input a parameter of type Polinom, I use a list<Vector2> where o store my values for chart: from -10 to 10 with step (0.02),i use x to be i, the step of for loop and y to be the value of polinom in point i clamped in interval -10, 10 (the value  is reduced to interval [-10,10]) and add this values to list of vector2, after receiving all values i just instantiate a point at every member of list<vector2> coordinates.
