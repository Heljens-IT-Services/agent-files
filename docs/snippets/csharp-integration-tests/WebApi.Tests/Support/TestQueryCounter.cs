namespace Example.WebApi.Tests.Support;

/// <summary>
/// Zählt an die Datenbank abgesetzte Befehle, um N+1-Abfragen messbar auszuschließen. Threadsicher,
/// weil der Testserver Anfragen nebenläufig ausführen kann.
/// </summary>
public sealed class TestQueryCounter
{
    private int _count;

    public int Count => Volatile.Read(ref _count);

    public void Increment() => Interlocked.Increment(ref _count);

    public void Reset() => Interlocked.Exchange(ref _count, 0);
}
