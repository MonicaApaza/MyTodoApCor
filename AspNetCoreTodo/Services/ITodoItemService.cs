using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user);
        Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user);
        Task<bool> MarkDoneAsync(Guid id, IdentityUser user);
    }
}