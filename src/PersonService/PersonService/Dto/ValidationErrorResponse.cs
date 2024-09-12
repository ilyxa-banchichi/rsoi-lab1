namespace PersonService.Dto;

public class ValidationErrorResponse
{
    public string Message { get; set; }
    
    public ValidationErrorResponse(string message)
    {
        Message = message;
    }
}