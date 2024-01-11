using FirebaseAdmin.Messaging;
using System.Net;

namespace IMS.Contract.ExceptionHandling;

public class HttpException : Exception
{
    public HttpStatusCode Status { get; }
    public string Message { get; set; }

    public HttpException(HttpStatusCode statusCode, string message)
    {
        Status = statusCode;
        Message = message;
    }

    // bad request - 400
    public static HttpException BadRequestException(string message) 
        => new HttpException(HttpStatusCode.BadRequest, message);

    // Not found - 404
    public static HttpException NotFoundException(string message)
        => new HttpException(HttpStatusCode.NotFound, message);

    // UnAuthorized - 401
    public static HttpException UnauthorizedException(string message)
        => new HttpException(HttpStatusCode.Unauthorized, message);

    // no permission - 403
    public static HttpException NoPermissionException(string message)
        => new HttpException(HttpStatusCode.Forbidden, message);

    // add on ....

}
