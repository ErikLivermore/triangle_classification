using TriangleClassification;

static void PrintResult(TriangleClassificationResult result)
{
	var message = result switch
	{
		EquilateralTriangle => "Equilateral triangle",
		IsoscelesTriangle => "Isosceles triangle",
		ScaleneTriangle => "Scalene triangle",
		InvalidInput invalidInput => $"Invalid input: {string.Join(" ", invalidInput.Errors.Select(error => $"{error.ErrorType}: {error.Message}"))}",
	};

	Console.WriteLine(message);
}

PrintResult(TriangleClassificationService.ClassifyTriangle(1, 1, 1));
PrintResult(TriangleClassificationService.ClassifyTriangle(1, 2, 2));
PrintResult(TriangleClassificationService.ClassifyTriangle(3, 4, 5));
PrintResult(TriangleClassificationService.ClassifyTriangle(-1, 2, 4));
PrintResult(TriangleClassificationService.ClassifyTriangle(-1, -3, -6));
PrintResult(TriangleClassificationService.ClassifyTriangle(3, 1, 2));