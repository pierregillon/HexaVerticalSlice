using Reqnroll;

namespace HexaVerticalSlice.Api.Tests.Acceptance.Utils;

public class ErrorDriver(ScenarioInfo scenarioInfo)
{
    private readonly Queue<HttpError> _errors = new();

    private bool InErrorScenario => scenarioInfo.Tags.Contains("ErrorHandling");

    public async Task TryExecute(Func<Task> action)
    {
        if (!InErrorScenario)
        {
            await action();
        }
        else
        {
            try
            {
                await action();
            }
            catch (HttpException ex)
            {
                _errors.Enqueue(new HttpError(ex));
            }
        }
    }

    public async Task<TResult> TryExecute<TResult>(Func<Task<TResult>> action)
    {
        if (!InErrorScenario)
        {
            return await action();
        }

        try
        {
            return await action();
        }
        catch (HttpRequestException ex)
        {
            _errors.Enqueue(new HttpError(HttpException.From("", ex.StatusCode ?? 0)));
            return default!;
        }
        catch (HttpException ex)
        {
            _errors.Enqueue(new HttpError(ex));
            return default!;
        }
    }

    public HttpError GetLastError()
    {
        if (!_errors.TryDequeue(out var error))
        {
            throw new ReqnrollException("No error has been thrown but it should");
        }

        return error;
    }

    public void ThrowIfNotProcessedException()
    {
        if (_errors.Any())
        {
            throw new ReqnrollException("An error occurred during scenario but has not be processed.",
                _errors.Dequeue().InnerException);
        }
    }
}