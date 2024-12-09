using Microsoft.EntityFrameworkCore;
using Moq;

namespace OrderTest;

public static class MockDbSetExtensions
{
    public static void SetupData<T>(this Mock<DbSet<T>> mockSet, List<T> data) where T : class
    {
        var queryableData = data.AsQueryable();

        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());
    }
}
