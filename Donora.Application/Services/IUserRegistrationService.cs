public interface IUserRegistrationService
{
    Task<ValidationResponse> ValidateAsync(UserRegistrationValidationRequest request);
}