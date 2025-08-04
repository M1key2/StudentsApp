using Microsoft.EntityFrameworkCore;

namespace StudentsApp.Helpers
{
    public static class CollectionSyncHelper
    {
        public static void SynchronizeCollections<T>(
            DbContext context,
            ICollection<T> existingCollection,
            IEnumerable<T> updatedCollection,
            Func<T, int> keySelector,
            Action<T, T> updateAction,
            Action<T> addAction
        ) where T : class
        {
            var itemsToRemove = existingCollection
                .Where(e => !updatedCollection.Any(u => keySelector(u) == keySelector(e)))
                .ToList();

            foreach (var item in itemsToRemove)
                context.Set<T>().Remove(item);

            foreach (var updatedItem in updatedCollection)
            {
                var existingItem = existingCollection
                    .FirstOrDefault(e => keySelector(e) == keySelector(updatedItem));

                if (existingItem == null)
                    addAction(updatedItem);
                else
                    updateAction(existingItem, updatedItem);
            }
        }
    }
}
