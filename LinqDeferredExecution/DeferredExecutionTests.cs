using FluentAssertions;

namespace LinqDeferredExecution;

public class DeferredExecutionTests
{
    public IEnumerable<Wrapper<T>> CreateWrapper<T>(IEnumerable<T> items)
    {
        return items.Select(item => new Wrapper<T>(item));
    }

    [Test]
    public void DeferredExecutionCreatesNewWrappers()
    {
        var items = Enumerable.Range(1, 10).ToList();
        var wrappers = CreateWrapper(items);

        var store = new List<Wrapper<int>>();
        store.AddRange(wrappers);

        var storeContainsAnyWrappers = wrappers.Any(wrapper => store.Contains(wrapper));

        storeContainsAnyWrappers.Should().BeFalse();
    }

    [Test]
    public void MaterializingItemsPreventsReevaluation()
    {
        var items = Enumerable.Range(1, 10).ToList();
        var wrappers = CreateWrapper(items).ToList();

        var store = new List<Wrapper<int>>();
        store.AddRange(wrappers);

        var storeContainsAnyWrappers = wrappers.Any(wrapper => store.Contains(wrapper));

        storeContainsAnyWrappers.Should().BeTrue();
    }
}