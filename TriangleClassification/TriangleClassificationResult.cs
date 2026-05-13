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
public record InvalidInput(InputErrorType ErrorType, string Message) : TriangleClassificationResult;
