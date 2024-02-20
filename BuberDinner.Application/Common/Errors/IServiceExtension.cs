using System.Net;

namespace BuberDinner.Application.Common.Errors;
public interface IServiceExtension
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}