namespace Example.Core.Tests.Pagination;

/// <summary>
/// Sichert beide Erweiterungsmethoden aus <see cref="QueryableExtensions"/> ohne Datenbank über
/// LINQ-to-Objects ab.
/// </summary>
[Trait("Category", "Fast")]
public sealed class QueryableExtensionsTests
{
    private sealed record TestPageable(int Page, int PageSize) : IPageable;

    private sealed record TestItem(int Value);

    [Fact]
    public void AsPage_on_a_sorted_source_returns_the_requested_slice_and_the_total_count()
    {
        var source = Enumerable.Range(1, 10).AsQueryable().OrderBy(value => value);
        var page = new TestPageable(Page: 2, PageSize: 3);

        var result = source.AsPage(page);

        result.Count.Should().Be(10);
        result.Items.Should().Equal(4, 5, 6);
    }

    [Fact]
    public void AsPage_on_a_page_past_the_end_returns_the_total_count_and_empty_items()
    {
        var source = Enumerable.Range(1, 10).AsQueryable().OrderBy(value => value);
        var page = new TestPageable(Page: 5, PageSize: 3);

        var result = source.AsPage(page);

        result.Count.Should().Be(10);
        result.Items.Should().BeEmpty();
    }

    [Fact]
    public void AsPage_on_an_empty_source_returns_zero_count_and_empty_items()
    {
        var source = Array.Empty<int>().AsQueryable().OrderBy(value => value);
        var page = new TestPageable(Page: 1, PageSize: 3);

        var result = source.AsPage(page);

        result.Count.Should().Be(0);
        result.Items.Should().BeEmpty();
    }

    [Fact]
    public void PageResponse_projects_the_requested_slice_and_returns_the_same_total_count_as_AsPage()
    {
        var source = Enumerable.Range(1, 10)
            .Select(value => new TestItem(value))
            .AsQueryable()
            .OrderBy(item => item.Value);
        var page = new TestPageable(Page: 2, PageSize: 3);

        var result = source.PageResponse(page, item => item.Value);

        result.Count.Should().Be(10);
        result.Items.Should().Equal(4, 5, 6);
    }

    [Fact]
    public void AsPage_throws_ArgumentNullException_when_source_is_null()
    {
        IOrderedQueryable<int>? nullSource = null;
        var page = new TestPageable(Page: 1, PageSize: 1);

        var action = () => nullSource!.AsPage(page);

        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AsPage_throws_ArgumentNullException_when_page_is_null()
    {
        var source = Enumerable.Range(1, 3).AsQueryable().OrderBy(value => value);

        var action = () => source.AsPage(null!);

        action.Should().Throw<ArgumentNullException>();
    }
}
