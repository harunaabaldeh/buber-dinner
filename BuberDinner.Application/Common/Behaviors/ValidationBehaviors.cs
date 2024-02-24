using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request,
                                                      CancellationToken cancellationToken,
                                                      RequestHandlerDelegate<TResponse> next)
    {
        if (_validator is null) return await next();

        var validationReuslt = await _validator.ValidateAsync(request, cancellationToken);

        if (validationReuslt.IsValid) return await next();

        var errors = validationReuslt.Errors.ConvertAll(validationFailure => Error.Validation(
         validationFailure.PropertyName, validationFailure.ErrorMessage
        ));

        return (dynamic)errors;
    }
}