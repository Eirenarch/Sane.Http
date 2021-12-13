# Sane.Http.HttpResponseException
HttpResponseException and corresponding middleware and helpers.

# Motivation
ASP.NET MVC used to have HttpResponseException which when thrown was caught by the framework and converted to the specified status code response. This was removed in ASP.NET Core because it was misused, namely people would throw it from their business logic layer. Some people also feel like it is a bad practice to treat 400 and 500 responses as exceptions (we disagree).

One thing you could do with HttpResponseException is create methods to return a specific status code on specific conditions. For example a common pattern would be something like

    public async Task<Post> Get(Guid id)
    {
        Post? post = await PostService.GetFeedPostAsync(id);
        ThrowNotFoundIfNull(post);
    
        return post;
    }


The alternative without HttpResponseException looks like this

    public async Task<ActionResult<Post>> Get(Guid id)
    {
        Post? post = await PostService.GetFeedPostAsync(id);
    
        if (post is null)
        {
            return NotFound();
        }
    
        return post;
    }


The problem with this approach is that the developer can't hide the ifs in a method. Sometimes the ifs might be more complex and will need specific method call for the condition. Using exceptions allows to return the status code directly from the method.

To use HttpResponseExceptions add the middleware

    app.UseHttpResponseExceptions();

and use the ThrowHelper class or throw the exception yourself. You can also add a global static using for the ThrowHelper or you can add helper methods in your base controller class.
