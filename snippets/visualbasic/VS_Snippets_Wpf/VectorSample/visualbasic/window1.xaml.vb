'This is a list of commonly used namespaces for a window.

Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media


Namespace VectorSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
		   InitializeComponent()
		End Sub

		Public Sub PerformOperation(ByVal sender As Object, ByVal e As RoutedEventArgs)

			Dim li As RadioButton = TryCast(sender, RadioButton)

			' Strings used to display results
			Dim syntaxString, resultType, operationString As String

			'''The local variables point1, point2, vector2, etc are defined in each
			'''case block for readability reasons. Each variable is contained within
			'''the scope of each case statement.  

			Select Case li.Name

				Case "rb1"
						' Translates a Point by a Vector using the overloaded + operator.

						Dim point1 As New System.Windows.Point(10, 5)
						Dim vector1 As New Vector(20, 30)
						Dim pointResult As New System.Windows.Point()

						pointResult = point1 + vector1

						' pointResult is equal to (-10,-25) 

						' Displaying Results
						syntaxString = "pointResult = point1 + vector1"
						resultType = "Point"
						operationString = "Translating a Point by a Vector"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb2"

						'<Snippet10>                    
						' Adds a Vector to a Vector using the overloaded + operator.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim vectorResult As New Vector()


						' vectorResult is equal to (65,100)
						vectorResult = vector1 + vector2
						'</Snippet10> 



						' Displaying Results
						syntaxString = "vectorResult = vector1 + vector2"
						resultType = "Vector"
						operationString = "Adding a Vector to a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb3"
						' Adds a Vector to a Vector using the static Add method.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim vectorResult As New Vector()

						vectorResult = Vector.Add(vector1, vector2)

						' vectorResult is equal to (65,100)

						' Displaying Results
						syntaxString = "vectorResult = Vector.Add(vector1, vector2)"
						resultType = "Vector"
						operationString = "Adding a Vector to a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb4"
						' Translates a Point by a Vector using the static Add method.  

						Dim vector1 As New Vector(20, 30)
						Dim point1 As New System.Windows.Point(10, 5)
						Dim pointResult As New System.Windows.Point()

						pointResult = Vector.Add(vector1, point1)

						' vectorResult is equal to (30,35)

						' Displaying Results
						syntaxString = "pointResult = Vector.Add(vector1, point1)"
						resultType = "Point"
						operationString = "Translating a Point by a Vector"
						ShowResults(pointResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb5"
						' Subtracts a Vector from a Vector using the overloaded - operator.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim vectorResult As New Vector()

						vectorResult = vector1 - vector2

						' vector Result is equal to (-25, -40)

						' Displaying Results 
						syntaxString = "vectorResult = vector1 - vector2"
						resultType = "Vector"
						operationString = "Subtracting a Vector from a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb6"
						' Subtracts a Vector from a Vector using the static Subtract method.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim vectorResult As New Vector()

						vectorResult = Vector.Subtract(vector1, vector2)

						' vector Result is equal to (-25, -40)

						' Displaying Results
						syntaxString = "Vector.Subtract(vector1, vector2)"
						resultType = "Vector"
						operationString = "Subtracting a Vector from a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select
				Case "rb7"
						' Multiplies a Vector by a Scalar using the overloaded * operator.  

						Dim vector1 As New Vector(20, 30)
						Dim scalar1 As Double = 75
						Dim vectorResult As New Vector()

						vectorResult = vector1 * scalar1

						' vectorResult is equal to (1500,2250)

						' Displaying Results
						syntaxString = "vectorResult = vector1 * scalar1"
						resultType = "Vector"
						operationString = "Multiplies a Vector by a Scalar"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb8"
						' Multiplies a Scalar by a Vector using the overloaded * operator.  

						Dim vector1 As New Vector(20, 30)
						Dim scalar1 As Double = 75
						Dim vectorResult As New Vector()

						vectorResult = scalar1 * vector1

						' vectorResult is equal to (1500,2250)

						' Displaying Results
						syntaxString = "vectorResult = scalar1 * vector1"
						resultType = "Vector"
						operationString = "Multiplies a Scalar by a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select
				Case "rb9"
						' Multiplies a Vector by a Vector using the overloaded * operator.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim doubleResult As Double

						doubleResult = vector1 * vector2

						' doubleResult is equal to 3000

						' Displaying Results
						syntaxString = "doubleResult = vector1 * vector2"
						resultType = "Double"
						operationString = "Multiplies a Vector by a Vector"
						ShowResults(doubleResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb10"
						' Multiplies a Vector by a Matrix using the overloaded * operator.  

						Dim vector1 As New Vector(20, 30)
						Dim matrix1 As New Matrix(40, 50, 60, 70, 80, 90)
						Dim vectorResult As New Vector()

						vectorResult = vector1 * matrix1

						' vector Result is equal to (2600,3100)


						' Displaying Results
						syntaxString = "vectorResult = vector1 * matrix1"
						resultType = "Vector"
						operationString = "Multiplies a Vector by a Matrix"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb11"
						' Multiplies a Vector by a Scalar using the static Multiply method.  

						Dim vector1 As New Vector(20, 30)
						Dim scalar1 As Double = 75
						Dim vectorResult As New Vector()

						vectorResult = Vector.Multiply(vector1, scalar1)

						' vectorResult is equal to (1500,2250)

						' Displaying Results
						syntaxString = "vectorResult = Vector.Multiply(vector1, scalar1)"
						resultType = "Vector"
						operationString = "Multiplies a Vector by a Scalar"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb12"
						' Multiplies a Scalar by a Vector using the static Multiply method.  

						Dim vector1 As New Vector(20, 30)
						Dim scalar1 As Double = 75
						Dim vectorResult As New Vector()

						vectorResult = Vector.Multiply(scalar1, vector1)

						' vectorResult is equal to (1500,2250)

						' Displaying Results
						syntaxString = "vectorResult = Vector.Multiply(scalar1, vector1)"
						resultType = "Vector"
						operationString = "Multiplies a Scalar by a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb13"
						' Multiplies a Vector by a Vector using the static Multiply method.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim doubleResult As Double

						doubleResult = Vector.Multiply(vector1,vector2)

						' doubleResult is equal to 3000

						' Displaying Results
						syntaxString = "DoubleResult = Vector.Multiply(vector1,vector2)"
						resultType = "Double"
						operationString = "Multiplies a Vector by a Vector"
						ShowResults(doubleResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb14"
						' Multiplies a Vector by a Matrix using the static Multiply method.  

						Dim vector1 As New Vector(20, 30)
						Dim matrix1 As New Matrix(40, 50, 60, 70, 80, 90)
						Dim vectorResult As New Vector()

						vectorResult = Vector.Multiply(vector1,matrix1)

						' vector Result is equal to (2600,3100)


						' Displaying Results
						syntaxString = "vectorResult = Vector.Multiply(vector1,matrix1)"
						resultType = "Vector"
						operationString = "Multiplies a Vector by a Matrix"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb15"
						' Divides a Vector by a Scalar using the overloaded / operator.  

						Dim vector1 As New Vector(20, 30)
						Dim vectorResult As New Vector()
						Dim scalar1 As Double = 75

						vectorResult = vector1 / scalar1

						' vectorResult is approximately equal to (0.26667,0.4)

						' Displaying Results
						syntaxString = "vectorResult = vector1 / scalar1"
						resultType = "Vector"
						operationString = "Dividing a Vector by a Scalar"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select
				Case "rb16"
						' Divides a Vector by a Double using the static Divide method.  

						Dim vector1 As New Vector(20, 30)
						Dim vectorResult As New Vector()
						Dim scalar1 As Double = 75

						vectorResult = Vector.Divide(vector1, scalar1)

						' vectorResult is approximately equal to (0.26667,0.4)

						' Displaying Results
						syntaxString = "vectorResult = Vector.Divide(vector1, scalar1)"
						resultType = "Vector"
						operationString = "Dividing a Vector by a Scalar"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb17"
						' Gets the hashcode of a Vector structure

						Dim vector1 As New Vector(20, 30)
						Dim vectorHashCode As Integer

						vectorHashCode = vector1.GetHashCode()

						' Displaying Results
						syntaxString = "vectorHashCode = vector1.GetHashCode()"
						resultType = "int"
						operationString = "Getting the hashcode of a Vector"
						ShowResults(vectorHashCode.ToString(), syntaxString, resultType, operationString)
						Exit Select


				Case "rb18"
						' Gets the length of a Vector.  

						Dim vector1 As New Vector(20, 30)
						Dim length As Double

						length = vector1.Length

						' length is approximately equal to 36.0555


						' Displaying Results
						syntaxString = "length = vector1.Length()"
						resultType = "Double"
						operationString = "Getting the length of a Vector"
						ShowResults(length.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb19"
						' Gets the square of the length of a Vector.  

						Dim vector1 As New Vector(20, 30)
						Dim lengthSq As Double

						lengthSq = vector1.LengthSquared

						' lengthSq is equal to 1300

						' Displaying Results
						syntaxString = "lengthSq = vector1.LengthSquared"
						resultType = "Double"
						operationString = "Getting the length square of a Vector"
						ShowResults(lengthSq.ToString(), syntaxString, resultType, operationString)
						Exit Select
				Case "rb20"
						' Normalizes a Vector using the Normalize method.  

						Dim vector1 As New Vector(20, 30)

						vector1.Normalize()

						' vector1 is approximately equal to (0.5547,0.8321) 

						' Displaying Results
						syntaxString = "vector1.Normalize()"
						resultType = "Vector"
						operationString = "Normalizing a Vector"
						ShowResults(vector1.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb21"
						' Calculates the angle between two Vectors using the static AngleBetween method. 

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim angleBetween As Double

						angleBetween = Vector.AngleBetween(vector1, vector2)

						' angleBetween is approximately equal to 0.9548

						' Displaying Results
						syntaxString = "angleBetween = Vector.AngleBetween(vector1, vector2)"
						resultType = "Double"
						operationString = "Calculating the angle between two Vectors"
						ShowResults(angleBetween.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb22"
						' Calculates the cross product of two Vectors using the static  CrossProduct method.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim crossProduct As Double

						crossProduct = Vector.CrossProduct(vector1,vector2)

						' crossProduct is equal to 50

						' Displaying Results
						syntaxString = "crossProduct = Vector.CrossProduct(vector1,vector2)"
						resultType = "Double"
						operationString = "Calculating the crossproduct of two Vectors"
						ShowResults(crossProduct.ToString(), syntaxString, resultType, operationString)
						Exit Select



				Case "rb23"
						' Calculates the determinant of two Vectors using the static Determinant method.  

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim determinant As Double

						determinant = Vector.Determinant(vector1, vector2)

						' determinant is equal to 50

						' Displaying Results
						syntaxString = "determinant = Vector.Determinant(vector1, vector2)"
						resultType = "Double"
						operationString = "Calculating the determinant of two Vectors"
						ShowResults(determinant.ToString(), syntaxString, resultType, operationString)
						Exit Select


				Case "rb24"
						' Checks if two Vectors are equal using the overloaded equality operator.

						' Declaring vecto1 and initializing x,y values
						Dim vector1 As New Vector(20, 30)

						' Declaring vector2 without initializing x,y values
						Dim vector2 As New Vector()

						' Boolean to hold the result of the comparison
						Dim areEqual As Boolean

						' assigning values to vector2
						vector2.X = 45
						vector2.Y = 70

						' Comparing Vectors for equality
						areEqual = (vector1 = vector2)

						' areEqual is False

						' Displaying Results
						syntaxString = "areEqual = (vector1 == vector2)"
						resultType = "Boolean"
						operationString = "Checking if two vectors are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						Exit Select


				Case "rb25"
						' Checks if two Vectors are equal using the static Equals method.

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim areEqual As Boolean

						areEqual = Vector.Equals(vector1, vector2)

						' areEqual is False    

						' Displaying Results
						syntaxString = "areEqual = Vector.Equals(vector1, vector2)"
						resultType = "Boolean"
						operationString = "Checking if two vectors are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						Exit Select
				Case "rb26"
						' Compares an Object and a Vector for equality using the non-static Equals method.

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim areEqual As Boolean

						areEqual = vector1.Equals(vector2)

						' areEqual is False    


						' Displaying Results
						syntaxString = "areEqual = vector1.Equals(vector2)"
						resultType = "Boolean"
						operationString = "Checking if two vectors are equal"
						ShowResults(areEqual.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb27"
						' Converts a string representation of a vector into a Vector structure

						Dim vectorResult As New Vector()

						vectorResult = Vector.Parse("1,3")

						' vectorResult is equal to (1,3)

						' Displaying Results
						syntaxString = "vectorResult = Vector.Parse(""1,3"")"
						resultType = "Vector"
						operationString = "Converting a string into a Vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb28"
						' Checks if two Vectors are not equal using the overloaded inequality operator.

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)
						Dim areNotEqual As Boolean

						areNotEqual = (vector1 <> vector2)

						' areNotEqual is True

						' Displaying Results
						syntaxString = "areNotEqual = (vector1 != vector2)"
						resultType = "Boolean"
						operationString = "Checking if two points are not equal"
						ShowResults(areNotEqual.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb29"
						' Negates a Vector using the Negate method.

						Dim vector1 As New Vector(20, 30)
						Dim vectorResult As New Vector()

						vector1.Negate()

						' vector1 is equal to (-20, -30)

						' Displaying Results
						syntaxString = "vector1.Negate()"
						resultType = "void"
						operationString = "Negating a vector"
						ShowResults(vector1.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb30"
						' Negates a Vector using the overloaded unary negation operator.

						Dim vector1 As New Vector(20, 30)
						Dim vectorResult As New Vector()

						vectorResult = -vector1

						' vectorResult is equal to (-20, -30)

						' Displaying Results
						syntaxString = "vectorResult = -vector1"
						resultType = "Vector"
						operationString = "Negating a vector"
						ShowResults(vectorResult.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb31"
						' Gets a String representation of a Vector structure

						Dim vector1 As New Vector(20, 30)
						Dim vectorString As String

						vectorString = vector1.ToString()

						' vectorString is equal to 10,5

						' Displaying Results
						syntaxString = "vectorString = vector1.ToString()"
						resultType = "String"
						operationString = "Getting the string representation of a Vector"
						ShowResults(vectorString.ToString(), syntaxString, resultType, operationString)
						Exit Select
				Case "rb32"
						' Explicitly converts a Vector structure into a Size structure
						' Returns a Size.

						Dim vector1 As New Vector(20, 30)
						Dim size1 As New System.Windows.Size()

						size1 = CType(vector1, System.Windows.Size)

						' size1 has a width of 20 and a height of 30

						' Displaying Results
						syntaxString = "size1 = (Size)vector1"
						resultType = "Size"
						operationString = "Expliciting casting a Vector into a Size"
						ShowResults(size1.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case "rb33"
						' Explicitly converts a Vector structure into a Point structure
						' Returns a Point.

						Dim vector1 As New Vector(20, 30)
						Dim point1 As New System.Windows.Point()

						point1 = CType(vector1, System.Windows.Point)

						' point1 is equal to (20, 30)

						' Displaying Results
						syntaxString = "point1 = (Point)vector1"
						resultType = "Point"
						operationString = "Expliciting casting a Vector into a Point"
						ShowResults(point1.ToString(), syntaxString, resultType, operationString)
						Exit Select

				' task example.  this case statement is not referenced from the list of radio buttons
				Case "rb40"
						' adds two vectors using Add and +

						Dim vector1 As New Vector(20, 30)
						Dim vector2 As New Vector(45, 70)

						vector1 = vector1 + vector2
						' vector1 is now equal to (65, 100)

						vector1 = Vector.Add(vector1, vector2)
						' vector1 is now equal to (110, 170)

						' Displaying Results
						syntaxString = "vectorResult = Vector.Negate(vector1)"
						resultType = "Vector"
						operationString = "Negating a vector"
						ShowResults(vector1.ToString(), syntaxString, resultType, operationString)
						Exit Select

				Case Else
					Exit Select

			End Select ' end switch
		End Sub

		' Method to display the results of the operations
		Private Sub ShowResults(ByVal resultValue As String, ByVal syntax As String, ByVal resultType As String, ByVal opString As String)
			' Displays the results of the operation
			txtResultValue.Text = resultValue
			txtSyntax.Text = syntax
			txtResultType.Text = resultType
			txtOperation.Text = opString
		End Sub

		' Method to display the variables used in the operations
		Public Sub ShowVars()
			' Displays the values of the variables
			Dim p1 As New System.Windows.Point(10, 5)
			Dim p2 As New System.Windows.Point(15, 40)

			Dim v1 As New Vector(20, 30)
			Dim v2 As New Vector(45, 70)

			Dim m1 As New Matrix(40, 50, 60, 70, 80, 90)

			Dim s1 As Double = 75

			txtPoint1.Text = p1.ToString()
			txtPoint2.Text = p2.ToString()
			txtVector1.Text = v1.ToString()
			txtVector2.Text = v2.ToString()
			txtMatrix1.Text = m1.ToString()
			txtScalar1.Text = s1.ToString()
		End Sub

	End Class
End Namespace