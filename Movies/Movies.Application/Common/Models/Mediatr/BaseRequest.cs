﻿using MediatR;

namespace Movies.Application.Common.Models.Mediatr
{
    public class BaseRequest<T> : IBaseRequest, IRequest<T>
    {
    }
}
