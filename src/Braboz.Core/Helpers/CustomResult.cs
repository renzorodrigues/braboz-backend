﻿using System.Net;

namespace Braboz.Core.Helpers
{
    public class CustomResult
    {
        public HttpStatusCode StatusCode { get; set; } = new HttpResponseMessage().StatusCode;
        public bool IsSuccess { get; set; } = new HttpResponseMessage().IsSuccessStatusCode;
        public IEnumerable<Error>? Errors { get; set; }
        public string? Message { get; set; }
    }
}
