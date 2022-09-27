using enigma_core.models;
using Microsoft.AspNetCore.Mvc;

namespace enigma_core.utils;

public class Requests
{
    public static IActionResult Response(ControllerBase controller, ApiStatus statusCode, object dataValue, string msg)
    {
        var e = new ApiStatus(statusCode.StatusCode);
        var _ = new
        {
            status = e.StatusCode,
            error = true,
            detail = "",
            message = e.StatusDescription,
            data = dataValue
        };

        if (statusCode.StatusCode != 200)
        {
            _ = new
            {
                status = e.StatusCode,
                error = true,
                detail = msg,
                message = e.StatusDescription,
                data = dataValue
            };
        }
        else 
        {
            _ = new
            {
                status = e.StatusCode,
                error = false,
                detail = msg,
                message = e.StatusDescription,
                data = dataValue
            };
        }

        return controller.StatusCode(statusCode.StatusCode, _);
    }
}