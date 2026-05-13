namespace TriangleClassification;

public abstract record TriangleClassificationResult;

public record EquilateralTriangle() : TriangleClassificationResult;
public record IsoscelesTriangle() : TriangleClassificationResult;
public record ScaleneTriangle() : TriangleClassificationResult;

public enum InputErrorType
{
	SideLengthsMustBePositive,
	ViolatesTriangleInequality
}
public record InputValidationError(InputErrorType ErrorType, string Message);
public record InvalidInput(IReadOnlyList<InputValidationError> Errors) : TriangleClassificationResult;
