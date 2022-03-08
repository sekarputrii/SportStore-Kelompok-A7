using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace SportsStore.Models {

    /// <summary>
    /// class identity seed data
    /// </summary>
    public static class IdentitySeedData {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        /// <summary>
        /// user manager, identity user
        /// </summary>
        /// <param name="userManager">manager pengguna</param>
        /// <returns></returns>
        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager) {
            
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null) {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}