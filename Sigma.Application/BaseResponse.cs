﻿namespace Sigma.Application;

public class BaseResponse<TData>
{
    public TData Data { get; set; }

    public bool IsSuccess { get; set; }

    public IEnumerable<ErrorResponse> Errors { get; set; }
}